using System.Text.Json.Serialization;

namespace LocalRestaurantFinder.Models
{
    public class LocationModel
    {
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        [JsonPropertyName("display_address")]
        public IEnumerable<string>? DisplayAddress { get; set; }
    }
}
