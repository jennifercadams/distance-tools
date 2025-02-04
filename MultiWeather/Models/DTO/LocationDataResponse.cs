namespace MultiWeather.Models.DTO
{
    public class LocationDataResponse
    {
        public string PlaceName { get; set; } = "";
        public string CountryCode { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
