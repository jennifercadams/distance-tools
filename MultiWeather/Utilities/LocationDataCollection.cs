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
            var countryNames = new Dictionary<string, string>();
            var countries = new Dictionary<string, Country>();

            var root = Directory.GetCurrentDirectory();
            var countryNameFilePath = Path.Combine(root, "Resources", "CountryNames.txt");

            foreach (var line in File.ReadLines(countryNameFilePath))
            {
                var data = line.Split('\t');
                countryNames.Add(data[0], data[1]);
            }

            var directory = Path.Combine(root, "Resources", "PostalCodeData");
            var filePaths = Directory.GetFiles(directory);

            foreach (var path in filePaths)
            {
                var countryCode = Path.GetFileNameWithoutExtension(path);
                var countryName = countryNames[countryCode];
                var country = new Country(countryCode, countryName);

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
