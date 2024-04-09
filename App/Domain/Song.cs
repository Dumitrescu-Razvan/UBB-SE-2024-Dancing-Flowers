using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace App.Domain
{
    public class Song : Playable
    {
        private string title { get; set; } = string.Empty;
        private string artist { get; set; } = string.Empty;
        private string album { get; set; } = string.Empty;
        private int likes { get; set; }
        private int shares { get; set; }
        private int saves { get; set; }
        private List<String> restrictions { get; set; }

        public Song(string title, string artist, string album, List<String> restrictions, int duration) : base()
        {
            this.title = title;
            this.artist = artist;
            this.album = album;
            this.duration = duration;
            this.likes = 0;
            this.shares = 0;
            this.saves = 0;
            this.restrictions = restrictions;
        }

        public Song(int id,string title, string artist, string album, List<string> restrictions, int duration, int timesPlayed, int likes, int shares, int saves) :
            base(id, duration, timesPlayed)
        {
            this.title = title;
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

        public static List<String> getRestrictionsFromString(string text)
        {
            if (text.EndsWith(";"))
            {
                text = text.Substring(0, text.Length - 1);
            }

            List<string> restrictions = new List<string>(text.Split(';'));

            return restrictions;
        }

    }

}