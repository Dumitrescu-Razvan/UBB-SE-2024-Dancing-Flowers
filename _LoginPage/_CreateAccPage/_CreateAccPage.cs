namespace ISSProject
{
    public partial class CreateAccPage : ContentPage
    {
        private bool _client;
        public bool Client
        {
            get => _client;
            set
            {
                if (_client != value)
                {
                    _client = value;
                    OnPropertyChanged(nameof(Client));
                }
            }
        }
        private string email { get; set;} = new string("");
        private string username { get; set;} = new string("");
        private string password { get; set;} = new string("");
        private string confirmPassword { get; set;} = new string("");
        
        public CreateAccPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        private async void CreateAccButton_Clicked(object sender, EventArgs e)
        {
            email = emailEntry.Text;
            username = usernameEntry.Text;
            password = passwordEntry.Text;
            confirmPassword = confirmPasswordEntry.Text;

            if (IsValidCreateAcc(Client, email, username, password, confirmPassword))
            {
                // Navigate to the AppShell page using the main navigation page
                if (Application.Current != null && Application.Current.MainPage != null)
                {
                    Task poppingTask = Application.Current.MainPage.Navigation.PopAsync();
                    await poppingTask;
                    await DisplayAlert("Account Creation Successful", "Welcome to the app!", "OK");
                    Application.Current.MainPage = new AppShell(true, true, true);
                }
            }
            else
            {
                await DisplayAlert("Account Creation Failed", "Invalid email, username, password, or confirm password", "OK");
            }
        }
        public void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Perform required operation after examining e.Value
            Client = e.Value;
        }
        // Dummy validation method, replace with your actual validation logic
        private bool IsValidCreateAcc(bool client, string email, string username, string password, string confirmPassword)
        {
            // Dummy check, replace with your actual validation logic
            return email == "admin" && username == "admin" && password == "password" && confirmPassword == "password" && client == true;
        }
        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}