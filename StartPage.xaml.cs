using Microsoft.Maui.Controls;

namespace IMProWater
{
    public partial class StartPage : ContentPage
    {
        private string sectionNumber;

        public StartPage(string section)
        {
            InitializeComponent();
            sectionNumber = section;
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
            int minutes;
            if (int.TryParse(TimeEntry.Text, out minutes))
            {
                // Logic to activate the valve
                DisplayAlert("Success", $"Sekcja {sectionNumber} w³¹czona na {minutes} minut", "OK");
            }
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            TimeEntry.Text = string.Empty;
        }
    }
}
