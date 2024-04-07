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

        /// <summary>
        /// Adds a car to the user
        /// </summary>

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CarFormModel()
            {

            };
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel model)
        {
            await service.AddAsync(model);
            return RedirectToAction("Index", "Car");
        }

        /// <summary>
        /// Gets the details of a car
        /// </summary>

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await service.GetDetailsAsync(id);
            return View(model);
        }

        /// <summary>
        /// Updates car's information
        /// </summary>

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        { 
            var model = await service.GetFormByIdAsync(id);
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarFormModel model)
        {
            await service.UpdateAsync(model);
            return RedirectToAction("Details", "Car", new { id = model.UserId});
        }

        /// <summary>
        /// Deletes a car
        /// </summary>

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await service.GetModelByIdAsync(id);

            if (ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(CarViewModel model)
        {
            await service.DeleteAsync(model);
            return RedirectToAction("Index", "Car");
        }

    }
}
