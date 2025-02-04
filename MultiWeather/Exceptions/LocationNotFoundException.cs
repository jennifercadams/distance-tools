namespace MultiWeather.Exceptions
{
    public class LocationNotFoundException : Exception
    {
        private const string ErrorMessage = "Location not found for postal code {0}";

        public LocationNotFoundException(string postalCode)
            : base(string.Format(ErrorMessage, postalCode)) { }
    }
}
