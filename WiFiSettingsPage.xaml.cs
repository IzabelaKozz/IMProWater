using Microsoft.Maui.Controls;

namespace IMProWater
{
    public partial class WiFiSettingsPage : ContentPage
    {
        public WiFiSettingsPage()
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

        private async void OnWiFiNameButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WiFiNamePage());
        }

        private async void OnWiFiPasswordButtonClicked(object sender, EventArgs e)
        {
            // Tutaj musimy przekazaæ aktualnie po³¹czon¹ sieæ WiFi jako argument.
            string currentNetwork = "Network1"; // Zast¹p tym, jak pobraæ aktualnie po³¹czon¹ sieæ
            await Navigation.PushAsync(new WiFiPasswordPage(currentNetwork));
        }
    }
}
