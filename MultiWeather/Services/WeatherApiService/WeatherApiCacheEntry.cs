using MultiWeather.Models.DTO;

namespace MultiWeather.Services.WeatherApiService
{
    public class WeatherApiCacheEntry(GetForecastResponse value, DateTime expiration)
    {
        public GetForecastResponse Response { get; private set; } = value;
        private DateTime Expiration { get; set; } = expiration;
        public bool IsExpired
        {
            get { return DateTime.Now > Expiration; }
        }
    }
}
