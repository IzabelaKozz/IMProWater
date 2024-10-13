using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace IMProWater
{
    public partial class NamePage : ContentPage, INotifyPropertyChanged
    {
        private string sectionNumber;
        private string sectionTitle;

        public string SectionTitle
        {
            get => sectionTitle;
            set
            {
                sectionTitle = value;
                OnPropertyChanged(nameof(SectionTitle));
            }
        }

        public NamePage(string section)
        {
            InitializeComponent();
            sectionNumber = section;
            SectionTitle = $"Strefa {sectionNumber}";
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

        private void OnOkButtonClicked(object sender, EventArgs e)
        {
            // Logic to save the new section name
            DisplayAlert("Success", $"Nazwa sekcji {sectionNumber} zmieniona na {SectionTitle}", "OK");
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            NameEntry.Text = SectionTitle;
        }
    }
}
