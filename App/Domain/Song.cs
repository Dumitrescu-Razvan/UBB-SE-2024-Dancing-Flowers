
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Song : Playable {
    
    public String Artist;

    public String Album;

    public int Likes;

    public int Shares;

    public int Saves;
    
    public List<String> Restrictions;
    


    public Song() : base() {
        // call the constructor of the parent class
        this.Artist = "";
        this.Album = "";
        this.Likes = 0;
        this.Shares = 0;
        this.Saves = 0;
        this.Restrictions = new List<String>();

    }

    public Song(String artist, String albumList, List<String> restrictions, int duration) : base(duration) {
        // call the constructor of the parent class
        this.Artist = artist;
        this.Album = albumList;
        this.Likes = 0;
        this.Shares = 0;
        this.Saves = 0;
        this.Restrictions = restrictions;
    }
    
    

    

    /// <summary>
    /// @return
    /// </summary>
    public void Like() {
        this.Likes++;
    }

    /// <summary>
    /// @return
    /// </summary>
    public void Share() {
        this.Shares++;
    }

    /// <summary>
    /// @return
    /// </summary>
    public void Save() {
        this.Saves++;
    }

}