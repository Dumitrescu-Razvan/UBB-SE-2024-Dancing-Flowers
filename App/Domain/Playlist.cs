namespace App.Domain
{
    public class Playlist
    {
        private List<Song> songs { get; set; } = new List<Song>();
        public String Name { get; set; } = new String();
        public Playlist(string name)
        {
            this.Name = name;
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