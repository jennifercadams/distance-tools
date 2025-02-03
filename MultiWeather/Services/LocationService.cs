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

        public LocationDataResponse? GetPostalCodeLocation(string countryCode, string postalCode)
        {
            if (!Countries.TryGetValue(countryCode, out Country? country))
                return null;

            var location = country.Locations.Find(l => {
                return l.PostalCode.ToUpper() == postalCode.Trim().ToUpper();
            });

            if (location == null)
                return null;

            return new LocationDataResponse
            {
                CountryCode = countryCode,
                PostalCode = location.PostalCode,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
            };
        }

    }
}
