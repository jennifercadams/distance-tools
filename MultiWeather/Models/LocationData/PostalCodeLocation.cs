namespace MultiWeather.Models.LocationData
{
    public class PostalCodeLocation
    {
        public PostalCodeLocation(string[] data)
        {
            if (!decimal.TryParse(data[9], out decimal latitude))
                latitude = 0;
            if (!decimal.TryParse(data[10], out decimal longitude))
                longitude = 0;
            if (!int.TryParse(data[11], out int accuracy))
                accuracy = 0;

            CountryCode = data[0];
            PostalCode = data[1];
            PlaceName = data[2];
            AdminName1 = data[3];
            AdminCode1 = data[4];
            AdminName2 = data[5];
            AdminCode2 = data[6];
            AdminName3 = data[7];
            AdminCode3 = data[8];
            Latitude = latitude;
            Longitude = longitude;
            Accuracy = accuracy;
        }

        public string CountryCode { get; private set; }
        public string PostalCode { get; private set; }
        public string PlaceName { get; private set; }
        public string AdminName1 { get; private set; }
        public string AdminCode1 { get; private set; }
        public string AdminName2 { get; private set; }
        public string AdminCode2 { get; private set; }
        public string AdminName3 { get; private set; }
        public string AdminCode3 { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public int Accuracy { get; private set; }
    }
}
