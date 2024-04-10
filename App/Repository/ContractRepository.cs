using App.Repository;
using App.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
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
            var query = "SELECT * FROM Contracts WHERE id = @Id";
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
            var query = "INSERT INTO Contracts (clientId1,clientId2,musicId) VALUES (@clientId1,@clientId2,@musicId)";
            
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId1", contract.client1),
                new SqlParameter("@clientId2", contract.client2),
                new SqlParameter("@musicId", contract.song)
            };

            return ExecuteNonQuery(query, parameters);
        }

        public override bool Update(Contract contract)
        {
            var querry = "UPDATE Contracts SET clientId1 = @clientId1, clientId2 = @clientId2, musicId = @musicId WHERE id = @Id";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId1", contract.client1),
                new SqlParameter("@clientId2", contract.client2),
                new SqlParameter("@musicId", contract.song),
                new SqlParameter("@Id", contract.id)
            };
            return ExecuteNonQuery(querry, parameters);
        }

        public override bool Delete(Contract contract)
        {
            var query = "DELETE FROM Contracts WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", contract.id) };
            return ExecuteNonQuery(query, parameters);
        }

        public static Contract ContractMapper(IDataReader reader)
        {
            var id = (int)reader["id"];
            var client1 = (int)reader["clientId1"];
            var client2 = (int)reader["clientId2"];
            var songId = (int)reader["musicId"];
            var contract = new Contract(id,client1,client2, songId);
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