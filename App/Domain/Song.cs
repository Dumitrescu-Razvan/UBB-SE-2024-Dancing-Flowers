namespace App.Domain{
    public class Song : Playable{
        public String Artist { get; set; }
        public String Album { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }
        public int Saves { get; set; }
        public ?List<String> Restrictions { get; set; }
        public Song(string artist, string album, List<String> restrictions, int duration) : base(duration){
            Artist = artist;
            Album = album;
            Likes = 0;
            Shares = 0;
            Saves = 0;
            Restrictions = restrictions;
        }
        public void Like(){
            Likes++;
        }
        public void Share(){
            Shares++;
        }
        public void Save(){
            Saves++;
        }
    }

}
