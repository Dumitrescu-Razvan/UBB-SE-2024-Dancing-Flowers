namespace ISSProject
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (IsValidLogin(username, password))
            {
                // Navigate to the AppShell page using the main navigation page
                if (Application.Current != null && Application.Current.MainPage != null)
                {
                    Task poppingTask = Application.Current.MainPage.Navigation.PopAsync();
                    await poppingTask;
                    await DisplayAlert("Login Successful", "Welcome back!", "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new AppShell(true, true, true));
                }
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
        }

        // Dummy validation method, replace with your actual validation logic
        private bool IsValidLogin(string username, string password)
        {
            // Dummy check, replace with your actual validation logic
            return (username == "admin" && password == "password");
        }
        private async void CreateAccButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccPage());
        }
    }
}
