namespace MultiWeather.Models.DTO
{
    public class GetForecastResponse
    {
        public required string LocationQuery { get; set; }
        public required bool LocationFound { get; set; }
        public string? LocationName { get; set; }
        public string? TimeZone { get; set; }
        public string? ConditionText { get; set; }
        public string? ConditionIcon { get; set; }
        public decimal? CurrentTemp { get; set; }
        public decimal? MaxTemp { get; set; }
        public decimal? MinTemp { get; set; }
    }
}
