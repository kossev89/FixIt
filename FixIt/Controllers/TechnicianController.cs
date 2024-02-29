using Microsoft.AspNetCore.Mvc;

namespace FixIt.Controllers
{
    public class TechnicianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
