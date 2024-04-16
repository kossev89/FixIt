
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FixIt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error 400");
            }
            if (statusCode == 401)
            {
                return View("Error 401");
            }
            return View();
        }
    }
}
