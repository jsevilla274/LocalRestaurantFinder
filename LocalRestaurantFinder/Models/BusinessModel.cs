using System.Text.Json.Serialization;

namespace LocalRestaurantFinder.Models
{
    public class BusinessModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        [JsonPropertyName("display_phone")]
        public string? PhoneNumber { get; set; }
        public LocationModel? Location { get; set; }
        public double Rating { get; set; }
    }
}
