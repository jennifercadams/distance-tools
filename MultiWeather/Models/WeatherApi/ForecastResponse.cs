using System.Text.Json.Serialization;

namespace MultiWeather.Models.WeatherApi
{
    public class ForecastResponse
    {
        [JsonPropertyName("location")]
        public Location? Location { get; set; }

        [JsonPropertyName("current")]
        public Current? Current { get; set; }

        [JsonPropertyName("forecast")]
        public Forecast? Forecast { get; set; }

        [JsonPropertyName("error")]
        public ErrorResponse? Error { get; set; }
    }
}
