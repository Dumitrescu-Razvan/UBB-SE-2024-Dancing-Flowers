
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Ad : Playable {

    public Ad() : base() {
        this.Clicks = 0;
    }

    public int Clicks;
    
    /// <summary>
    /// @return
    /// </summary>
    public void Clicked() {
        this.Clicks++;
    }

    public void Skip() {
        // TODO implement here
    }

}