using System.Collections.ObjectModel;

namespace ISSProject
{
    public partial class SubscriptionsPage : ContentPage
    {
        public ObservableCollection<string> MonthlySubscriptions { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> YearlySubscriptions { get; } = new ObservableCollection<string>();
        public SubscriptionsPage()
        {
            InitializeComponent();

            // Set the BindingContext
            BindingContext = this;

            // Populate monthly subscriptions
            MonthlySubscriptions.Add("Netflix");
            MonthlySubscriptions.Add("Spotify");
            MonthlySubscriptions.Add("Hulu");

            // Populate yearly subscriptions
            YearlySubscriptions.Add("Disney+");
            YearlySubscriptions.Add("Apple Music");
            YearlySubscriptions.Add("Amazon Prime");
        }

        // Event handler for button clicks
        private async void Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                // Extract subscription name from the button's BindingContext
                var subscriptionName = button.BindingContext as string;
                if (subscriptionName != null)
                {

                    // Redirect to MySubscriptionPage passing subscription info
                    await Navigation.PushAsync(new MySubscriptionPage(subscriptionName));
                }
            }
        }
    }
}
