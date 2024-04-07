using System;
using System.Collections.ObjectModel;


namespace ISSProject
{
    public partial class AdminPage : ContentPage
    {
        public ObservableCollection<string> Users { get; set; }
        public ObservableCollection<string> AdminLog { get; set; }
        public ObservableCollection<string> Claims { get; set; }

        public AdminPage()
        {
            InitializeComponent();

            // Initialize ObservableCollection instances
            Users = new ObservableCollection<string> { "User 1", "User 2", "User 3" };
            AdminLog = new ObservableCollection<string> { "Log 1", "Log 2", "Log 3" };
            Claims = new ObservableCollection<string> { "Claim 1", "Claim 2", "Claim 3" };

            // Set the BindingContext to the current instance
            BindingContext = this;
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
