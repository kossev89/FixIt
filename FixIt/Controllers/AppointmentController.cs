using FixIt.Core.Contracts.Appointment;
using FixIt.Core.Contracts.Car;
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
        public async Task<IActionResult> Index()
        {
            var model = await service.GetAllAsync();
            return View(model);
        }
    }
}
