using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Playlist {
    
    private List<Song> songs{get;} = new List<Song>();
    public String Name { get; }
    public Playlist(string name) => Name = name;
    
    public bool addSong(Song song) {
        this.songs.Add(song);
        return true;
    }

    public bool removeSong(Guid songId) {
        try
        {
            this.songs.Remove(this.songs.Find(song => song.Id == songId));
        }
        catch (Exception e)
        {
            return false;
        }
        
        return true;
    }

}