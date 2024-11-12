using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IMProWater
{
    public class WeatherService
    {
        private readonly string _apiKey = "a530c8a029be6a7f94a8b00299a9809a"; // Podaj swój klucz API
        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        // Pobieranie prognozy godzinowej na 4 dni
        public async Task<List<WeatherData>> GetHourlyForecastAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            var forecastResponse = JsonConvert.DeserializeObject<ForecastResponse>(response);

            // Filtrowanie wszystkich danych prognozy co 3 godziny (API daje 5-dniową prognozę, co 3 godziny)
            var hourlyForecasts = new List<WeatherData>();
            foreach (var forecast in forecastResponse.List)
            {
                hourlyForecasts.Add(forecast);
            }
            return hourlyForecasts;
        }

        // Pobieranie prognozy dziennej na 16 dni
        public async Task<List<WeatherData>> GetDailyForecastAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            var forecastResponse = JsonConvert.DeserializeObject<ForecastResponse>(response);

            // Filtrowanie danych na godzinę 12:00 każdego dnia, aby uzyskać jedną prognozę na dzień
            var dailyForecasts = new List<WeatherData>();
            foreach (var forecast in forecastResponse.List)
            {
                if (DateTimeOffset.FromUnixTimeSeconds(forecast.Timestamp).Hour == 12)
                {
                    dailyForecasts.Add(forecast);
                }
            }
            return dailyForecasts;
        }
    }

    public class ForecastResponse
    {
        [JsonProperty("list")]
        public List<WeatherData> List { get; set; }
    }

    public class WeatherData
    {
        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("dt")]
        public long Timestamp { get; set; } // Używamy timestamp

        public DateTime DateTime => DateTimeOffset.FromUnixTimeSeconds(Timestamp).DateTime; // Konwersja timestamp na DateTime
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }
    }

    public class Weather
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
