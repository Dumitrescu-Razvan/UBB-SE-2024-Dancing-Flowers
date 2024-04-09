using System;
using App.Repository;
using App.Domain.User;

namespace App.Repository
{
    public class UserRepository : EntityRepository<User>
    {

        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public override User getById(int id)
        {
            var query = "SELECT * FROM Users WHERE id = @id";
            var parameters = new SqlParameter[] { new SqlParameter("@id", id) };
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
                new SqlParameter("@id", user.id),
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
            var query = "UPDATE Users SET username = @username, password = @password, email = @email, phone = @phone, zone = @zone, salt = @salt, location = @location, age = @age, subscriptionTier = @subscriptionTier WHERE id = @id";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@id", user.id),
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
            var query = "DELETE FROM Users WHERE id = @id";
            var parameters = new SqlParameter[] { new SqlParameter("@id", user.id) };
            return ExecuteNonQuery(query, parameters);
        }

        public static User Mapper(IDataReader reader)
        {
            int id = (int)reader["id"];

            string username = GetStringOrNull(reader, "username");
            string password = GetStringOrNull(reader, "password");
            string email = GetStringOrNull(reader, "email");
            string phone = GetStringOrNull(reader, "phone");
            string zone = GetStringOrNull(reader, "zone");
            string salt = GetStringOrNull(reader, "salt");
            string location = GetStringOrNull(reader, "location");
            int age = (int)reader["age"];
            int subscriptionTier = (int)reader["subscriptionTier"];

            return new User(id, username, password, email, phone, zone, salt, location, age, subscriptionTier);
        }
    }
}