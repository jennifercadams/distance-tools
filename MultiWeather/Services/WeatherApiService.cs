using MultiWeather.Exceptions;
using MultiWeather.Models.DTO;
using MultiWeather.Models.WeatherApi;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MultiWeather.Services
{
    public enum ErrorCodes
    {
        LocationNotFound = 1006
    }

    public class WeatherApiService
    {
        private const string BaseUrl = "https://api.weatherapi.com/v1/";

        private readonly WeatherApiCache _cache;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherApiService(WeatherApiCache weatherApiCache)
        {
            _cache = weatherApiCache;
            _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            _apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY") ?? "";
        }

        public async Task<List<GetCurrentResponse>> GetCurrentAsync(string[] locationQueries)
        {
            ValidateLocationQueries(locationQueries);

            var responseList = new List<GetCurrentResponse>();

            foreach (var locationQuery in locationQueries)
            {
                var cachedResponse = _cache.Get(locationQuery);
                if (cachedResponse != null)
                {
                    responseList.Add(cachedResponse);
                    continue;
                }

                var getCurrentResponse = await SendCurrentRequestAsync(locationQuery);

                _cache.Set(locationQuery, getCurrentResponse);

                responseList.Add(getCurrentResponse);
            }

            return responseList;
        }

        private void ValidateLocationQueries(string[] locationQueries)
        {
            foreach (var query in locationQueries)
            {
                var pattern = @"^-?\d+\.\d+,-?\d+\.\d+$";
                var match = Regex.IsMatch(query, pattern);

                if (!match)
                    throw new InvalidLocationQueryException(query);
            }
        }

        private async Task<GetCurrentResponse> SendCurrentRequestAsync(string locationQuery)
        {
            var path = $"current.json?key={_apiKey}&q={locationQuery}";

            var response = await _httpClient.GetAsync(path);
            var responseBody = await response.Content.ReadAsStringAsync();
            var currentResponse = JsonSerializer.Deserialize<CurrentResponse>(responseBody);

            if (currentResponse?.Error != null && currentResponse.Error.Code != (int)ErrorCodes.LocationNotFound)
            {
                throw new RequestFailedException(responseBody);
            }

            var getCurrentResponse = new GetCurrentResponse
            {
                LocationQuery = locationQuery,
                LocationFound = currentResponse?.Location != null,
                LocationName = currentResponse?.Location?.Name,
                TimeZone = currentResponse?.Location?.TimeZone,
                ConditionText = currentResponse?.Current?.Condition.Text,
                ConditionIcon = currentResponse?.Current?.Condition.Icon,
                TempC = currentResponse?.Current?.TempC,
                TempF = currentResponse?.Current?.TempF,
            };

            return getCurrentResponse;
        }

    }
}
