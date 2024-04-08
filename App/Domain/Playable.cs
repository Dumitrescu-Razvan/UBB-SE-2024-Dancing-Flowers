namespace App.Domain
{
    public abstract class Playable
    {
        public int id { get; set; } = new int();
        public int Duration { get; set; } = new int();
        public int TimesPlayed { get; set; } = new int();
        protected Playable()
        {
            this.Duration = 0;
            this.TimesPlayed = 0;
            this.id = 0;
        }
        protected Playable(int id, int duration, int timesPlayed)
        {
            /*
             * 
             * Added another constructor which as id and times played as well as id now
             * id is also int rather than guid
             *
             */
            this.id = id;
            this.Duration = duration;
            this.TimesPlayed = timesPlayed;
        }
        public void Play()
        {
            this.TimesPlayed++;
        }
        public void Pause()
        {
        }
        public void Stop()
        {
        }
    }
}