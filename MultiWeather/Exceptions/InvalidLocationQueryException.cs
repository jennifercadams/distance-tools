namespace MultiWeather.Exceptions
{
    public class InvalidLocationQueryException : Exception
    {
        private const string ErrorMessage = "Invalid location query: {0}";

        public InvalidLocationQueryException(string query)
            : base(string.Format(ErrorMessage, query)) { }
    }
}
