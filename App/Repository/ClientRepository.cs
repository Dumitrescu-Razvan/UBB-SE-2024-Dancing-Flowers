using System;
using App.Repository.EntityRepository;
using App.Domain.Client;

namespace App.Repository
{
	public class ClientRepository : EntityRepository<Client>
	{
		

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
			return ExecuteQuery(query, ClientMapper);
		}

		public override bool Add(Client client)
		{
			var query = "INSERT INTO Clients (id, username, password, phone, zone, salt, companyName, contactEmail, businessEmail) VALUES (@id, @username, @password, @phone, @zone, @salt, @companyName, @contactEmail, @businessEmail)";
			var parameters = new SqlParameter[]
			{
				new SqlParameter("@id", client.Id),
				new SqlParameter("@username", client.username),
				new SqlParameter("@password", client.password),
				new SqlParameter("@email", client.email),
				new SqlParameter("@phone", client.phone),
				new SqlParameter("@zone", client.zone),
				new SqlParameter("@salt", client.salt),
				new SqlParameter("@companyName", client.companyName),
				new SqlParameter("@contactEmail", client.contactEmail),
				new SqlParameter("@businessEmail", client.businessEmail),
			};

			return ExecuteNonQuery(query, parameters);
		}

		public override bool Update(Client client)
		{
			var query = "UPDATE Clients SET username = @username, password = @password, phone = @phone, zone = @zone, salt = @salt, companyName = @companyName, contactEmail = @contactEmail, businessEmail = @businessEmail WHERE Id = @Id";
			var parameters = new SqlParameter[]
			{
				new SqlParameter("@Id", client.Id),
				new SqlParameter("@username", client.username),
				new SqlParameter("@password", client.password),
				new SqlParameter("@email", client.email),
				new SqlParameter("@phone", client.phone),
				new SqlParameter("@zone", client.zone),
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
			var parameters = new SqlParameter[] { new SqlParameter("@Id", client.Id) };
			return ExecuteNonQuery(query, parameters);
		}

		public static Client ClientMapper(IDataReader reader)
		{
			int id = (int)reader["id"];

			string username = GetStringOrNull(reader, "username");
			string password = GetStringOrNull(reader, "password");
			string email = GetStringOrNull(reader, "email");
			string phone = GetStringOrNull(reader, "phone");
			string zone = GetStringOrNull(reader, "zone");
			string salt = GetStringOrNull(reader, "salt");
			string companyName = GetStringOrNull(reader, "companyName");
			string contactEmail = GetStringOrNull(reader, "contactEmail");
			string businessEmail = GetStringOrNull(reader, "businessEmail");

			return new Client(id, username, password, email, phone, zone, salt, companyName, contactEmail, businessEmail);	
		}
	}
}