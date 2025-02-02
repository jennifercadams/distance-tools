namespace MultiWeather.Models.LocationData
{
    public class Country
    {
        public Country(string countryCode)
        {
            CountryCode = countryCode;
            CountryName = "";
            Locations = [];
        }

        public string CountryCode { get; private set; }
        public string CountryName { get; private set; }
        public List<PostalCodeLocation> Locations { get; private set; }
    }
}
