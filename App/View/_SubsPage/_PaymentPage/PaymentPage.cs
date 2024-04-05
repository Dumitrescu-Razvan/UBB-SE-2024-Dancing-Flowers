namespace ISSProject
{
    public partial class PaymentPage : ContentPage
    {
        public event EventHandler<bool> ? PaymentCompleted;
        private DateTime _startDate;
        private string _subscriptionType;
        private string _channelName;


        public PaymentPage(DateTime startDate, string subscriptionType, string channelName)
        {
            InitializeComponent();

            _startDate = startDate;
            _subscriptionType = subscriptionType;
            _channelName = channelName;

            // Display subscription information
            SubscriptionInfoLabel.Text = $"Start Date: {_startDate:dd/MM/yyyy}\nSubscription Type: {_subscriptionType}\nChannel: {_channelName}";
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void PayButton_Clicked(object sender, EventArgs e)
        {
            // Perform payment processing here
            string cardNumber = CardNumberEntry.Text;
            string cardholderName = CardholderNameEntry.Text;
            string expirationDate = ExpirationDateEntry.Text;
            string cvv = CVVEntry.Text;

            // Validate input and process payment
            if (string.IsNullOrWhiteSpace(cardNumber) || string.IsNullOrWhiteSpace(cardholderName) ||
                string.IsNullOrWhiteSpace(expirationDate) || string.IsNullOrWhiteSpace(cvv))
            {
                DisplayAlert("Error", "Please fill in all fields.", "OK");
            }
            else
            {
                // Perform payment processing (e.g., call payment gateway API)
                DisplayAlert("Payment", "Payment successful!", "OK");

                // Reset fields after successful payment
                CardNumberEntry.Text = "";
                CardholderNameEntry.Text = "";
                ExpirationDateEntry.Text = "";
                CVVEntry.Text = "";
                PaymentCompleted?.Invoke(this, true); // Pass true for subscribed
                // Navigate back to the previous page
                Navigation.PopAsync();
            }
        }
    }
}
