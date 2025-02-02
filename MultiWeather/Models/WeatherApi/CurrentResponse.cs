using System.Text.Json.Serialization;

namespace MultiWeather.Models.WeatherApi
{
    public class CurrentResponse
    {
        [JsonPropertyName("location")]
        public Location? Location { get; set; }

        [JsonPropertyName("current")]
        public Current? Current { get; set; }

        [JsonPropertyName("error")]
        public ErrorResponse? Error { get; set; }
    }
}
