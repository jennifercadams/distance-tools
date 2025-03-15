using System.Globalization;
using System.Text.Json.Serialization;

namespace MultiWeather.Models.WeatherApi
{
    public class Current
    {
        [JsonPropertyName("last_updated_epoch")]
        public int LastUpdatedEpoch { get; set; }

        [JsonInclude]
        [JsonPropertyName("last_updated")]
        private string _rawLastUpdated { get; set; } = "";

        [JsonIgnore]
        public DateTime LastUpdated
        {
            get
            {
                return DateTime.ParseExact(_rawLastUpdated, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            }
        }

        [JsonPropertyName("temp_c")]
        public decimal TempC { get; set; }

        [JsonPropertyName("temp_f")]
        public decimal TempF { get; set; }

        [JsonPropertyName("feelslike_c")]
        public decimal FeelsLikeC { get; set; }

        [JsonPropertyName("feelslike_f")]
        public decimal FeelsLikeF { get; set; }

        [JsonPropertyName("windchill_c")]
        public decimal WindChillC { get; set; }

        [JsonPropertyName("windchill_f")]
        public decimal WindChillF { get; set; }

        [JsonPropertyName("heatindex_c")]
        public decimal HeatIndexC { get; set; }

        [JsonPropertyName("heatindex_f")]
        public decimal HeatIndexF { get; set; }

        [JsonPropertyName("dewpoint_c")]
        public decimal DewPointC { get; set; }

        [JsonPropertyName("dewpoint_f")]
        public decimal DewPointF { get; set; }

        [JsonInclude]
        [JsonPropertyName("condition")]
        private Condition? _condition { get; set; }

        [JsonIgnore]
        public Condition Condition
        {
            get
            {
                if (_condition == null)
                    _condition = new Condition();

                return _condition;
            }
            set { _condition = value; }
        }

        [JsonPropertyName("wind_mph")]
        public decimal WindSpeedMph { get; set; }

        [JsonPropertyName("wind_kph")]
        public decimal WindSpeedKph { get; set; }

        [JsonPropertyName("wind_degree")]
        public int WindDirectionDegree { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDirectionCompass { get; set; } = "";

        [JsonPropertyName("pressure_mb")]
        public decimal PressureMb { get; set; }

        [JsonPropertyName("pressure_in")]
        public decimal PressureIn { get; set; }

        [JsonPropertyName("precip_mm")]
        public decimal PrecipitationMm { get; set; }

        [JsonPropertyName("precip_in")]
        public decimal PrecipitationIn { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("cloud")]
        public int CloudCover { get; set; }

        [JsonInclude]
        [JsonPropertyName("is_day")]
        private int _isDay { get; set; }

        [JsonIgnore]
        public bool IsDay
        {
            get { return _isDay == 1; }
        }

        [JsonPropertyName("uv")]
        public decimal UvIndex { get; set; }

        [JsonPropertyName("gust_mph")]
        public decimal WindGustMph { get; set; }

        [JsonPropertyName("gust_kph")]
        public decimal WindGustKph { get; set; }

        [JsonPropertyName("vis_km")]
        public decimal VisibilityKm { get; set; }

        [JsonPropertyName("vis_miles")]
        public decimal VisibilityMi { get; set; }
    }
}
