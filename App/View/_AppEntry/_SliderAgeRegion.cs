using Microsoft.Maui.Controls;
using System;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;

namespace ISSProject
{
    public partial class SliderAgeRegion : ContentPage
    {
        public static string? SelectedCountry { get; set; }
        public static int SelectedAge { get; set; }

        public SliderAgeRegion()
        {
            InitializeComponent();
        }
        private void ClosePopupButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pickerCountry.SelectedItem as string))
            {
                DisplayAlert("Error", "Please select a country.", "OK");
                return;
            }

            if (pickerAge.SelectedItem == null)
            {
                DisplayAlert("Error", "Please select an age.", "OK");
                return;
            }

            // Retrieve selected country and age
            string selectedCountry = pickerCountry.SelectedItem as string;
            int selectedAge = (int)pickerAge.SelectedItem;
            Application.Current.MainPage = new AppShell(false, false, false);

            // Use the selected country and age as needed
            // For example, you can display them in a label or perform any other actions
        }
    }
}
