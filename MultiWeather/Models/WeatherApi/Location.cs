using System.Text.Json.Serialization;

namespace MultiWeather.Models.WeatherApi
{
    public class Location
    {
        [JsonPropertyName("lat")]
        public decimal Latitude { get; set; }

        [JsonPropertyName("lon")]
        public decimal Longitude { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("region")]
        public string Region { get; set; } = "";

        [JsonPropertyName("country")]
        public string Country { get; set; } = "";

        [JsonPropertyName("tz_id")]
        public string TimeZone { get; set; } = "";

        [JsonPropertyName("localtime_epoch")]
        public int LocalTimeEpoch { get; set; }

        [JsonPropertyName("localtime")]
        public string LocalTime { get; set; } = "";
    }
}
