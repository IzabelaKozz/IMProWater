using Microsoft.Maui.Controls;

namespace IMProWater
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnWiFiButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WiFiSettingsPage());
        }

        private async void OnProgramsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProgramsPage());
        }

        private async void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            // Add your additional settings functionality here
        }
    }
}
