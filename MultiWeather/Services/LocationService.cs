using MultiWeather.Exceptions;
using MultiWeather.Models.DTO;
using MultiWeather.Models.LocationData;
using MultiWeather.Utilities;

namespace MultiWeather.Services
{
    public class LocationService
    {
        private readonly Dictionary<string, string> CountryNameList;
        private readonly Dictionary<string, Country> Countries;

        public LocationService()
        {
            CountryNameList = LocationDataCollection.CountryNameList;
            Countries = LocationDataCollection.Countries;
        }

        public Dictionary<string, string> GetCountryNameList()
        {
            return CountryNameList;
        }

        public LocationDataResponse GetPostalCodeLocation(string countryCode, string postalCode)
        {
            if (!Countries.TryGetValue(countryCode, out Country? country))
                throw new CountryNotFoundException(countryCode);

            var location = country.Locations.Find(l => l.PostalCode.ToUpper() == postalCode.Trim().ToUpper());

            if (location == null)
                throw new LocationNotFoundException(postalCode);

            return new LocationDataResponse
            {
                PlaceName = location.PlaceName,
                CountryCode = countryCode,
                PostalCode = location.PostalCode,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
            };
        }

    }
}
