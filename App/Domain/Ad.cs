public class Ad : Playable {
    public int Clicks;
    public Ad() : base() {
        this.Clicks = 0;
    }
    public void Clicked() {
        this.Clicks++;
    }
    public void Skip() {
    }

}