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
            try
            {
                var response = await _weatherApiService.GetCurrentAsync(locationQuery);
                if (response.Error != null)
                {
                    return CreateErrorResponse(response.Error.Code);
                }

                var jsonResponse = JsonSerializer.Serialize(response);
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status200OK,
                    Content = jsonResponse,
                    ContentType = "application/json"
                };
            }
            catch (Exception)
            {
                return new ContentResult { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        private ContentResult CreateErrorResponse(int errorCode)
        {
            if (errorCode == (int)ErrorCodes.LocationNotFound)
            {
                return new ContentResult { StatusCode = StatusCodes.Status400BadRequest };
            }
            else
            {
                return new ContentResult { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

    }
}
