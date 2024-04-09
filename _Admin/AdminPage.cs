using System;
using System.Collections.ObjectModel;


namespace ISSProject
{
    public partial class AdminPage : ContentPage
    {
        public ObservableCollection<string> Users { get; set; }
        public ObservableCollection<string> AdminLog { get; set; }
        public ObservableCollection<string> Claims { get; set; }

        private string? _selectedUser;
        public string? SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelectedUser));
                }
            }
        }


        public AdminPage()
        {
            InitializeComponent();

            // Initialize ObservableCollection instances
            Users = new ObservableCollection<string> { "User 1", "User 2", "User 3" };
            AdminLog = new ObservableCollection<string> { "Log 1", "Log 2", "Log 3" };
            Claims = new ObservableCollection<string> { "Claim 1", "Claim 2", "Claim 3", "Claim 4", "Claim 5" };

            // Set the BindingContext to the current instance
            BindingContext = this;
        }

        private void ClaimsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                // If an item is selected, make the resolveClaimSection visible
                resolveClaimSection.IsVisible = true;
            }
            else
            {
                // If no item is selected, hide the resolveClaimSection
                resolveClaimSection.IsVisible = false;
            }
        }

        private void UserCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                // If an item is selected, make the resolveClaimSection visible
                actionButtonsLayout.IsVisible = true;
                // Set the selected user
                SelectedUser = e.CurrentSelection.FirstOrDefault() as string;
            }
            else
            {
                // If no item is selected, hide the resolveClaimSection
                actionButtonsLayout.IsVisible = false;
            }
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
            if (!string.IsNullOrEmpty(SelectedUser))
            {
                // Handle ban button click
                // This method will be called when the Ban button is clicked
                // You can implement the logic to ban the selected user here
                // For example, you can add a ban log entry to the AdminLog collection
                
                AdminLog.Add($"Banned user: {SelectedUser}");
                SelectedUser = "";
            }
        }

        private void WarnButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedUser))
            {
                // Handle warn button click
                // This method will be called when the Warn button is clicked
                // You can implement the logic to warn the selected user here
                // For example, you can add a warn log entry to the AdminLog collection
                
                AdminLog.Add($"Warned user: {SelectedUser}");
                SelectedUser = "";
            }
        }
    }
}
