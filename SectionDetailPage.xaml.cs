using Microsoft.Maui.Controls;

namespace IMProWater
{
    public partial class SectionDetailPage : ContentPage
    {
        public string Title { get; set; }
        public string SectionNumber { get; set; }

        public SectionDetailPage(string sectionNumber)
        {
            InitializeComponent();
            SectionNumber = sectionNumber;
            Title = $"Sekcja {SectionNumber}";
            BindingContext = this;
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnStartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartPage(SectionNumber));
        }

        private async void OnNameButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NamePage(SectionNumber));
        }
    }
}
