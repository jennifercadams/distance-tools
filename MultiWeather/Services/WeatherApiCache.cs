using MultiWeather.Models.DTO;

namespace MultiWeather.Services
{
    public class WeatherApiCache
    {
        private const int MaxSize = 10000;
        private const double ExpInMinutes = 10.0;
        private const double CleanUpInterval = 30.0;

        private readonly Dictionary<string, WeatherApiCacheEntry> Entries;

        public WeatherApiCache()
        {
            Entries = [];
            Task.Run(StartCacheCleanUpTask);
        }

        public GetCurrentResponse? Get(string key)
        {
            if (Entries.TryGetValue(key, out WeatherApiCacheEntry? value) && value != null)
                return value.Response;
            else
                return null;
        }

        public void Set(string key, GetCurrentResponse value)
        {
            var expiration = DateTime.Now.AddMinutes(ExpInMinutes);
            var entry = new WeatherApiCacheEntry(value, expiration);

            if (Entries.Count >= MaxSize)
                CleanExpired();

            if (Entries.Count < MaxSize)
                Entries.Add(key, entry);
        }

        private Task StartCacheCleanUpTask()
        {
            Console.WriteLine("Cache cleanup is running in the background.");

            while (true)
            {
                Task.Delay(TimeSpan.FromMinutes(CleanUpInterval)).Wait();

                Console.WriteLine("Cleaning cache...");

                CleanExpired();

                Console.WriteLine("Cache cleanup complete.");
            }
        }

        private void CleanExpired()
        {
            var expiredEntryKeys = new List<string>();

            foreach (var entry in Entries)
            {
                if (entry.Value.IsExpired)
                    expiredEntryKeys.Add(entry.Key);
            }

            foreach (var key in expiredEntryKeys)
            {
                Entries.Remove(key);
            }
        }
    }
}
