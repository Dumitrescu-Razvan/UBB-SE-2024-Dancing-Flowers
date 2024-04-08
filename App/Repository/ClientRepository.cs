using App.Repository.EntityRepository;
using App.Domain.Client;

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
			Client user = new Client();

			user.Id = reader.GetInt32(reader.GetOrdinal("Id"));

			int nameOrdinal = reader.GetOrdinal("name");
			client.username = reader.IsDBNull(usernameOrdinal) ? null : reader.GetString(usernameOrdinal);

			int passwordOrdinal = reader.GetOrdinal("password");
			client.password = reader.IsDBNull(passwordOrdinal) ? null : reader.GetString(passwordOrdinal);

			int emailOrdinal = reader.GetOrdinal("email");
			client.email = reader.IsDBNull(emailOrdinal) ? null : reader.GetString(emailOrdinal);

			int phoneOrdinal = reader.GetOrdinal("phone");
			client.phone = reader.IsDBNull(phoneOrdinal) ? null : reader.GetString(phoneOrdinal);

			int zoneOrdinal = reader.GetOrdinal("zone");
			client.zone = reader.IsDBNull(zoneOrdinal) ? null : reader.GetString(zoneOrdinal);

			int saltOrdinal = reader.GetOrdinal("salt");
			client.salt = reader.IsDBNull(saltOrdinal) ? null : reader.GetString(saltOrdinal);

			int comapnyNameOrdinal = reader.GetOrdinal("companyName");
			client.companyName = reader.IsDBNull(comapnyNameOrdinal) ? null : reader.GetString(comapnyNameOrdinal);

			int contactEmailOrdinal = reader.GetOrdinal("contactEmail");
			client.contactEmail = reader.IsDBNull(contactEmailOrdinal) ? null : reader.GetString(contactEmailOrdinal);

			int businessEmailOrdinal = reader.GetOrdinal("businessEmail");
			client.businessEmail = reader.IsDBNull(businessEmailOrdinal) ? null : reader.GetString(businessEmailOrdinal);


			return client;
		}
	}
}