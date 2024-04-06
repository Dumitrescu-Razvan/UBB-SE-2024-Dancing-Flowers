using System.ComponentModel;

namespace ISSProject
{
    public partial class MySubscriptionPage : ContentPage, INotifyPropertyChanged
    {
        private SubscriptionManager _subscriptionManager;

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

        private string? _expirationText;
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

        private string? _changeTextButton;
        public string ChangeTextButton
        {
            get { return _changeTextButton ?? string.Empty; }
            set
            {
                if (_changeTextButton != value)
                {
                    _changeTextButton = value;
                    OnPropertyChanged(nameof(ChangeTextButton));
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


        public MySubscriptionPage(string subscriptionName)
        {
            InitializeComponent();

            // Initialize subscription manager
            _subscriptionManager = new SubscriptionManager();

            BindingContext = this;

            ChannelName = subscriptionName;

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
                ChangeTextButton = "Change";
            }
            else
            {
                ExpirationText = "Not Subscribed";
                ChangeTextButton = "Subscribe";
            }
        }
        private async void BackToSubscriptionsButton_Clicked(object sender, EventArgs e)
        {
            // Navigate back to the previous page
            await Navigation.PopAsync();
        }
    }
}
