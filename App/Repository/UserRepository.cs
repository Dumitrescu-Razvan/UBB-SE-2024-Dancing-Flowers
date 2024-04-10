using App.Repository;
using App.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace App.Repository
{
    public class UserRepository : EntityRepository<User>
    {
        // string username, string password, string email, string phone, string salt, string location, int age, string subscriptionTier

        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public override User getById(int id)
        {
            var query = "SELECT * FROM Users WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", id) };
            return ExecuteQuery(query, UserMapper, parameters).FirstOrDefault();
        }

        public User getByUsername(string username)
        {
            var query = "SELECT * FROM Users WHERE username = @username";
            var parameters = new SqlParameter[] { new SqlParameter("@username", username) };
            return ExecuteQuery(query, UserMapper, parameters).FirstOrDefault();
        }

        public override List<User> getAll()
        {
            var query = "SELECT * FROM Users";
            return ExecuteQuery(query, UserMapper);
        }

        public override bool Add(User user)
        {
            var query = "INSERT INTO Users (username, password, email, salt, location, age, subscriptionTier, isAdimn) VALUES (@username, @password, @email, @phone, @salt, @location, @age, @subscriptionTier, @isAdmin)";
            var parameters = new SqlParameter[]
            {
                //new SqlParameter("@id", user.id),
                new SqlParameter("@username", user.username),
                new SqlParameter("@password", user.passwordHash),
                new SqlParameter("@email", user.email),
                new SqlParameter("@salt", user.salt),
                new SqlParameter("@location", user.location),
                new SqlParameter("@age", user.age),
                new SqlParameter("@subscriptionTier", user.subscriptionTier),
                new SqlParameter("@isAdmin", user.isAdmin),
            };

            return ExecuteNonQuery(query, parameters);
        }

        public override bool Update(User user)
        {
            var query = "UPDATE Users SET username = @username, password = @password, email = @email, salt = @salt, location = @location, age = @age, subscriptionTier = @subscriptionTier WHERE Id = @Id";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@id", user.id),
                new SqlParameter("@username", user.username),
                new SqlParameter("@password", user.passwordHash),
                new SqlParameter("@email", user.email),
                new SqlParameter("@salt", user.salt),
                new SqlParameter("@location", user.location),
                new SqlParameter("@age", user.age),
                new SqlParameter("@subscriptionTier", user.subscriptionTier),
                new SqlParameter("@isAdmin", user.isAdmin)
            };

            return ExecuteNonQuery(query, parameters);
        }

        public override bool Delete(User user)
        {
            var query = "DELETE FROM Users WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", user.id) };
            return ExecuteNonQuery(query, parameters);
        }

        public static User UserMapper(IDataReader reader)
        {

            var id = reader.GetInt32(reader.GetOrdinal("Id"));

            int usernameOrdinal = reader.GetOrdinal("username");
            var username = reader.IsDBNull(usernameOrdinal) ? null : reader.GetString(usernameOrdinal);

            int passwordOrdinal = reader.GetOrdinal("password");
            var password = reader.IsDBNull(passwordOrdinal) ? null : reader.GetString(passwordOrdinal);

            int emailOrdinal = reader.GetOrdinal("email");
            var email = reader.IsDBNull(emailOrdinal) ? null : reader.GetString(emailOrdinal);

            int saltOrdinal = reader.GetOrdinal("salt");
            var salt = reader.IsDBNull(saltOrdinal) ? null : reader.GetString(saltOrdinal);

            int locationOrdinal = reader.GetOrdinal("location");
            var location = reader.IsDBNull(locationOrdinal) ? null : reader.GetString(locationOrdinal);

            int ageOrdinal = reader.GetOrdinal("age");
            var age = reader.GetInt32(ageOrdinal);

            int subscriptionTierOrdinal = reader.GetOrdinal("subscriptionTier");
            var subscriptionTier = reader.IsDBNull(subscriptionTierOrdinal) ? null : reader.GetString(subscriptionTierOrdinal);

            int isAdminOrdinal = reader.GetOrdinal("isAdmin");
            var isAdmin = reader.GetBoolean(isAdminOrdinal);

            var user = new User(id, username, password, email, salt, location, age, subscriptionTier, isAdmin);

            return user;
        }
    }
}