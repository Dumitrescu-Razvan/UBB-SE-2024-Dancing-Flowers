namespace App.Domain
{
    public class Ad : Playable
    {
        public int Clicks { get; set; } = new int();
        public Ad() : base()
        {
            this.Clicks = 0;
        }

        public Ad(int id, int duration, int timesPlayed, int clicks) : base(id, duration, timesPlayed)
        {
            /*
             * new constructor for Ad which takes in id, duration and timesPlayed as well for base class
             */
            this.Clicks = clicks;
        }
        public void Clicked()
        {
            this.Clicks++;
        }
        public void Skip()
        {
        }
    }
}