using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace IMProWater
{
    public partial class SectionDetailPage : ContentPage
    {
        private Section _section;
        private Action _saveSectionsCallback;

        public SectionDetailPage(Section section, Action saveSectionsCallback)
        {
            InitializeComponent();
            _section = section;
            _saveSectionsCallback = saveSectionsCallback;

            // Ustaw dane sekcji
            SectionNameEntry.Text = _section.Name;
            StartTimeEntry.Text = _section.StartTime;
            DurationEntry.Text = _section.Duration;
            LoadSelectedDays();
        }

        private void LoadSelectedDays()
        {
            SetDayButtonState("pn", _section.SelectedDays.Contains("pn"));
            SetDayButtonState("wt", _section.SelectedDays.Contains("wt"));
            SetDayButtonState("œr", _section.SelectedDays.Contains("œr"));
            SetDayButtonState("czw", _section.SelectedDays.Contains("czw"));
            SetDayButtonState("pt", _section.SelectedDays.Contains("pt"));
            SetDayButtonState("so", _section.SelectedDays.Contains("so"));
            SetDayButtonState("nd", _section.SelectedDays.Contains("nd"));
        }

        private void SetDayButtonState(string day, bool isSelected)
        {
            Button dayButton = this.FindByName<Button>($"{day}Button");
            dayButton.BackgroundColor = isSelected ? Color.FromHex("#008080") : Color.FromHex("#D3D3D3");
        }

        private void OnDaySelected(object sender, EventArgs e)
        {
            var button = sender as Button;
            string day = button.Text;

            // Prze³¹cz stan dnia i zapis w sekcji
            bool isCurrentlySelected = _section.SelectedDays.Contains(day);
            if (isCurrentlySelected)
            {
                _section.SelectedDays.Remove(day);
                button.BackgroundColor = Color.FromHex("#D3D3D3");
            }
            else
            {
                _section.SelectedDays.Add(day);
                button.BackgroundColor = Color.FromHex("#008080");
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Zapisz zmiany w sekcji
            _section.Name = SectionNameEntry.Text;
            _section.StartTime = StartTimeEntry.Text;
            _section.Duration = DurationEntry.Text;

            _saveSectionsCallback(); // Wywo³aj zapisanie wszystkich sekcji
            await DisplayAlert("Zapisano", "Dane sekcji zosta³y zapisane", "OK");
            await Navigation.PopAsync();
        }
        private void OnEditClicked(object sender, EventArgs e)
        {
            // Logika edycji sekcji
            SectionNameEntry.IsEnabled = true;
            StartTimeEntry.IsEnabled = true;
            DurationEntry.IsEnabled = true;
        }
    }
}
