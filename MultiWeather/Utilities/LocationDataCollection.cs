using MultiWeather.Models.LocationData;

namespace MultiWeather.Utilities
{
    public static class LocationDataCollection
    {
        static LocationDataCollection()
        {
            Countries = LoadData();
        }

        public static Dictionary<string, Country> Countries { get; }

        private static Dictionary<string, Country> LoadData()
        {
            var countries = new Dictionary<string, Country>();

            var root = Directory.GetCurrentDirectory();
            var directory = Path.Combine(root, "Resources", "PostalCodeData");
            var filePaths = Directory.GetFiles(directory);

            foreach (var path in filePaths)
            {
                var countryCode = Path.GetFileNameWithoutExtension(path);
                var country = new Country(countryCode);

                foreach (var line in File.ReadLines(path))
                {
                    var data = line.Split('\t');

                    try
                    {
                        var location = new PostalCodeLocation(data);
                        country.Locations.Add(location);
                    }
                    catch
                    {
                        continue;
                    }
                }

                countries.Add(countryCode, country);
            }

            return countries;
        }

    }
}
