using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Technician;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AppointmentAdminController : Controller
    {
        private readonly IAdminService service;
        public AppointmentAdminController(IAdminService _service)
        {
            service = _service;
        }

        /// <summary>
        /// All appointments
        /// </summary>
        /// <returns>All appointments</returns>
        /// 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await service.GetAllAppointmentsAsync();
            if (ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/AppointmentAdmin/Index.cshtml", model);
            }
            return View("~/Areas/Admin/Views/AppointmentAdmin/Index.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> AppointTechnician(int id)
        {
            try
            {
                var appointment = await service.GetAppointmentAsync(id);
                ViewBag.AppointmentData = appointment;
                var model = await service.GetAllTechniciansAsync();
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/AppointmentAdmin/AppointTechnician.cshtml", model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AppointTechnician(int id, TechnicianViewModel model)
        {
            try
            {
                await service.AppointTechnicianAsync(id, model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
