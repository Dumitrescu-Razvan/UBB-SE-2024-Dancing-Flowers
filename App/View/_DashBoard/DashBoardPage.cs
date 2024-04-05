
namespace ISSProject
{
    public partial class DashBoardPage : ContentPage
    {
        public DashBoardPage()
        {
            InitializeComponent();

            MockDataForLabels();
            MockDataForArtistsListView();
        }

        private void BuyAds_Clicked(object sender, EventArgs e)
        {
            // Handle Buy More Ads button click
        }

        private void TakeDown_Clicked(object sender, EventArgs e)
        {
            // Handle Take Down Request button click
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle search text change event
        }

        private void ArtistsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Handle artist list item selection
        }

        private void MockDataForLabels()
        {
            // Mock data for Revenue from Ads
            revenueLabel.Text = "$1000";

            // Mock data for Monthly Streams
            streamsLabel.Text = "5000";

            // Mock data for Copyright Claims
            claimsLabel.Text = "5";
        }
        private void MockDataForArtistsListView()
        {
            // Sample data for artists
            List<string> artists = new List<string> { "Artist A", "Artist B", "Artist C" };

            // Set the ItemsSource of artistsListView
            artistsListView.ItemsSource = artists;
        }

    }
}
