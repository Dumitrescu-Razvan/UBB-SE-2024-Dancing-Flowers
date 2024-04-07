namespace App.Domain
{
    public class User : Account
    {
        protected private string location { get; set; } = new string();
        protected private int age { get; set; } = new int();
        protected private string subscriptionTier { get; set; } = new string();
        protected private List<Playlist> playlists { get; set; } = new List<Playlist>();
        protected private bool isAdmin { get; set; } = new bool();

        public User(string username, string password, string email, string phone, string zone, string salt, string location, int age, string subscriptionTier, Guid guid) : base(username, password, email, phone, zone, salt, guid)
        {
            this.location = location;
            this.age = age;
            this.subscriptionTier = subscriptionTier;
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