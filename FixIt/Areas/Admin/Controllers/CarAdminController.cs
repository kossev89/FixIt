using FixIt.Core.Contracts.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CarAdminController : Controller
    {

        private readonly IAdminService service;
        public CarAdminController(IAdminService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await service.GetAllCarsAsync();
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Car/Index.cshtml", model);
                }
                return View("~/Areas/Admin/Views/Car/Index.cshtml");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> CarDetails(int id)
        {
            try
            {
                var model = await service.GetCarDetailsAsync(id);
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Car/CarDetails.cshtml", model);
                }
                return RedirectToAction("Index", "CarAdmin");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> CarHistory(int id)
        {
            try
            {
                var model = await service.GetCarHistory(id);
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Car/CarHistory.cshtml", model);
                }
                return RedirectToAction("CarDetails", "CarAdmin");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
