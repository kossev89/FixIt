using FixIt.Core.Contracts.Appointment;
using FixIt.Core.Contracts.ServiceHistory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Controllers
{
    [Authorize]
    public class ServiceHistoryController : Controller
    {
        private readonly IServiceHistoryService service;
        public ServiceHistoryController(IServiceHistoryService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await service.GetAllAsync();
            return View(model);
        }
    }
}
