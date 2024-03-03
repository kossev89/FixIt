using FixIt.Core.Contracts.Car;
using FixIt.Core.Models.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService service;
        public CarController(ICarService _service)
        {
            service = _service;
        }

        /// <summary>
        /// All cars
        /// </summary>
        /// <returns> All cars, owned by the user </returns>
        /// 

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await service.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CarFormModel()
            {

            };
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel model)
        {
            await service.AddAsync(model);
            return RedirectToAction("Index", "Car");
        }
    }
}
