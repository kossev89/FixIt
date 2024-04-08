using FixIt.Core.Contracts.Car;
using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Appointment;
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

        [HttpGet]
        public async Task<IActionResult> EditCustomerCar(string customerId, int carId)
        {
            var model = await service.GetCustomerCarFormAsync(customerId, carId);
            if (ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Customer/EditCustomerCar.cshtml", model);
            }
            return View("~/Areas/Admin/Views/Customer/EditCustomerCar.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomerCar(CarFormModel model)
        {
            await service.EditCustomerCarAsync(model);
            return RedirectToAction("CustomerDetails", new { id = model.UserId });
        }

        [HttpGet]
        public IActionResult AddCar(string id)
        {
            var model = new CarFormModel()
            {
                UserId = id
            };
            if (ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Customer/AddCar.cshtml", model);
            }
            return View("~/Areas/Admin/Views/Customer/AddCar.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarFormModel model)
        {
            await service.AddCarAsync(model);
            return RedirectToAction("CustomerDetails", new { id = model.UserId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string customerId, int carId)
        {
            var model = await service.GetCustomerCarViewAsync(customerId, carId);

            if (ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Customer/Delete.cshtml", model);
            }
            else
            {
                return View("~/Areas/Admin/Views/Customer/Delete.cshtml");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(CarViewModel viewModel)
        {
            await service.DeleteAsync(viewModel);
            return RedirectToAction("CustomerDetails", new { id = viewModel.UserId });
        }

        [HttpGet]
        public async Task<IActionResult> BookToCar(string customerId, int carId)
        {
            var model = new AppointmentFormModel()
            {
                ServiceList = await service.GetServicesAsync(),
                CarList = new CarViewModel[] { await service.GetCustomerCarViewAsync(customerId, carId) },
                UserId = customerId
            };
            if (ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Customer/BookToCar.cshtml", model);
            }
            return RedirectToAction("CustomerDetails", new { id = model.UserId });
        }

        [HttpPost]
        public async Task<IActionResult> BookConfirmed(AppointmentFormModel model)
        {
            await service.BookAsync(model);
            return RedirectToAction("CustomerDetails", new { id = model.UserId });
        }
    }
}
