using App.Repository;
using App.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace App.Repository
{
	public class ClientRepository : EntityRepository<Client>
	{
		// id, username, password, phone, zone, salt, companyName, contactEmail, businessEmail,

		public ClientRepository(string connectionString) : base(connectionString)
		{
		}

		public override Client getById(int id)
		{
			var query = "SELECT * FROM Clients WHERE Id = @Id";
			var parameters = new SqlParameter[] { new SqlParameter("@Id", id) };
			return ExecuteQuery(query, ClientMapper, parameters).FirstOrDefault();
		}

		public override List<Client> getAll()
		{
			var query = "SELECT * FROM Clients";
			return ExecuteQuery(query, ClientMapper, null);
		}

		public override bool Add(Client client)
		{
			var query = "INSERT INTO Clients (id, username, password, email, phone, salt, companyName, contactEmail, businessEmail) VALUES (@id, @username, @password, @email, @phone, @salt, @companyName, @contactEmail, @businessEmail)";

            var parameters = new SqlParameter[]
			{
				new SqlParameter("@id", client.id),
				new SqlParameter("@username", client.username),
				new SqlParameter("@password", client.passwordHash),
				new SqlParameter("@email", client.email),
				new SqlParameter("@phone", client.phone),
				new SqlParameter("@salt", client.salt),
				new SqlParameter("@companyName", client.companyName),
				new SqlParameter("@contactEmail", client.contactEmail),
				new SqlParameter("@businessEmail", client.businessEmail),
			};

			return ExecuteNonQuery(query, parameters);
		}

		public override bool Update(Client client)
		{
			var query = "UPDATE Clients SET username = @username, password = @password, email = @email , phone = @phone, salt = @salt, companyName = @companyName, contactEmail = @contactEmail, businessEmail = @businessEmail WHERE Id = @Id";
			var parameters = new SqlParameter[]
			{
				new SqlParameter("@Id", client.id),
				new SqlParameter("@username", client.username),
				new SqlParameter("@password", client.passwordHash),
				new SqlParameter("@email", client.email),
				new SqlParameter("@phone", client.phone),
				new SqlParameter("@salt", client.salt),
				new SqlParameter("@companyName", client.companyName),
				new SqlParameter("@contactEmail", client.contactEmail),
				new SqlParameter("@businessEmail", client.businessEmail),
			};

			return ExecuteNonQuery(query, parameters);
		}

		public override bool Delete(Client client)
		{
			var query = "DELETE FROM Clients WHERE Id = @Id";
			var parameters = new SqlParameter[] { new SqlParameter("@Id", client.id) };
			return ExecuteNonQuery(query, parameters);
		}

		public static Client ClientMapper(IDataReader reader)
		{

			var id = reader.GetInt32(reader.GetOrdinal("Id"));

			int usernameOrdinal = reader.GetOrdinal("name");
			var username = reader.IsDBNull(usernameOrdinal) ? null : reader.GetString(usernameOrdinal);

			int passwordOrdinal = reader.GetOrdinal("password");
			var password = reader.IsDBNull(passwordOrdinal) ? null : reader.GetString(passwordOrdinal);

			int emailOrdinal = reader.GetOrdinal("email");
			var email = reader.IsDBNull(emailOrdinal) ? null : reader.GetString(emailOrdinal);

			int phoneOrdinal = reader.GetOrdinal("phone");
			var phone = reader.IsDBNull(phoneOrdinal) ? null : reader.GetString(phoneOrdinal);

			int saltOrdinal = reader.GetOrdinal("salt");
			var salt = reader.IsDBNull(saltOrdinal) ? null : reader.GetString(saltOrdinal);

			int companyNameOrdinal = reader.GetOrdinal("companyName");
			var companyName = reader.IsDBNull(companyNameOrdinal) ? null : reader.GetString(companyNameOrdinal);

			int contactEmailOrdinal = reader.GetOrdinal("contactEmail");
			var contactEmail = reader.IsDBNull(contactEmailOrdinal) ? null : reader.GetString(contactEmailOrdinal);

			int businessEmailOrdinal = reader.GetOrdinal("businessEmail");
			var businessEmail = reader.IsDBNull(businessEmailOrdinal) ? null : reader.GetString(businessEmailOrdinal);

			Client client = new Client(id, username, password, email, phone, salt, companyName, contactEmail, businessEmail);

			return client;
		}
	}
}