namespace MultiWeather.Models.LocationData
{
    public class Country(string countryCode, string countryName)
    {
        public string CountryCode { get; private set; } = countryCode;
        public string CountryName { get; private set; } = countryName;
        public List<PostalCodeLocation> Locations { get; private set; } = [];
    }
}
