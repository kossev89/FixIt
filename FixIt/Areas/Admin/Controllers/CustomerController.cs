using FixIt.Core.Contracts.Car;
using FixIt.Core.Contracts.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CustomerController : Controller
    {
        private readonly IAdminService service;
        public CustomerController(IAdminService _service)
        {
            service = _service;
        }

        /// <summary>
        /// All cutomers
        /// </summary>
        /// <returns>All users in role "Customer"</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await service.GetAllCustomersAsync();
            if (ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Customer/Index.cshtml", model);
            }
            return View("~/Areas/Admin/Views/Customer/Index.cshtml");
        }
    }
}
