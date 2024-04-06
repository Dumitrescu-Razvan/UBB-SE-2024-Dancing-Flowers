
namespace App.Domain{
    public abstract class Playable{
        public Guid Id { get; set; }
        public int Duration { get; set; }
        public int TimesPlayed { get; set; }
        protected Playable(){
            this.Duration = 0;
            this.TimesPlayed = 0;
            this.Id = Guid.NewGuid();
        }
        protected Playable(int duration){
            this.Duration = duration;
            this.TimesPlayed = 0;
            this.Id = Guid.NewGuid();
        }
        public void Play(){
            this.TimesPlayed++;
        }
        public void Pause(){
        }
        public void Stop(){
        }
    }
}