using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using App.Service;

namespace ISSProject
{
    public partial class SongPage : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<string> Songs { get; set; }
        public ObservableCollection<string> TopThreeArtists { get; set; }

        public Service service = new Service();

        // Constructor
        public SongPage()
        {
            InitializeComponent();
            Songs = new ObservableCollection<string>();
            TopThreeArtists = new ObservableCollection<string>(); // Contains image URLs
            LoadSongs();
            LoadTopThreeArtists();
            BindingContext = this;
        }

        // Method to load sample songs (replace with your actual data source)
        private void LoadSongs()
        {
            Songs = service.GetSongs();
            Songs.CollectionChanged += Songs_CollectionChanged;
        }

        // Method to populate the TopThreeArtists list
        private void LoadTopThreeArtists()
        {
            // For demonstration purposes, assume these are image URLs
            TopThreeArtists.Add("https://i1.sndcdn.com/artworks-OVjQCFFE8TAvXrwA-NomMbQ-t500x500.jpg");
            TopThreeArtists.Add("https://i.scdn.co/image/ab6761610000e5eb1d8e3ecf59f556b8e4fafce8");
            TopThreeArtists.Add("https://i.scdn.co/image/ab6761610000e5eb4293385d324db8558179afd9");
        }

        // Method to dynamically update the top three artists
        private void UpdateTopThreeArtists()
        {
            // Update top three artists if needed (e.g., if artists are dynamic)
            // For demonstration, we're not updating here
        }

        // Event handler for the Songs collection changed
        private void Songs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Update top three artists if needed
        }

        // Event handler for the button clicked (to trigger update of top 3 artists)
        private void UpdateTopThreeButton_Clicked(object sender, EventArgs e)
        {
            UpdateTopThreeArtists();
        }

        // Implementation of INotifyPropertyChanged interface
        public new event PropertyChangedEventHandler? PropertyChanged;
        protected new void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Event handler for the button clicked (example)
        private async void SongInfo_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                // Extract song name from the button's BindingContext
                var songName = button.BindingContext as string;
                if (songName != null)
                {
                    // Display alert with song info
                    await Navigation.PushAsync(new SongDetailsPage(songName));
                }
            }
        }
    }
}
