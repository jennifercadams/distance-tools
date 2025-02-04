using Microsoft.AspNetCore.Mvc;
using MultiWeather.Exceptions;
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
        public async Task<ContentResult> GetCurrent([FromQuery] string[] locationQueries)
        {
            try
            {
                var response = await _weatherApiService.GetCurrentAsync(locationQueries);
                var jsonResponse = JsonSerializer.Serialize(response);
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status200OK,
                    Content = jsonResponse,
                    ContentType = "application/json"
                };
            }
            catch (InvalidLocationQueryException ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return new ContentResult { StatusCode = StatusCodes.Status400BadRequest };
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return new ContentResult { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

    }
}
