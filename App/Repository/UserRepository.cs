using App.Repository;
using App.Domain.User;

namespace App.Repository
{
    public class UserRepository : EntityRepository<User>
    {
        // string username, string password, string email, string phone, string zone, string salt, string location, int age, string subscriptionTier, Guid guid

        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public override User getById(int id)
        {
            var query = "SELECT * FROM Users WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", id) };
            return ExecuteQuery(query, UserMapper, parameters).FirstOrDefault();
        }

        public override List<User> getAll()
        {
            var query = "SELECT * FROM Users";
            return ExecuteQuery(query, UserMapper);
        }

        public override bool Add(User user)
        {
            var query = "INSERT INTO Users (id ,username, password, email, phone, zone, salt, location, age, subscribtionTier) VALUES (@id ,@username, @password, @email, @phone, @zone, @salt, @location, @age, @subscriptionTier)";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@id", user.Id),
                new SqlParameter("@username", user.username),
                new SqlParameter("@password", user.password),
                new SqlParameter("@email", user.email),
                new SqlParameter("@phone", user.phone),
                new SqlParameter("@zone", user.zone),
                new SqlParameter("@salt", user.salt),
                new SqlParameter("@location", user.location),
                new SqlParameter("@age", user.age),
                new SqlParameter("@subscriptionTier", user.subscriptionTier),
            };

            return ExecuteNonQuery(query, parameters);
        }

        public override bool Update(User user)
        {
            var query = "UPDATE Users SET username = @username, password = @password, email = @email, phone = @phone, zone = @zone, salt = @salt, location = @location, age = @age, subscriptionTier = @subscriptionTier WHERE Id = @Id";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", user.Id),
                new SqlParameter("@username", user.username),
                new SqlParameter("@password", user.password),
                new SqlParameter("@email", user.email),
                new SqlParameter("@phone", user.phone),
                new SqlParameter("@zone", user.zone),
                new SqlParameter("@salt", user.salt),
                new SqlParameter("@location", user.location),
                new SqlParameter("@age", user.age),
                new SqlParameter("@subscriptionTier", user.subscriptionTier),
            };

            return ExecuteNonQuery(query, parameters);
        }

        public override bool Delete(User user)
        {
            var query = "DELETE FROM Users WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", user.Id) };
            return ExecuteNonQuery(query, parameters);
        }

        public static User UserMapper(IDataReader reader)
        {
            User user = new User();

            user.Id = reader.GetInt32(reader.GetOrdinal("Id"));

            int usernameOrdinal = reader.GetOrdinal("username");
            user.username = reader.IsDBNull(usernameOrdinal) ? null : reader.GetString(usernameOrdinal);

            int passwordOrdinal = reader.GetOrdinal("password");
            user.password = reader.IsDBNull(passwordOrdinal) ? null : reader.GetString(passwordOrdinal);

            int emailOrdinal = reader.GetOrdinal("email");
            user.email = reader.IsDBNull(emailOrdinal) ? null : reader.GetString(emailOrdinal);

            int phoneOrdinal = reader.GetOrdinal("phone");
            user.phone = reader.IsDBNull(phoneOrdinal) ? null : reader.GetString(phoneOrdinal);

            int zoneOrdinal = reader.GetOrdinal("zone");
            user.zone = reader.IsDBNull(zoneOrdinal) ? null : reader.GetString(zoneOrdinal);

            int saltOrdinal = reader.GetOrdinal("salt");
            user.salt = reader.IsDBNull(saltOrdinal) ? null : reader.GetString(saltOrdinal);

            int locationOrdinal = reader.GetOrdinal("location");
            user.location = reader.IsDBNull(locationOrdinal) ? null : reader.GetString(locationOrdinal);

            int ageOrdinal = reader.GetOrdinal("age");
            user.age = reader.GetInt32(ageOrdinal);

            int subscriptionTierOrdinal = reader.GetOrdinal("subscriptionTier");
            user.subscriptionTier = reader.IsDBNull(subscriptionTierOrdinal) ? (int?)null : reader.GetInt32(subscriptionTierOrdinal);

            return user;
        }
    }
}