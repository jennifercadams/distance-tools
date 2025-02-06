using MultiWeather.Models.DTO;

namespace MultiWeather.Services
{
    public class WeatherApiCacheEntry(GetCurrentResponse value, DateTime expiration)
    {
        public GetCurrentResponse Response { get; private set; } = value;
        private DateTime Expiration { get; set; } = expiration;
        public bool IsExpired
        {
            get { return DateTime.Now > Expiration; }
        }
    }
}
