using MultiWeather.Exceptions;
using MultiWeather.Models.DTO;
using MultiWeather.Models.WeatherApi;
using System.Text.Json;

namespace MultiWeather.Services.WeatherApiService
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

        public async Task<List<SearchLocationResponse>> SearchLocationAsync(string locationQuery)
        {
            var path = $"search.json?key={_apiKey}&q={locationQuery}";

            var response = await _httpClient.GetAsync(path);
            var responseBody = await response.Content.ReadAsStringAsync();
            var searchResponse = JsonSerializer.Deserialize<List<Location>>(responseBody);

            var responseList = new List<SearchLocationResponse>();

            var locations = searchResponse ?? [];
            foreach (var location in locations)
            {
                string[] nameElements = [location.Name, location.Region, location.Country];
                var fullNameArray = nameElements.Where(part => !string.IsNullOrEmpty(part)).ToArray();
                var getLocationResponse = new SearchLocationResponse
                {
                    ShortName = location.Name,
                    FullName = string.Join(", ", fullNameArray),
                };

                responseList.Add(getLocationResponse);
            }

            return responseList;

        }

        public async Task<List<GetForecastResponse>> GetForecastAsync(string[] locationQueries)
        {
            var responseList = new List<GetForecastResponse>();

            foreach (var locationQuery in locationQueries)
            {
                var cachedResponse = _cache.Get(locationQuery);
                if (cachedResponse != null)
                {
                    responseList.Add(cachedResponse);
                    continue;
                }

                var getForecastResponse = await SendForecastRequestAsync(locationQuery);

                _cache.Set(locationQuery, getForecastResponse);

                responseList.Add(getForecastResponse);
            }

            return responseList;
        }

        private async Task<GetForecastResponse> SendForecastRequestAsync(string locationQuery)
        {
            var path = $"forecast.json?key={_apiKey}&q={locationQuery}&days=1";

            var response = await _httpClient.GetAsync(path);
            var responseBody = await response.Content.ReadAsStringAsync();
            var forecastResponse = JsonSerializer.Deserialize<ForecastResponse>(responseBody);

            if (forecastResponse?.Error != null && forecastResponse.Error.Code != (int)ErrorCodes.LocationNotFound)
            {
                throw new RequestFailedException(responseBody);
            }

            var conditionIconLarge = forecastResponse?.Current?.Condition.Icon.Replace("64x64", "128x128");

            var getForecastResponse = new GetForecastResponse
            {
                LocationQuery = locationQuery,
                LocationFound = forecastResponse?.Location != null,
                LocationName = forecastResponse?.Location?.Name,
                Region = forecastResponse?.Location?.Region,
                Country = forecastResponse?.Location?.Country,
                TimeZone = forecastResponse?.Location?.TimeZone,
                ConditionText = forecastResponse?.Current?.Condition.Text,
                ConditionIcon = conditionIconLarge,
                CurrentTemp = forecastResponse?.Current?.TempC,
                FeelsLike = forecastResponse?.Current?.FeelsLikeC,
                MaxTemp = forecastResponse?.Forecast?.Days?.FirstOrDefault()?.Day?.MaxTempC,
                MinTemp = forecastResponse?.Forecast?.Days?.FirstOrDefault()?.Day?.MinTempC,
                WillItRain = forecastResponse?.Forecast?.Days?.FirstOrDefault()?.Day?.WillItRain,
                ChanceOfRain = forecastResponse?.Forecast?.Days?.FirstOrDefault()?.Day?.ChanceOfRain,
                TotalPrecipMm = forecastResponse?.Forecast?.Days?.FirstOrDefault()?.Day?.TotalPrecipMm,
                WillItSnow = forecastResponse?.Forecast?.Days?.FirstOrDefault()?.Day?.WillItSnow,
                ChanceOfSnow = forecastResponse?.Forecast?.Days?.FirstOrDefault()?.Day?.ChanceOfSnow,
                TotalSnowCm = forecastResponse?.Forecast?.Days?.FirstOrDefault()?.Day?.TotalSnowCm
            };

            return getForecastResponse;
        }

    }
}
