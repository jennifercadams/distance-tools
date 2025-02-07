namespace MultiWeather.Models.DTO
{
    public class SearchLocationResponse
    {
        public required decimal Latitude { get; set; }
        public required decimal Longitude { get; set; }
        public required string ShortName { get; set; }
        public required string FullName { get; set; }
    }
}
