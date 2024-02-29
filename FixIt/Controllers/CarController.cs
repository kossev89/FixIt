using Microsoft.AspNetCore.Mvc;

namespace FixIt.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
