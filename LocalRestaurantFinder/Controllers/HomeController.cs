using LocalRestaurantFinder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LocalRestaurantFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(); // Note: View method searches for corresponding Index.cshtml
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}