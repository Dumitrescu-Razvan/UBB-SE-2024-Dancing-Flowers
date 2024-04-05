namespace ISSProject
{
    public partial class SongDetailsPage : ContentPage
    {
        public string SelectedSong { get; set; }

        public SongDetailsPage(string selectedSong)
        {
            InitializeComponent();
            SelectedSong = selectedSong;
            BindingContext = this;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
