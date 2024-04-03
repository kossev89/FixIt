using FixIt.Core.Contracts.Car;
using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Infrastructure.Data.Models;
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

        [HttpGet]
        public async Task<IActionResult> SearchCustomer(string filter)
        {
            var model = await service.SearchIndexAsync(filter);
            if (ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Customer/Index.cshtml", model);
            }
            return View("~/Areas/Admin/Views/Customer/Index.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> CustomerDetails(string id)
        {
            var cutomer = await service.GetCustomerDetailsAsync(id);
            var cars = await service.GetCustomerCarsAsync(id);
            var appointments = await service.GetCustomerApointmentsAsync(id);
            var serviceHistories = await service.GetCustomerServicesAsync(id);

            ViewBag.CustomerData = cutomer;
            ViewBag.CarsData = cars;
            ViewBag.AppointmentsData = appointments;
            ViewBag.ServicesData = serviceHistories;

            return View("~/Areas/Admin/Views/Customer/CustomerDetails.cshtml");
        }

        [HttpGet]
        public IActionResult RegisterCustomer()
        {
            var model = new CustomerFormModel()
            {

            };
            if (ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Customer/RegisterCustomer.cshtml", model);
            }
            return View("~/Areas/Admin/Views/Customer/RegisterCustomer.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(CustomerFormModel model)
        {
            await service.RegisterCustomerAsync(model);
            return RedirectToAction("Index", "Customer");
        }
    }
}
