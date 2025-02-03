using Microsoft.AspNetCore.Mvc;
using MultiWeather.Services;
using System.Text.Json;

namespace MultiWeather.Controllers
{
    [ApiController]
    [Route("Location")]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationController()
        {
            _locationService = new LocationService();
        }

        [HttpGet]
        [Route("GetCountryNameList")]
        public ContentResult GetCountryNameList()
        {
            try
            {
                var list = _locationService.GetCountryNameList();
                var jsonList = JsonSerializer.Serialize(list);
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status200OK,
                    Content = jsonList,
                    ContentType = "application/json"
                };
            }
            catch (Exception)
            {
                return new ContentResult { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        [HttpGet]
        [Route("GetPostalCodeLocation")]
        public ContentResult GetPostalCodeLocation(string countryCode, string postalCode)
        {
            try
            {
                var location = _locationService.GetPostalCodeLocation(countryCode, postalCode);

                if (location == null)
                {
                    return new ContentResult { StatusCode = StatusCodes.Status400BadRequest };
                }

                var jsonLocation = JsonSerializer.Serialize(location);
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status200OK,
                    Content = jsonLocation,
                    ContentType = "application/json"
                };
            }
            catch (Exception)
            {
                return new ContentResult { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

    }
}
