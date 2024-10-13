using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace IMProWater
{
    public partial class ProgramSettingsPage : ContentPage, INotifyPropertyChanged
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

        public ProgramSettingsPage(string section)
        {
            InitializeComponent();
            sectionNumber = section;
            SectionTitle = $"Sekcja {sectionNumber}";
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

        private void OnDayButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackgroundColor = button.BackgroundColor == Colors.Gray ? Colors.Transparent : Colors.Gray;
        }

        private void OnOkButtonClicked(object sender, EventArgs e)
        {
            // Logic to save the program settings
            DisplayAlert("Success", $"Ustawienia sekcji {sectionNumber} zosta³y zapisane", "OK");
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            StartTimeEntry.Text = string.Empty;
            DurationEntry.Text = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
