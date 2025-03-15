using System.Text.Json.Serialization;

namespace MultiWeather.Models.WeatherApi
{
    public class Day
    {
        [JsonPropertyName("maxtemp_c")]
        public decimal MaxTempC {  get; set; }

        [JsonPropertyName("maxtemp_f")]
        public decimal MaxTempF { get; set; }

        [JsonPropertyName("mintemp_c")]
        public decimal MinTempC { get; set; }

        [JsonPropertyName("mintemp_f")]
        public decimal MinTempF { get; set; }

        [JsonPropertyName("avgtemp_c")]
        public decimal AvgTempC { get; set; }

        [JsonPropertyName("avgtemp_f")]
        public decimal AvgTempF { get; set; }

        [JsonPropertyName("maxwind_mph")]
        public decimal MaxWindSpeedMph { get; set; }

        [JsonPropertyName("maxwind_kph")]
        public decimal MaxWindSpeedKph { get; set; }

        [JsonPropertyName("totalprecip_mm")]
        public decimal TotalPrecipMm { get; set; }

        [JsonPropertyName("totalprecip_in")]
        public decimal TotalPrecipIn { get; set; }

        [JsonPropertyName("totalsnow_cm")]
        public decimal TotalSnowCm { get; set; }

        [JsonPropertyName("avgvis_km")]
        public decimal AvgVisibilityKm { get; set; }

        [JsonPropertyName("avgvis_miles")]
        public decimal AvgVisibilityMi { get; set; }

        [JsonPropertyName("avghumidity")]
        public decimal AvgHumidity { get; set; }

        [JsonInclude]
        [JsonPropertyName("daily_will_it_rain")]
        private int _willItRain { get; set; }

        [JsonIgnore]
        public bool WillItRain
        {
            get { return _willItRain == 1; }
        }

        [JsonPropertyName("daily_chance_of_rain")]
        public int ChanceOfRain { get; set; }

        [JsonInclude]
        [JsonPropertyName("daily_will_it_snow")]
        private int _willItSnow { get; set; }

        [JsonIgnore]
        public bool WillItSnow
        {
            get { return _willItSnow == 1; }
        }

        [JsonPropertyName("daily_chance_of_snow")]
        public int ChanceOfSnow { get; set; }

        [JsonPropertyName("condition")]
        public Condition? Condition { get; set; }

        [JsonPropertyName("uv")]
        public decimal UvIndex { get; set; }
    }
}
