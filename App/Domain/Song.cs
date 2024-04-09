using System;
using System.Collections.Generic;

namespace App.Domain
{
    public class Song : Playable
    {
        private string artist { get; set; } = string.Empty;
        private string album { get; set; } = string.Empty;
        private int likes { get; set; }
        private int shares { get; set; }
        private int saves { get; set; }
        private List<String> restrictions { get; set; }

        public Song(string artist, string album, List<String> restrictions, int duration) : base()
        {
            this.artist = artist;
            this.album = album;
            this.duration = duration;
            this.likes = 0;
            this.shares = 0;
            this.saves = 0;
            this.restrictions = restrictions;
        }

        public Song(int id, string artist, string album, List<string> restrictions, int duration, int timesPlayed, int likes, int shares, int saves) :
            base(id, duration, timesPlayed)
        {

            this.artist = artist;
            this.album = album;
            this.likes = likes;
            this.shares = shares;
            this.saves = saves;
            this.restrictions = restrictions;
        }

        public void like()
        {
            this.likes++;
        }
        public void share()
        {
            this.shares++;
        }
        public void save()
        {
            this.saves++;
        }


    }

}