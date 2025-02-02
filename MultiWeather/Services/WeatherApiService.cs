using MultiWeather.Models.DTO;
using MultiWeather.Models.WeatherApi;
using System.Text.Json;

namespace MultiWeather.Services
{
    public enum ErrorCodes
    {
        LocationNotFound = 1006
    }

    public class WeatherApiService
    {
        private const string BaseUrl = "https://api.weatherapi.com/v1/";

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            _apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY") ?? "";
        }

        public async Task<GetCurrentResponse> GetCurrentAsync(string locationQuery)
        {
            var path = $"current.json?key={_apiKey}&q={locationQuery}";

            var response = await _httpClient.GetAsync(path);

            var responseBody = await response.Content.ReadAsStringAsync();
            var currentResponse = JsonSerializer.Deserialize<CurrentResponse>(responseBody);

            var getCurrentResponse = new GetCurrentResponse()
            {
                LocationName = currentResponse?.Location?.Name,
                TimeZone = currentResponse?.Location?.TimeZone,
                ConditionText = currentResponse?.Current?.Condition.Text,
                ConditionIcon = currentResponse?.Current?.Condition.Icon,
                Temperature = $"{currentResponse?.Current?.TempC}° C | {currentResponse?.Current?.TempF}° F",
                Error = currentResponse?.Error
            };

            return getCurrentResponse;
        }

    }
}
