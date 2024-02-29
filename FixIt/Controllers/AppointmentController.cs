using Microsoft.AspNetCore.Mvc;

namespace FixIt.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
