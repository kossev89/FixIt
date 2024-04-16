using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Service;
using FixIt.Core.Models.Technician;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ServiceAdminController : Controller
    {
        private readonly IAdminService service;
        public ServiceAdminController(IAdminService _service)
        {
            service = _service;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await service.GetServicesAsync();
            if (ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/ServiceAdmin/Index.cshtml", model);
            }
            return View("~/Areas/Admin/Views/AppointmentAdmin/Index.cshtml");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ServiceFormModel()
            {

            };
            if (ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/ServiceAdmin/Add.cshtml", model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServiceFormModel model)
        {
            await service.AddServiceAsync(model);
            return RedirectToAction("Index", "ServiceAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await service.GetServiceFormAsync(id);
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/ServiceAdmin/Edit.cshtml", model);
                }
                return View("~/Areas/Admin/Views/ServiceAdmin/Edit.cshtml");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceFormModel model)
        {
            try
            {
                await service.EditServiceAsync(model);
                return RedirectToAction("Index", "ServiceAdmin");
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
                    .GetServiceViewModelAsync(id);

                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/ServiceAdmin/Delete.cshtml", model);
                }
                else
                {
                    return View("~/Areas/Admin/Views/ServiceAdmin/Index.cshtml");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(ServiceViewModel model)
        {
            try
            {
                await service
                    .DeleteServiceAsync(model);
                return RedirectToAction("Index", "ServiceAdmin");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
