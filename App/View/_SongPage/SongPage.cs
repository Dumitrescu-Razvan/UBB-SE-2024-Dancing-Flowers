using System.Collections.ObjectModel;

namespace ISSProject
{
    public partial class SongPage : ContentPage
    {
        public ObservableCollection<string> Songs { get; } = new ObservableCollection<string>();

        // Property to track button clicks
        public bool IsClicked { get; set; }

        public SongPage()
        {
            InitializeComponent();

            // Set the BindingContext
            BindingContext = this;

            // Populate songs
            Songs.Add("Song 1");
            Songs.Add("Song 2");
            Songs.Add("Song 3");
        }

        // Event handler for button clicks
        private async void Clicked(object sender, EventArgs e)
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
