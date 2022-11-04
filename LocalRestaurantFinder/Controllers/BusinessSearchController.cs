using LocalRestaurantFinder.Models;
using LocalRestaurantFinder.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LocalRestaurantFinder.Controllers
{
    public class BusinessSearchController : Controller
    {
        public BusinessSearchController(YelpAPIBusinessService businessService)
        {
            BusinessService = businessService; // Note: Dependency injection is used to pass in an instance of the service into the contructor
        }
        public YelpAPIBusinessService BusinessService { get; }

        public async Task<IEnumerable<BusinessModel>> Get(string zipCode)
        {
            IEnumerable<BusinessModel> businesses;
            if (zipCode != null && Regex.Match(zipCode, @"^\d{5}$").Success)
            {
                businesses = await BusinessService.GetBusinesses(zipCode);   
            }
            else
            {
                businesses = new List<BusinessModel>();
            }

            return businesses;
        }
    }
}
