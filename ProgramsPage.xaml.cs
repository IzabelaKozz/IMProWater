using Microsoft.Maui.Controls;

namespace IMProWater
{
    public partial class ProgramsPage : ContentPage
    {
        public ProgramsPage()
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

        private async void OnSectionButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string section = button.Text.Replace("Sekcja ", "");
            await Navigation.PushAsync(new ProgramSettingsPage(section));
        }
    }
}
