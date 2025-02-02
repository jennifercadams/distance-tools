namespace MultiWeather.Models.DTO
{
    public class GetCurrentResponse
    {
        public string? LocationName { get; set; }
        public string? TimeZone { get; set; }
        public string? ConditionText { get; set; }
        public string? ConditionIcon { get; set; }
        public string? Temperature { get; set; }
        public string? Error { get; set; }
    }
}
