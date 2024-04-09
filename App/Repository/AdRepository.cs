using System;
using App.Domain.Ad;

namespace App.Repository
{
    public class AdRepository : EntityRepository<Ad>
    {
        public AdRepository(string connectionString) : base(connectionString)
        {

        }

        public override Ad getById(int id)
        {
            var query = "SELECT * FROM Ads WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", id) };
            return ExecuteQuery(query, AdMapper, parameters).FirstOrDefault();
        }

        public override List<Ad> getAll()
        {
            var query = "SELECT * FROM Ads";
            return ExecuteQuery(query, AdMapper);
        }

        public override bool Add(Ad ad)
        {
            var query = "INSERT INTO Ads (id, duration, timesPlayed, clicks) VALUES (@id, @duration, @timesPlayed, @clicks)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@id", ad.Id),
                new SqlParameter("@duration", ad.duration),
                new SqlParameter("@timesPlayed", ad.timesPlayed),
                new SqlParameter("@clicks", ad.clicks),
            };

            return ExecuteNonQuery(query, parameters);
        }

        public override bool Update(Ad ad)
        {
            var query = "UPDATE Ads SET duration = @duration, timesPlayed = @timesPlayed, clicks = @clicks WHERE Id = @Id";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", ad.Id),
                new SqlParameter("@duration", ad.duration),
                new SqlParameter("@timesPlayed", ad.timesPlayed),
                new SqlParameter("@clicks", ad.clicks),
            };

            return ExecuteNonQuery(query, parameters);
        }

        public override bool Delete(int id)
        {
            var query = "DELETE FROM Ads WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", id) };
            return ExecuteNonQuery(query, parameters);
        }

        private Ad AdMapper(SqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("id"));

            int duration = GetStringOrNull("duration");
            int timesPlayed = GetStringOrNull("timesPlayed");
            int clicks = GetStringOrNull("clicks");

            return new Ad(id, duration, timesPlayed, clicks);
        }
    }
}