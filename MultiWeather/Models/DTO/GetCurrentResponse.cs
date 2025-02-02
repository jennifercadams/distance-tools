using MultiWeather.Models.WeatherApi;
using System.Text.Json.Serialization;

namespace MultiWeather.Models.DTO
{
    public class GetCurrentResponse
    {
        public string? LocationName { get; set; }
        public string? TimeZone { get; set; }
        public string? ConditionText { get; set; }
        public string? ConditionIcon { get; set; }
        public decimal? TempC { get; set; }
        public decimal? TempF { get; set; }

        [JsonIgnore]
        public ErrorResponse? Error { get; set; }
    }
}
