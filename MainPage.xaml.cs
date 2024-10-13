using Microsoft.Maui.Controls;
using System;

namespace IMProWater
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        // Funkcja obsługująca zamknięcie aplikacji
        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            Application.Current.Quit(); // Zamknięcie aplikacji
        }

    }
}
