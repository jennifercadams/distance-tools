using Microsoft.AspNetCore.Mvc;
using MultiWeather.Exceptions;
using MultiWeather.Services.LocationService;
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
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }
        }

        [HttpGet]
        [Route("GetPostalCodeLocation")]
        public ContentResult GetPostalCodeLocation(string countryCode, string postalCode)
        {
            try
            {
                var location = _locationService.GetPostalCodeLocation(countryCode, postalCode);
                var jsonLocation = JsonSerializer.Serialize(location);
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status200OK,
                    Content = jsonLocation,
                    ContentType = "application/json"
                };
            }
            catch (Exception ex)
            {
                return HandleErrorResponse(ex);
            }
        }

        private ContentResult HandleErrorResponse(Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());

            if (ex is CountryNotFoundException || ex is LocationNotFoundException)
            {
                return new ContentResult { StatusCode = StatusCodes.Status400BadRequest };
            }
            else
            {
                Console.Error.WriteLine(ex.ToString());
                return new ContentResult { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

    }
}
