using System.Text.Json.Serialization;

namespace MultiWeather.Models.WeatherApi
{
    public class CurrentResponse
    {
        [JsonInclude]
        [JsonPropertyName("location")]
        private Location? _location { get; set; }

        [JsonIgnore]
        public Location Location
        {
            get
            {
                if (_location == null)
                    _location = new Location();

                return _location;
            }
            set { _location = value; }
        }

        [JsonInclude]
        [JsonPropertyName("current")]
        private Current? _current { get; set; }

        [JsonIgnore]
        public Current Current
        {
            get
            {
                if (_current == null)
                    _current = new Current();

                return _current;
            }
            set { _current = value; }
        }
    }
}
