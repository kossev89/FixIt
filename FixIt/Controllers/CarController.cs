using FixIt.Models.Car;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Controllers
{
    public class CarController : Controller
    {
        /// <summary>
        /// All cars
        /// </summary>
        /// <returns> All cars, owned by the user </returns>
        public IActionResult Index(IEnumerable<CarViewModel> model)
        {
            return View(model);
        }
    }
}
