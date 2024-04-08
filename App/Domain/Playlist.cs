using System;

namespace App.Domain
{
    public class Playlist
    {
        private int id { get; }
        private List<Song> songs { get; set; };
        private string name { get; set; } = new string();

        public Playlist(string name)
        {
            this.name = name;
        }

        public Playlist(int id, int name, List<Song> songs)
        {
            this.id = id;
            this.name = name;
            this.songs = songs;
        }

        public bool addSong(Song song)
        {
            this.songs.Add(song);
            return true;
        }

        public bool removeSong(int songId)
        {
            try
            {
                this.songs.Remove(this.songs.Find(song => song.Id == songId));
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

    }

}