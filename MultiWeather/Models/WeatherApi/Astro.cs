using System.Text.Json.Serialization;

namespace MultiWeather.Models.WeatherApi
{
    public class Astro
    {
        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; } = "";

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; } = "";

        [JsonPropertyName("moonrise")]
        public string Moonrise { get; set; } = "";

        [JsonPropertyName("moonset")]
        public string Moonset { get; set; } = "";

        [JsonPropertyName("moon_phase")]
        public string MoonPhase { get; set; } = "";

        [JsonPropertyName("moon_illumination")]
        public decimal MoonIllumination { get; set; }

        [JsonInclude]
        [JsonPropertyName("is_moon_up")]
        private int _isMoonUp { get; set; }

        [JsonIgnore]
        public bool IsMoonUp
        {
            get { return _isMoonUp == 1; }
        }

        [JsonInclude]
        [JsonPropertyName("is_sun_up")]
        private int _isSunUp { get; set; }

        [JsonIgnore]
        public bool IsSunUp
        {
            get { return _isSunUp == 1; }
        }
    }
}
