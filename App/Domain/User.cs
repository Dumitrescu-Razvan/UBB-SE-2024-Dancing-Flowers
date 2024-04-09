using System;
using System.Collections.Generic;

namespace App.Domain
{
    public class User : Account
    {
        public string location { get; set; } = string.Empty;
        public int age { get; set; } = new int();
        public string subscriptionTier { get; set; } = string.Empty;
        public List<Playlist> playlists { get; set; } = new List<Playlist>();
        public bool isAdmin { get; set; } = new bool();

        public User(int id, string username, string password, string email, string salt, string location, int age, string subscriptionTier, bool isAdmin) : 
            base(id,username,password,email,salt)
        {
            this.location = location;
            this.age = age;
            this.subscriptionTier = subscriptionTier;
            this.isAdmin = isAdmin;
        }

        public void purchaseSubscription(string subscriptionTier)
        {
            /*
             * @param subscriptionTier: string
             * @return bool
             *
             * Method to purchase a subscription
             * Changes the subscription tier
             *
             * Returns true if the subscription is purchased successfully, else false
             */

            this.subscriptionTier = subscriptionTier;
        }

        public void cancelSubscription()
        {
            /*
             * Method to cancel a subscription
             * Changes the subscription tier to null
             *
             * Returns true if the subscription is canceled successfully, else false
             */

            this.subscriptionTier = null;
        }

        public void createPlaylist(Playlist playlist)
        {
            /*
             * @param playlist: Playlist
             * @return bool
             *
             * Method to create a playlist
             * Adds the playlist to the list of playlists
             *
             * Returns true if the playlist is created successfully, else false
             */
            playlists.Add(playlist);
        }

        public void deletePlaylist(Playlist playlist)
        {
            /*
             * @param playlist: Playlist
             * @return bool
             *
             * Method to delete a playlist
             * Removes the playlist from the list of playlists
             *
             * Returns true if the playlist is deleted successfully, else false
             */
            playlists.Remove(playlist);
        }
    }
}