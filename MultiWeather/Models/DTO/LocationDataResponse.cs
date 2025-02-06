namespace MultiWeather.Models.DTO
{
    public class LocationDataResponse
    {
        public string PlaceName { get; set; } = "";
        public string CountryCode { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
