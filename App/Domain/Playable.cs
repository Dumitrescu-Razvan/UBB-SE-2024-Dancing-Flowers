
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Playable {
    
    public Guid Id { get; private set; }    
    
    public int Duration;

    public int TimesPlayed;

    protected Playable() {
        this.Duration = 0;
        this.TimesPlayed = 0;
        this.Id = Guid.NewGuid();
    }
    
    protected Playable(int duration) {
        this.Duration = duration;
        this.TimesPlayed = 0;
        this.Id = Guid.NewGuid();
    }

    
    public void Play() {
        this.TimesPlayed++;
    }

    public void Pause() {
        // TODO implement here
    }

    public void Stop() {
        // TODO implement here
    }

}