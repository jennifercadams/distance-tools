namespace MultiWeather.Models.DTO
{
    public class GetCurrentResponse
    {
        public required string LocationQuery { get; set; }
        public required bool LocationFound {  get; set; }
        public string? LocationName { get; set; }
        public string? TimeZone { get; set; }
        public string? ConditionText { get; set; }
        public string? ConditionIcon { get; set; }
        public decimal? TempC { get; set; }
        public decimal? TempF { get; set; }
    }
}
