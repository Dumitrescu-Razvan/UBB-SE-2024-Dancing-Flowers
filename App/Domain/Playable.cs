using System;

namespace App.Domain
{
    public abstract class Playable
    {
        public int id { get; } = new int();
        public int duration { get; set; } = new int();
        public int timesPlayed { get; set; } = new int();

        protected Playable()
        {
            this.duration = 0;
            this.timesPlayed = 0;
        }

        protected Playable(int id, int duration, int timesPlayed)
        {
            this.id = id;
            this.duration = duration;
            this.timesPlayed = timesPlayed;
        }

        public void play()
        {
            this.timesPlayed++;
        }
    }
}