using System.Text.Json.Serialization;

namespace MultiWeather.Models.WeatherApi
{
    public class Forecast
    {
        [JsonPropertyName("forecastday")]
        public ForecastDay[]? Days { get; set; }
    }
}
