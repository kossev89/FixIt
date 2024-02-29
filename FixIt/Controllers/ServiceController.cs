using Microsoft.AspNetCore.Mvc;

namespace FixIt.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
