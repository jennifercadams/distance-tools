using MultiWeather.Models.LocationData;

namespace MultiWeather.Services.LocationService
{
    public static class LocationDataCollection
    {
        public static Dictionary<string, string> CountryNameList { get; }
        public static Dictionary<string, Country> Countries { get; }

        static LocationDataCollection()
        {
            var root = Directory.GetCurrentDirectory();
            var countryNames = LoadCountryNames(root);
            var countries = LoadCountryData(root, countryNames);

            CountryNameList = countryNames;
            Countries = countries;
        }

        private static Dictionary<string, string> LoadCountryNames(string root)
        {
            var countryNames = new Dictionary<string, string>();

            var path = Path.Combine(root, "Resources", "CountryNames.txt");

            foreach (var line in File.ReadLines(path))
            {
                var data = line.Split('\t');
                countryNames.Add(data[0], data[1]);
            }

            return countryNames;
        }

        private static Dictionary<string, Country> LoadCountryData(string root, Dictionary<string, string> countryNames)
        {
            var countries = new Dictionary<string, Country>();

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
