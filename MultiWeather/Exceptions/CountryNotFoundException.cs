namespace MultiWeather.Exceptions
{
    public class CountryNotFoundException : Exception
    {
        private const string ErrorMessage = "Country not found for country code {0}";

        public CountryNotFoundException(string countryCode)
            : base(string.Format(ErrorMessage, countryCode)) { }
    }
}
