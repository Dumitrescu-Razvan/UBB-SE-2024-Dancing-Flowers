using System;

namespace App.Domain
{
    public class Ad : Playable
    {
        private int clicks { get; set; } = new int();

        public Ad() : base()
        {
            this.clicks = 0;
        }

        public Ad(int id, int duration, int timesPlayed, int clicks) : base(id, duration, timesPlayed)
        {
            this.clicks = clicks;
        }

        public void clicked()
        {
            this.clicks++;
        }

    }
}