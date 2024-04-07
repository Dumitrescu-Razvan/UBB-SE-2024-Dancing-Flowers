using App.Repository.EntityRepository;
using App.Domain.Contract;

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
            return ExecuteQuery(query, ContractMapper);
        }

        public override bool Add(Contract contract)
        {
            var query = "INSERT INTO Contracts (id) VALUES (@id)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@id", contract.Id),
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
            return new Contract
            {
                Id = (Guid)reader["Id"],
            };
        }

        public Contract GetContractWithClients(int contractId)
        {
            Contract contract = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                string query = @"SELECT c.Id, client.*
                         FROM Contract c
                         INNER JOIN ContractUser cu ON c.Id = cu.ContractId
                         INNER JOIN [Client] client ON cu.ClientId = client.Id
                         WHERE c.Id = @ContractId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ContractId", contractId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (contract == null)
                            {
                                contract = new Contract
                                {
                                    ContractId = reader.GetInt32(reader.GetOrdinal("ContractId")),
                                    ContractName = reader.GetString(reader.GetOrdinal("ContractName")),
                                    Clients = new List<Clients>()
                                };
                            }

                            
                            Client client= Client.ClientMapper(reader);
                            contract.Clients.Add(client);
                        }
                    }
                }
            }

            return contract;
        }
    }
}