using Microsoft.Maui.Controls;
using System;
using Microsoft.Maui.Controls.Xaml;

namespace ISSProject
{
    public partial class AppShell : Shell
    {
        public static bool IsLoggedIn { get; set; } = false;
        public static bool IsAdmin { get; set; } = false;
        public static bool IsAClient { get; set; } = false;
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        public AppShell(bool isLoggedIn, bool isAClient, bool isAdmin)
        {
            InitializeComponent();
            IsLoggedIn = isLoggedIn;
            IsAClient = isAClient;
            IsAdmin = isAdmin;
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);

            // Update tab visibility whenever navigation occurs
            UpdateTabVisibility();
        }

        // Method to update the visibility of the tabs based on type
        private void UpdateTabVisibility()
        {
            IsLoggedInSub.IsVisible = IsLoggedIn;
            IsLoggedInShow.IsVisible = !IsLoggedIn;
            IsAClientCont.IsVisible = IsAClient;
            IsAClientSub.IsVisible = IsAClient;
            IsAdminSub.IsVisible = IsAdmin;

        }
            
    }
}