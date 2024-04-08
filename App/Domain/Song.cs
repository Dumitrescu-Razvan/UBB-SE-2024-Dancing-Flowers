namespace App.Domain
{
    public class Song : Playable
    {
        public String Artist { get; set; }
        public String Album { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }
        public int Saves { get; set; }
        public ? List<String> Restrictions { get; set; }

        public Song(int id, string artist, string album, List<String> restrictions, int duration, int timesPlayed) : base(id, duration, timesPlayed)
        {
            // old constructor, modified for base class. still missing parameters get initialised with 0
            // may be useful for new songs added to the db 
            Artist = artist;
            Album = album;
            Likes = 0;
            Shares = 0;
            Saves = 0;
            Restrictions = restrictions;
        }

        public Song(int id, string artist, string album, List<string> restrictions, int duration, int timesPlayed, int likes, int shares, int saves) : base(id, duration, timesPlayed)
        {
            /*
             * new constructor that has the other parameters, 
             * also the base constructor now has all the parameters it needs
             */
            Artist = artist;
            Album = album;
            Likes = likes;
            Shares = shares;
            Saves = saves;
            Restrictions = restrictions;
        }

        public void Like()
        {
            Likes++;
        }
        public void Share()
        {
            Shares++;
        }
        public void Save()
        {
            Saves++;
        }
    }

}