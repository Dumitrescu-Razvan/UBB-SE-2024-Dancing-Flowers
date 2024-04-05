namespace ISSProject
{

    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();

            // Populate users list
            PopulateUsersList();

            // Populate admin log
            PopulateAdminLog();

            // Populate claims list
            PopulateClaimsList();
        }

        private void PopulateUsersList()
        {
            // Fetch user data from your data source
            List<string> users = new List<string> { "User 1", "User 2", "User 3" };
            usersListView.ItemsSource = users;
        }

        private void PopulateAdminLog()
        {
            // Fetch admin log data from your data source
            List<string> adminLog = new List<string> { "Admin action 1", "Admin action 2", "Admin action 3" };
            adminLogListView.ItemsSource = adminLog;
        }

        private void PopulateClaimsList()
        {
            // Fetch claims data from your data source
            List<string> claims = new List<string> { "Claim 1", "Claim 2", "Claim 3" };
            claimsListView.ItemsSource = claims;
        }
        private void ClaimsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            // Show the resolve claim section when a claim is selected
            resolveClaimSection.IsVisible = true;
        }

        private void ResolveClaimButton_Clicked(object sender, EventArgs e)
        {
            // Handle resolve claim button click
            string decision = resolveEntry.Text; // Get the decision from the entry
                                                 // Perform any necessary actions with the decision
        }

        private void UsersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Your event handling logic here
        }
        private void BanButton_Clicked(object sender, EventArgs e)
        {
            // Handle ban button click
        }

        private void WarnButton_Clicked(object sender, EventArgs e)
        {
            // Handle warn button click
        }
    }
}