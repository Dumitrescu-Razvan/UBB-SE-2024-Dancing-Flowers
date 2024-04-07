namespace App.Domain {
    public class Ad : Playable {
        public int Clicks{get;set;} = new int();
        public Ad() : base() {
            this.Clicks = 0;
        }
        public void Clicked() {
            this.Clicks++;
        }
        public void Skip() {
        }
    }
}
