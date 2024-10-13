using Microsoft.Maui.Controls;

namespace IMProWater
{
    public partial class WiFiPasswordPage : ContentPage
    {
        private string networkName;

        public WiFiPasswordPage(string network)
        {
            InitializeComponent();
            networkName = network;
            Title = $"Wpisz has³o dla {networkName}";
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void OnOkButtonClicked(object sender, EventArgs e)
        {
            // Implement logic to connect to the WiFi network with the entered password
            DisplayAlert("Success", $"Po³¹czono z sieci¹ {networkName}", "OK");
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            PasswordEntry.Text = string.Empty;
        }
    }
}
