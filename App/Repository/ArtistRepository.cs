/*using App.Domain;
using App.Repository;
using ISS.App.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS.App.Repository
{
    internal class ArtistRepository : EntityRepository<Artist>
    {
        public ArtistRepository(string connection) : base(connection)
        {
        }

        public override Client getById(int id)
        {
            var query = "SELECT * FROM Artists WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", id) };
            return ExecuteQuery(query, ClientMapper, parameters).FirstOrDefault();
        }


    }
}
*/