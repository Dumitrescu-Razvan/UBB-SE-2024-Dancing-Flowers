namespace ISSProject
{
    public partial class SongDetailsPage : ContentPage
    {
        
        private string? _selectedSong;

        public string? SelectedSong
        {
            get { return _selectedSong; }
            set
            {
                if (_selectedSong != value)
                {
                    _selectedSong = value;
                    OnPropertyChanged(nameof(SelectedSong));
                }
            }
        }

        public SongDetailsPage(string selectedSong)
        {
            InitializeComponent();
            BindingContext = this;
            SelectedSong = selectedSong;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
