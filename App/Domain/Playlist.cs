namespace App.Domain{
    public class Playlist{
        private List<Song> songs{get; set;} = new List<Song>();
        public String Name { get; set; }
        public Playlist(string name) => Name = name;
        
        public bool addSong(Song song) {
            this.songs.Add(song);
            return true;
        }

        public bool removeSong(Guid songId) {
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

