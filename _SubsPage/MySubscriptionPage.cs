using System;

namespace ISSProject
{
    public partial class MySubscriptionPage : ContentPage
    {

        private bool _isSubscriptionSelected;
        public bool IsSubscriptionSelected
        {
            get { return _isSubscriptionSelected; }
            set
            {
                if (_isSubscriptionSelected != value)
                {
                    _isSubscriptionSelected = value;
                    OnPropertyChanged(nameof(IsSubscriptionSelected));
                }
            }
        }
        private string _currentSubscription = new string("");
        public string CurrentSubscription
        {
            get { return _currentSubscription; }
            set
            {
                if (_currentSubscription != value)
                {
                    _currentSubscription = value;
                    OnPropertyChanged(nameof(CurrentSubscription));
                }
            }
        
        }
        private string[] _subscriptionDescriptions = {
            "For only 1$/month you get:\n- fewer ads\n- shorter ads\n- maximum of 5 playlists (compared to 3 default)\n- better audio (128 kbps AAC)",
            "Maximum of one ad/hour\nUnlimited playlists\nBetter audio 182kbps AAC",
            "No ads\nBetter audio (320kbds)\nOffline support for up to 182 kbps AAC",
            "Best audio (FLAC)\nOffline support for every bitrate, including FLAC"
        };

        private int _selectedTierIndex = 0; // Default to Bronze

        public MySubscriptionPage()
        {
            InitializeComponent();
            BindingContext = this; // Set the BindingContext to this page
            //<Label Text="{Binding CurrentSubscription}" FontSize="Medium"/>    
            //get the current subscription from the database
            CurrentSubscription = "Bronze";

        }

        private void PickerSubscription_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = pickerSubscription.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < _subscriptionDescriptions.Length)
            {
                descriptionLabel.Text = _subscriptionDescriptions[selectedIndex]; // Set description based on selected index
                _selectedTierIndex = selectedIndex; // Update selected tier index
                UpdateIsSubscriptionSelected();
            }
        }

        private void PayButton_Clicked(object sender, EventArgs e)
        {
            //It goes to PaymentPage and gets the selected subscription tier
            Navigation.PushAsync(new PaymentPage(GetSelectedTier()));
        }

        private void UpdateIsSubscriptionSelected()
        {
            IsSubscriptionSelected = _selectedTierIndex >= 0;
        }

        private string GetSelectedTier()
        {
                return pickerSubscription.SelectedItem.ToString();
        }
    }
}
