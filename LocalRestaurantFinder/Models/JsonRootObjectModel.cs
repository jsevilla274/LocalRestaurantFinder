namespace LocalRestaurantFinder.Models
{
    public class JsonRootObjectModel
    {
        public IEnumerable<BusinessModel>? Businesses { get; set; }
        public int Total { get; set; }
        //public Region { get; set; } 
    }
}
