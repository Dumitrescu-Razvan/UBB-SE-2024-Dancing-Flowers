namespace ISSProject
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private string? _username { get; set;} = new string("");
        private string? _password { get; set;} = new string("");

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            _username = usernameEntry.Text;
            _password = passwordEntry.Text;

            if (IsValidLogin(_username, _password))
            {
                // Navigate to the AppShell page using the main navigation page
                if (Application.Current != null && Application.Current.MainPage != null)
                {
                    Task poppingTask = Application.Current.MainPage.Navigation.PopAsync();
                    await poppingTask;
                    await DisplayAlert("Login Successful", "Welcome back!", "OK");
                    Application.Current.MainPage  = new AppShell(true, true, true);
                }
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
        }

        // Dummy validation method, replace with your actual validation logic
        private bool IsValidLogin(string _username, string _password)
        {
            // Dummy check, replace with your actual validation logic
            return (_username == "admin" && _password == "password");
        }
        private async void CreateAccButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccPage());
        }
    }
}
