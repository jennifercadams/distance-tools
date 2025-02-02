using Microsoft.AspNetCore.Mvc;
using MultiWeather.Services;
using System.Text.Json;

namespace MultiWeather.Controllers
{
    [ApiController]
    [Route("MultiWeather")]
    public class MultiWeatherController : ControllerBase
    {
        private readonly WeatherApiService _weatherApiService;

        public MultiWeatherController()
        {
            _weatherApiService = new WeatherApiService();
        }

        [HttpGet]
        [Route("GetCurrent")]
        public async Task<ContentResult> GetCurrent(string locationQuery)
        {
            var response = await _weatherApiService.GetCurrentAsync(locationQuery);
            var jsonResponse = JsonSerializer.Serialize(response);
            return new ContentResult()
            {
                StatusCode = StatusCodes.Status200OK,
                Content = jsonResponse,
                ContentType = "application/json"
            };
        }

    }
}
