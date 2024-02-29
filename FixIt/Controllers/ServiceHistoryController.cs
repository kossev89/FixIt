using Microsoft.AspNetCore.Mvc;

namespace FixIt.Controllers
{
    public class ServiceHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
