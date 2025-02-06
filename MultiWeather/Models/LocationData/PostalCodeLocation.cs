namespace MultiWeather.Models.LocationData
{
    public class PostalCodeLocation
    {
        public string PostalCode { get; private set; }
        public string PlaceName { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public PostalCodeLocation(string[] data)
        {
            if (!double.TryParse(data[9], out double latitude))
                latitude = 0;
            if (!double.TryParse(data[10], out double longitude))
                longitude = 0;

            PostalCode = data[1];
            PlaceName = data[2];
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
