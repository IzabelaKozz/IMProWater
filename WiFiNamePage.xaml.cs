using Microsoft.Maui.Controls;

namespace IMProWater
{
    public partial class WiFiNamePage : ContentPage
    {
        public WiFiNamePage()
        {
            InitializeComponent();
            // Example list of WiFi networks
            WiFiNetworksList.ItemsSource = new string[] { "Network1", "Network2", "Network3" };
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private string selectedNetwork;
        private void OnNetworkSelected(object sender, ItemTappedEventArgs e)
        {
            selectedNetwork = e.Item as string;
        }

        private async void OnAcceptButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedNetwork))
            {
                await Navigation.PushAsync(new WiFiPasswordPage(selectedNetwork));
            }
        }
    }
}
