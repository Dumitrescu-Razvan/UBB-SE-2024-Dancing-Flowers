using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain;
using System.Data;
using Microsoft.Data.SqlClient;

namespace App.Repository
{
    public class SongRepository : EntityRepository<Song>
    {
        public SongRepository(string connectionString) : base(connectionString)
        {
            
        }

        public override Song getById(int id)
        {
            var query = "SELECT * FROM Songs WHERE id = @id";
            var parameters = new SqlParameter[] { new SqlParameter("@id", id) };
            return ExecuteQuery(query, SongMapper, parameters).FirstOrDefault();
        }

        public override List<Song> getAll()
        {
            var query = "SELECT * FROM Songs";
            return ExecuteQuery(query, SongMapper);
        }

        public override bool Add(Song song)
        {
            var query = "INSERT INTO Songs (title, artist, album,likes,shares,saves,restrictions) VALUES ( @title, @artist, @album, @likes, @shares, @saves, @restrictions)";
            var parameters = new SqlParameter[]
            {
                //new SqlParameter("@id", song.id),
                new SqlParameter("@title", song.title),
                new SqlParameter("@artist", song.artist),
                new SqlParameter("@album", song.album),
                new SqlParameter("@restrictions", string.Join(";", song.restrictions)),
                new SqlParameter("@duration", song.duration),
                new SqlParameter("@timesPlayed", song.timesPlayed),
                new SqlParameter("@likes", song.likes),
                new SqlParameter("@shares", song.shares),
                new SqlParameter("@saves", song.saves),
            };

            return ExecuteNonQuery(query, parameters);
        }

        public override bool Update(Song song)
        {
            var query = "UPDATE Songs SET title = @title, artist = @artist, album = @album, restrictions = @restrictions, duration = @duration, timesPlayed = @timesPlayed, likes = @likes, shares = @shares, saves = @saves WHERE Id = @Id";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", song.id),
                new SqlParameter("@title", song.title),
                new SqlParameter("@artist", song.artist),
                new SqlParameter("@album", song.album),
                new SqlParameter("@restrictions", string.Join(";", song.restrictions)),
                new SqlParameter("@duration", song.duration),
                new SqlParameter("@timesPlayed", song.timesPlayed),
                new SqlParameter("@likes", song.likes),
                new SqlParameter("@shares", song.shares),
                new SqlParameter("@saves", song.saves),
            };

            return ExecuteNonQuery(query, parameters);
        }

        public override bool Delete(Song song)
        {
            var query = "DELETE FROM Songs WHERE Id = @Id";
            var parameters = new SqlParameter[] { new SqlParameter("@Id", song.id) };
            return ExecuteNonQuery(query, parameters);
        }


        public static Song SongMapper(IDataReader reader)
        {
            var id = (int)reader["Id"];

            int titleOrdinal = reader.GetOrdinal("title");
            var title = reader.IsDBNull(titleOrdinal) ? string.Empty : reader.GetString(titleOrdinal);

            int artistOrdinal = reader.GetOrdinal("artist");
            var artist = reader.IsDBNull(artistOrdinal) ? string.Empty : reader.GetString(artistOrdinal);

            int albumOrdinal = reader.GetOrdinal("album");
            var album = reader.IsDBNull(albumOrdinal) ? string.Empty : reader.GetString(albumOrdinal);

            int restrictionsOrdinal = reader.GetOrdinal("restrictions");
            var restrictionsString = reader.IsDBNull(restrictionsOrdinal) ? null : reader.GetString(restrictionsOrdinal);
            var restrictions = Song.getRestrictionsFromString(restrictionsString);

            int durationOrdinal = reader.GetOrdinal("duration");
            var duration = reader.IsDBNull(durationOrdinal) ? 0 : reader.GetInt32(durationOrdinal);

            int timesPlayedOrdinal = reader.GetOrdinal("timesPlayed");
            var timesPlayed = reader.IsDBNull(timesPlayedOrdinal) ? 0 : reader.GetInt32(timesPlayedOrdinal);

            int likesOrdinal = reader.GetOrdinal("likes");
            var likes = reader.IsDBNull(likesOrdinal) ? 0 : reader.GetInt32(likesOrdinal);

            int sharesOrdinal = reader.GetOrdinal("shares");
            var shares = reader.IsDBNull(sharesOrdinal) ? 0 : reader.GetInt32(sharesOrdinal);

            int savesOrdinal = reader.GetOrdinal("saves");
            var saves = reader.IsDBNull(savesOrdinal) ? 0 : reader.GetInt32(savesOrdinal);


            return new Song(id, title, artist, album, restrictions, duration, timesPlayed, likes, shares, saves);
        }

    }

    
}
