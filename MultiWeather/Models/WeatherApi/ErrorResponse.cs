using System.Text.Json.Serialization;

namespace MultiWeather.Models.WeatherApi
{
    public class ErrorResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = "";
    }
}
