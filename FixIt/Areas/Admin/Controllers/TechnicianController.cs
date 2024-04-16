using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.Technician;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class TechnicianController : Controller
    {
        private readonly IAdminService service;
        public TechnicianController(IAdminService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await service.GetAllTechniciansAsync();
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Technician/Index.cshtml", model);
                }
                return View("~/Areas/Admin/Views/Technician/Index.cshtml");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            try
            {
                var model = new CustomerFormModel()
                {

                };
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Technician/RegisterUser.cshtml", model);
                }
                return View("~/Areas/Admin/Views/Technician/RegisterUser.cshtml");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CustomerFormModel model)
        {
            try
            {
                await service.RegisterTechnicianUserAsync(model);
                var userId = await service.GetTechnicinUserIdAsync(model.Email);
                return RedirectToAction("AddInfo", new { userId = userId });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult AddInfo(string userId)
        {
            try
            {
                var model = new TechnicianFormModel()
                {
                    UserId = userId
                };
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Technician/AddInfo.cshtml", model);
                }
                return View("~/Areas/Admin/Views/Technician/AddInfo.cshtml");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddInfo(TechnicianFormModel model)
        {
            try
            {
                await service.AddTechnicianInfoAsync(model);
                return RedirectToAction("Index", "Technician");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await service
                    .GetTechnicianViewModelAsync(id);

                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Technician/Delete.cshtml", model);
                }
                else
                {
                    return View("~/Areas/Admin/Views/Technician/Index.cshtml");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(TechnicianViewModel viewModel)
        {
            try
            {
                await service
                    .DeleteTechnicianAsync(viewModel);
                return RedirectToAction("Index", "Technician");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
