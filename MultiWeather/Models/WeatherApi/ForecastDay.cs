using System.Globalization;
using System.Text.Json.Serialization;

namespace MultiWeather.Models.WeatherApi
{
    public class ForecastDay
    {
        [JsonInclude]
        [JsonPropertyName("date")]
        private string _rawDate { get; set; } = "";

        [JsonIgnore]
        public DateTime Date
        {
            get
            {
                return DateTime.ParseExact(_rawDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
        }

        [JsonPropertyName("date_epoch")]
        public int DateEpoch { get; set; }

        [JsonPropertyName("day")]
        public Day? Day { get; set; }

        [JsonPropertyName("astro")]
        public Astro? Astro { get; set; }

        [JsonPropertyName("hour")]
        public Hour[]? Hours { get; set; }
    }
}
