namespace ISSProject
{
    public partial class CreateAccPage : ContentPage
    {
        private string email { get; set;} = new string("");
        private string username { get; set;} = new string("");
        private string password { get; set;} = new string("");
        private string confirmPassword { get; set;} = new string("");
        
        public CreateAccPage()
        {
            InitializeComponent();
        }
        private async void CreateAccButton_Clicked(object sender, EventArgs e)
        {
            email = emailEntry.Text;
            username = usernameEntry.Text;
            password = passwordEntry.Text;
            confirmPassword = confirmPasswordEntry.Text;

            if (IsValidCreateAcc(email, username, password, confirmPassword))
            {
                // Navigate to the AppShell page using the main navigation page
                if (Application.Current != null && Application.Current.MainPage != null)
                {
                    Task poppingTask = Application.Current.MainPage.Navigation.PopAsync();
                    await poppingTask;
                    await DisplayAlert("Account Creation Successful", "Welcome to the app!", "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new AppShell(true, true, true));
                }
            }
            else
            {
                await DisplayAlert("Account Creation Failed", "Invalid email, username, password, or confirm password", "OK");
            }
        }

        // Dummy validation method, replace with your actual validation logic
        private bool IsValidCreateAcc(string email, string username, string password, string confirmPassword)
        {
            // Dummy check, replace with your actual validation logic
            return (email == "admin" && username == "admin" && password == "password" && confirmPassword == "password");
        }
        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}