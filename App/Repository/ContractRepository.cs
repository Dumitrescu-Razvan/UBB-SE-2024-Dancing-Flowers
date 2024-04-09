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
                
                


                string query = @"SELECT c.Id, client.*, song.*
                         FROM Contract c
                         INNER JOIN ContractUser cu ON c.Id = cu.ContractId
                         INNER JOIN [Client] client ON cu.ClientId = client.Id
                         INNER JOIN Song s on c.SongId = s.Id
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

                                int songTitleOrdinal = reader.GetOrdinal("s.title");
                                var songTitle = reader.IsDBNull(songTitleOrdinal) ? null : reader.GetString(songTitleOrdinal);

                                int songDurationOrdinal = reader.GetOrdinal("s.duration");
                                var songDuration = reader.IsDBNull(songDurationOrdinal) ? -1 : reader.GetInt32(songDurationOrdinal);

                                int songTimesPlayedOrdinal = reader.GetOrdinal("s.timesPlayed");
                                var songTimesPlayed = reader.IsDBNull(songTimesPlayedOrdinal) ? -1 : reader.GetInt32(songTimesPlayedOrdinal);

                                int songArtistOrdinal = reader.GetOrdinal("s.artist");
                                var songArtist = reader.IsDBNull(songArtistOrdinal) ? null : reader.GetString(songArtistOrdinal);

                                int songAlbumOrdinal = reader.GetOrdinal("s.album");
                                var songAlbum = reader.IsDBNull(songAlbumOrdinal) ? null : reader.GetString(songAlbumOrdinal);

                                int songRestrictionsOrdinal = reader.GetOrdinal("s.restrictions");
                                var songRestrictionsString = reader.IsDBNull(songRestrictionsOrdinal) ? null : reader.GetString(songRestrictionsOrdinal);
                                var songRestrictions = Song.getRestrictionsFromString(songRestrictionsString);

                                int songLikesOrdinal = reader.GetOrdinal("s.likes");
                                var songLikes = reader.IsDBNull(songLikesOrdinal) ? -1 : reader.GetInt32(songLikesOrdinal);

                                int songSharesOrdinal = reader.GetOrdinal("s.shares");
                                var songShares = reader.IsDBNull(songSharesOrdinal) ? -1 : reader.GetInt32(songSharesOrdinal);

                                int songSavesOrdinal = reader.GetOrdinal("s.saves");
                                var songSaves = reader.IsDBNull(songSavesOrdinal) ? -1 : reader.GetInt32(songSavesOrdinal);
                                
                                song = new Song(songId, songTitle, songArtist, songAlbum, songRestrictions, songDuration, songTimesPlayed, songLikes, songShares, songSaves);
                            }

                            int clientId = (int)reader["client.id"];
                            
                            int clientUsernameOrdinal = reader.GetOrdinal("client.username");
                            var clientUsername = reader.IsDBNull(clientUsernameOrdinal) ? null : reader.GetString(clientUsernameOrdinal);

                            var clientPasswordOrdinal = reader.GetOrdinal("client.password");
                            var clientPassword = reader.IsDBNull(clientPasswordOrdinal) ? null : reader.GetString(clientPasswordOrdinal);

                            var clientEmailOrdinal = reader.GetOrdinal("client.email");
                            var clientEmail = reader.IsDBNull(clientEmailOrdinal) ? null : reader.GetString(clientEmailOrdinal);

                            var clientPhoneOrdinal = reader.GetOrdinal("client.phone");
                            var clientPhone = reader.IsDBNull(clientPhoneOrdinal) ? null : reader.GetString(clientPhoneOrdinal);

                            var clientSaltOrdinal = reader.GetOrdinal("client.salt");
                            var clientSalt = reader.IsDBNull(clientSaltOrdinal) ? null : reader.GetString(clientSaltOrdinal);

                            var clientCompanyNameOrdinal = reader.GetOrdinal("client.companyName");
                            var clientCompanyName = reader.IsDBNull(clientCompanyNameOrdinal) ? null : reader.GetString(clientCompanyNameOrdinal);

                            var clientContactEmailOrdinal = reader.GetOrdinal("client.contactEmail");
                            var clientContactEmail = reader.IsDBNull(clientContactEmailOrdinal) ? null : reader.GetString(clientContactEmailOrdinal);

                            var clientBusinessEmailOrdinal = reader.GetOrdinal("client.businessEmail");
                            var clientBusinessEmail = reader.IsDBNull(clientBusinessEmailOrdinal) ? null : reader.GetString(clientBusinessEmailOrdinal);

                            var client = new Client(clientId, clientUsername, clientPassword, clientEmail, clientPhone, clientSalt, clientCompanyName, clientContactEmail, clientBusinessEmail);

                            
                            clients.Add(client);
                        }
                    }
                }
            }

            Contract contract = new Contract(contractId, clients, song);

            return contract;
        }
    }
}