using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace IMProWater
{
    public class StatusPageViewModel : INotifyPropertyChanged
    {
        private readonly WeatherService _weatherService;
        private string _selectedCity;

        public ObservableCollection<WeatherData> HourlyForecast { get; set; }
        public ObservableCollection<WeatherData> DailyForecast { get; set; }
        public ObservableCollection<string> Cities { get; set; }

        public string SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    OnPropertyChanged();
                    LoadHourlyForecastAsync(); // Ładowanie prognozy godzinowej po zmianie miasta
                    LoadDailyForecastAsync();  // Ładowanie prognozy dziennej po zmianie miasta
                }
            }
        }

        public ICommand LoadHourlyCommand { get; }
        public ICommand LoadDailyCommand { get; }

        public StatusPageViewModel()
        {
            _weatherService = new WeatherService();
            HourlyForecast = new ObservableCollection<WeatherData>();
            DailyForecast = new ObservableCollection<WeatherData>();

            // Lista popularnych miast
            Cities = new ObservableCollection<string> { "Warsaw", "New York", "London", "Paris", "Tokyo", "Berlin", "Rome", "Sydney" };
            SelectedCity = Cities[0]; // Domyślnie ustawione miasto

            LoadHourlyCommand = new Command(async () => await LoadHourlyForecastAsync());
            LoadDailyCommand = new Command(async () => await LoadDailyForecastAsync());
        }

        public async Task LoadHourlyForecastAsync()
        {
            if (string.IsNullOrEmpty(SelectedCity))
                return;

            var forecasts = await _weatherService.GetHourlyForecastAsync(SelectedCity);
            HourlyForecast.Clear();
            foreach (var forecast in forecasts)
            {
                HourlyForecast.Add(forecast);
            }
        }

        public async Task LoadDailyForecastAsync()
        {
            if (string.IsNullOrEmpty(SelectedCity))
                return;

            var forecasts = await _weatherService.GetDailyForecastAsync(SelectedCity);
            DailyForecast.Clear();
            foreach (var forecast in forecasts)
            {
                DailyForecast.Add(forecast);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
