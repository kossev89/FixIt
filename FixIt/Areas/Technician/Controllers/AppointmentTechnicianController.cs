using FixIt.Core.Contracts.Car;
using FixIt.Core.Contracts.Technician;
using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Areas.Technician.Controllers
{
    [Authorize(Roles = "Technician")]
    public class AppointmentTechnicianController : Controller
    {

        private readonly ITechnicianService service;
        private readonly IAdminService adminService;
        public AppointmentTechnicianController(
            ITechnicianService _service,
            IAdminService _adminService
            )
        {
            service = _service;
            adminService = _adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await service.GetMyAppointmentsAsync();
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Technician/Views/AppointmentTechnician/Index.cshtml", model);
                }
                return View("~/Areas/Admin/Views/AppointmentAdmin/Index.cshtml");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Accept(int id)
        {
            try
            {
                var model = await service.GetAppointmentByIdAsync(id);

                if (ModelState.IsValid)
                {
                    return View("~/Areas/Technician/Views/AppointmentTechnician/Accept.cshtml", model);
                }
                else
                {
                    return View("~/Areas/Technician/Views/AppointmentTechnician/Accept.cshtml");
                }
            }
            catch (Exception)
            {
                return BadRequest("Wrong data!"); ;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AcceptConfirmed(AppointmentViewModel model)
        {
            try
            {
                await service.AcceptAppointmentAsync(model);
                return RedirectToAction("Tasks");
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Tasks()
        {
            try
            {
                var model = await service.GetTasksAsync();
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Technician/Views/AppointmentTechnician/Tasks.cshtml", model);
                }
                return View("~/Areas/Admin/Views/AppointmentAdmin/Index.cshtml");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Complete(int id)
        {
            try
            {
                var model = await service.GetAppointmentByIdAsync(id);

                if (ModelState.IsValid)
                {
                    return View("~/Areas/Technician/Views/AppointmentTechnician/Complete.cshtml", model);
                }
                else
                {
                    return View("~/Areas/Technician/Views/AppointmentTechnician/Complete.cshtml");
                }
            }
            catch (Exception)
            {
               throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CompleteConfirmed(AppointmentViewModel model)
        {
            try
            {
                var carModel = await adminService.GetCarDetailsAsync(model.CarId);
                var serviceModel = await adminService.GetServiceViewModelAsync(model.ServiceId);
                var technicianModel = await adminService.GetTechnicianViewModelAsync(model.TechnicianId);
                model.Car = carModel;
                model.Service = serviceModel;
                model.Technician = technicianModel;
                await service.CompleteTaskAsync(model);
                return RedirectToAction("History");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> History()
        {
            try
            {
                var model = await service.GetMyHistoryAsync();
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Technician/Views/AppointmentTechnician/History.cshtml", model);
                }
                return View("~/Areas/Technician/Views/AppointmentTechnician/History.cshtml");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
