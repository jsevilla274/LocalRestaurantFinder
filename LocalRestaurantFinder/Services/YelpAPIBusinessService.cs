using System.Net.Http.Headers;
using System.Text.Json;
using LocalRestaurantFinder.Models;

namespace LocalRestaurantFinder.Services
{
    public class YelpAPIBusinessService
    {
        public YelpAPIBusinessService(IConfiguration config)
        {
            _config = config; // Note: allows us to access values from appsettings.json
        }

        private IConfiguration _config;

        public string BusinessSearchEndpointURL
        {
            get { return "https://api.yelp.com/v3/businesses/search"; }
        }

        public async Task<IEnumerable<BusinessModel>> GetBusinesses(string zipCode)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Local Restaurant Finder");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_config.GetValue<string>("APIKey")}");

                var json = await client.GetStringAsync($"{BusinessSearchEndpointURL}?location={zipCode}");
                JsonRootObjectModel rootObject = JsonSerializer.Deserialize<JsonRootObjectModel>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return rootObject.Businesses;
            }
        }
    }
}
