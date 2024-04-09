using App.Repository;
using App.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace App.Repository
{
    public class ContractRepository : EntityRepository<Contract>
    {


        public ContractRepository(string connectionString) : base(connectionString)
        {
        }

        public override Contract getById(int id)
        {
            var query = "SELECT * FROM Contracts WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", id) };
            return ExecuteQuery(query, ContractMapper, parameters).FirstOrDefault();
        }

        public override List<Contract> getAll()
        {
            var query = "SELECT * FROM Contracts";
            return ExecuteQuery(query, ContractMapper, null);
        }

        public override bool Add(Contract contract)
        {
            var query = "INSERT INTO Contracts (id) VALUES (@id)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@id", contract.id),
            };

            return ExecuteNonQuery(query, parameters);
        }

        public override bool Update(Contract contract)
        {

            return true;
        }

        public override bool Delete(Contract contract)
        {
            var query = "DELETE FROM Contracts WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", contract.Id) };
            return ExecuteNonQuery(query, parameters);
        }

        public static Contract ContractMapper(IDataReader reader)
        {
            var id = (int)reader["Id"];
            var contract = new Contract(id);
            return contract;
        }

        public Contract GetContractWithClientsAndSong(int contractId)
        {
            List<Client> clients = new List<Client>();
            Song song = null;

            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                string query = @"SELECT c.id, client.id, s.id
                         FROM Contract c
                         INNER JOIN ContractUser cu ON c.id = cu.contractId
                         INNER JOIN [Client] client ON cu.clientId = client.Id
                         INNER JOIN Song s on c.songId = s.id
                         WHERE c.Id = @ContractId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", contractId);
                    

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if(song == null)
                            {
                                int songId = (int)reader["s.id"];

                                song = new SongRepository(_connectionString).getById(songId);
                            }

                            int clientId = (int)reader["client.id"];

                            Client client = new ClientRepository(_connectionString).getById(clientId); 

                            
                            clients.Add(client);
                        }
                    }
                }
            }

            Contract contract = new Contract(contractId, clients, song);

            return contract;
        }

        public bool AddClientToContract(int contractId, int clientId)
        {
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO ContractUser (contractId, clientId) VALUES (@ContractId, @ClientId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", contractId);
                    command.Parameters.AddWithValue("@ClientId", clientId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool RemoveClientFromContract(int contractId, int clientId)
        {
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                string query = @"DELETE FROM ContractUser WHERE contractId = @ContractId AND clientId = @ClientId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", contractId);
                    command.Parameters.AddWithValue("@ClientId", clientId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}