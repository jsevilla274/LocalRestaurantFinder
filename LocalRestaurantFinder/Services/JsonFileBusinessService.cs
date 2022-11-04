using System.Net.Http.Headers;
using System.Text.Json;
using LocalRestaurantFinder.Models;

namespace LocalRestaurantFinder.Services
{
    public class JsonFileBusinessService
    {
        public string JsonFileName
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "businesses.json"); }
        }

        public IEnumerable<BusinessModel> GetBusinesses()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                JsonRootObjectModel rootObject = JsonSerializer.Deserialize<JsonRootObjectModel>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                return rootObject.Businesses;
            }
        }
    }
}
