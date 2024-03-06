using FixIt.Core.Contracts.Appointment;
using FixIt.Core.Contracts.Car;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService service;
        public AppointmentController(IAppointmentService _service)
        {
            service = _service;
        }

        /// <summary>
        /// Gets All Appoitnments of the customer
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var model = await service.GetAllAsync();
            return View(model);
        }
        /// <summary>
        /// Cancels an Appoingment
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Cancel(int id)
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
        public async Task<IActionResult> CancelConfirmed(AppointmentViewModel model)
        {
            await service.CancelAsync(model);
            return RedirectToAction("Index", "Appointment");
        }
    }
}
