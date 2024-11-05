using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;

namespace IMProWater
{
    public partial class SectionsPage : ContentPage
    {
        private List<Section> _sections;

        public SectionsPage()
        {
            InitializeComponent();
            LoadSections();
        }

        private void LoadSections()
        {
            // Odczytaj zapisane sekcje z Preferences
            var sectionsJson = Preferences.Get("Sections", "[]");
            _sections = JsonConvert.DeserializeObject<List<Section>>(sectionsJson);

            // Wyœwietl ka¿d¹ sekcjê na stronie
            SectionsContainer.Children.Clear();
            foreach (var section in _sections)
            {
                AddSectionTile(section);
            }
        }

        private void AddSectionTile(Section section)
{
    var sectionFrame = new Frame
    {
        BackgroundColor = Color.FromHex("#B3FFFFFF"), // Pó³przezroczyste t³o
        BorderColor = Color.FromHex("#B3FFFFFF"), // Kolor ramki, np. morski (dopasuj do estetyki logowania)
        CornerRadius = 15,
        HasShadow = true,
        Padding = 20,
        HorizontalOptions = LayoutOptions.FillAndExpand,
        VerticalOptions = LayoutOptions.Center,
        WidthRequest = 500,
        HeightRequest = 100


    };

    var sectionLabel = new Label
    {
        Text = section.Name,
        TextColor = Color.FromHex("black"), // Kolor tekstu, np. morski (dopasuj do estetyki logowania)
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        FontSize = 18 // Mo¿esz dostosowaæ rozmiar tekstu
    };

    sectionFrame.Content = sectionLabel;

    var tapGestureRecognizer = new TapGestureRecognizer();
    tapGestureRecognizer.Tapped += (s, args) => NavigateToSectionDetail(section);
    sectionFrame.GestureRecognizers.Add(tapGestureRecognizer);

    SectionsContainer.Children.Add(sectionFrame);
}

        private void OnAddSectionClicked(object sender, EventArgs e)
        {
            var newSection = new Section
            {
                Id = Guid.NewGuid().ToString(),
                Name = "nowa sekcja"
            };
            _sections.Add(newSection);
            SaveSections();
            AddSectionTile(newSection);
        }

        private void SaveSections()
        {
            var sectionsJson = JsonConvert.SerializeObject(_sections);
            Preferences.Set("Sections", sectionsJson);
        }

        private async void NavigateToSectionDetail(Section section)
        {
            await Navigation.PushAsync(new SectionDetailPage(section, SaveSections));
        }
    }
}
