using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace IMProWater
{
    public partial class StatusPage : ContentPage
    {
        public ObservableCollection<SectionStatus> SectionStatuses { get; set; }

        public StatusPage()
        {
            InitializeComponent();
            SectionStatuses = new ObservableCollection<SectionStatus>
            {
                new SectionStatus { SectionName = "Sekcja1", StartTime = "05:00", Duration = "30min", Days = "PN" },
                new SectionStatus { SectionName = "Sekcja2", StartTime = "05:30", Duration = "30min", Days = "PN" },
                new SectionStatus { SectionName = "Sekcja3", StartTime = "05:00", Duration = "15min", Days = "WT" },
                new SectionStatus { SectionName = "Sekcja4", StartTime = "05:15", Duration = "15min", Days = "WT" },
                new SectionStatus { SectionName = "Sekcja5", StartTime = "05:30", Duration = "30min", Days = "WT" },
                new SectionStatus { SectionName = "Sekcja6", StartTime = "05:00", Duration = "60min", Days = "ŒR" },
            };
            BindingContext = this;
            StatusListView.ItemsSource = SectionStatuses;
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }

    public class SectionStatus
    {
        public string SectionName { get; set; }
        public string StartTime { get; set; }
        public string Duration { get; set; }
        public string Days { get; set; }
    }
}
