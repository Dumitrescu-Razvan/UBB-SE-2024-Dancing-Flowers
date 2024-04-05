using System.ComponentModel;

namespace ISSProject
{
    public partial class MySubscriptionPage : ContentPage, INotifyPropertyChanged
    {
        private SubscriptionManager _subscriptionManager;
        public new event PropertyChangedEventHandler? PropertyChanged;
        // Bindable properties for channel name, description, and subscription status
        private string _channelName = "Music Channel";
        public string ChannelName
        {
            get { return _channelName; }
            set
            {
                if (_channelName != value)
                {
                    _channelName = value;
                    OnPropertyChanged(nameof(ChannelName));
                }
            }
        }

        private string _description = "Enjoy the latest music tracks!";
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private string ? _expirationText;
        public string ExpirationText
        {
            get { return _expirationText ?? string.Empty; }
            set
            {
                if (_expirationText != value)
                {
                    _expirationText = value;
                    OnPropertyChanged(nameof(ExpirationText));
                }
            }
        }

        private bool _isSubscribed;
        public bool IsSubscribed
        {
            get { return _isSubscribed; }
            set
            {
                if (_isSubscribed != value)
                {
                    _isSubscribed = value;
                    OnPropertyChanged(nameof(IsSubscribed));
                }
            }
        }

        public MySubscriptionPage(string subscriptionName)
        {
            InitializeComponent();
            ChannelName = subscriptionName;
            _subscriptionManager = new SubscriptionManager();

            // Initialize subscription manager

            // Set the data context to this page
            this.BindingContext = this;

            // Set initial subscription status
            IsSubscribed = _subscriptionManager.IsSubscribed;

            // Update UI
            UpdateExpirationLabel();
        }

        private void SubscribeButton_Clicked(object sender, EventArgs e)
        {
            // Call subscription method
            _subscriptionManager.Subscribe(ChannelName, this.Navigation);

            // Update IsSubscribed based on the subscription status
            IsSubscribed = _subscriptionManager.IsSubscribed;

            // Update UI
            UpdateExpirationLabel();
        }

        private void CancelSubscriptionButton_Clicked(object sender, EventArgs e)
        {
            // Call cancellation method
            _subscriptionManager.CancelSubscription();

            // Update UI
            UpdateExpirationLabel();
            IsSubscribed = false;
        }

        private void ChangeSubscriptionButton_Clicked(object sender, EventArgs e)
        {
            // Call change subscription method
            _subscriptionManager.ChangeSubscription(this.Navigation);

            // Update UI
            UpdateExpirationLabel();
        }


        private void UpdateExpirationLabel()
        {
            if (_subscriptionManager.IsSubscribed)
            {
                ExpirationText = $"Subscription Expires: {_subscriptionManager.ExpirationDate:dd/MM/yyyy}";
            }
            else
            {
                ExpirationText = "Subscription Expires: Not Subscribed";
            }
        }

        protected new void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void BackToSubscriptionsButton_Clicked(object sender, EventArgs e)
        {
            // Navigate back to the previous page
            await Navigation.PopAsync();
        }
    }
}
