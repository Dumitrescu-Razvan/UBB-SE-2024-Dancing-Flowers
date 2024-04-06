using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using App.Repository.EntityRepository;
using App.Domain.Playlist

namespace App.Repository 
{
    public class PlaylistRepository: EntityRepository<Playlist>
    {
        public PlaylistRepository(string connectionString) : base(connectionString)
        {
        }

        private Playlist map(IDataReader reader)
        {
            Playlist playlist = new Playlist(reader["Name"].ToString());

            return playlist;
        }

        public override Playlist getById(int id)
        {
            string query = "SELECT * FROM Playlist WHERE Id = @Id";
            SqlParameter parameter = new SqlParameter("@Id", id);
            
            return ExecuteQuery(query, map, parameter).FirstOrDefault();
        }

        public override List<Playlist> getAll()
        {
            string query = "SELECT * FROM Playlist";
            
            return ExecuteQuery(query, map);
        }

        public override bool add(Playlist playlist)
        {
            string query = "INSERT INTO Playlist (Name) VALUES (@Name)";
            SqlParameter parameter = new SqlParameter("@Name", playlist.Name);
            
            return ExecuteNonQuery(query, parameter);
        }
        
        public override bool delete(Playlist playlist)
        {
            
        }

        public override bool update(Playlist playlist)
        {
                
        }

        public bool addSong(Guid playlistId, Guid songId)
        {
            string query = "INSERT INTO PlaylistSong (PlaylistId, SongId) VALUES (@PlaylistId, @SongId)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PlaylistId", playlistId),
                new SqlParameter("@SongId", songId)
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool removeSong(Guid playlistId)
        {
            string query = "DELETE FROM PlaylistSong WHERE PlaylistId = @PlaylistId AND SongId = @SongId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PlaylistId", playlistId),
                new SqlParameter("@SongId", songId)
            };

            return ExecuteNonQuery(query, parameters);
        }
    }
}