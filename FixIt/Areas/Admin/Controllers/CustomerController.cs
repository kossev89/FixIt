
using FixIt.Core.Contracts.Car;
using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.Technician;
using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            try
            {
                var model = await service.GetAllCustomersAsync();
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Customer/Index.cshtml", model);
                }
                return View("~/Areas/Admin/Views/Customer/Index.cshtml");
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchCustomer(string filter)
        {
            try
            {
                var model = await service.SearchIndexAsync(filter);
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Customer/Index.cshtml", model);
                }
                return View("~/Areas/Admin/Views/Customer/Index.cshtml");
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CustomerDetails(string id)
        {
            try
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
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpGet]
        public IActionResult RegisterCustomer()
        {
            try
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
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(CustomerFormModel model)
        {
            try
            {
                await service.RegisterCustomerAsync(model);
                return RedirectToAction("Index", "Customer");
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditCustomerCar(string customerId, int carId)
        {
            try
            {
                var model = await service.GetCustomerCarFormAsync(customerId, carId);
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Customer/EditCustomerCar.cshtml", model);
                }
                return View("~/Areas/Admin/Views/Customer/EditCustomerCar.cshtml");
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomerCar(CarFormModel model)
        {
            try
            {
                await service.EditCustomerCarAsync(model);
                return RedirectToAction("CustomerDetails", new { id = model.UserId });
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpGet]
        public IActionResult AddCar(string id)
        {
            try
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
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarFormModel model)
        {
            try
            {
                await service.AddCarAsync(model);
                return RedirectToAction("CustomerDetails", new { id = model.UserId });
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string customerId, int carId)
        {
            try
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
            catch (Exception)
            {
                return BadRequest("Wrong data!"); ;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(CarViewModel viewModel)
        {
            try
            {
                await service.DeleteAsync(viewModel);
                return RedirectToAction("CustomerDetails", new { id = viewModel.UserId });
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BookToCar(string customerId, int carId)
        {
            try
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
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Book(string customerId)
        {
            try
            {
                var model = new AppointmentFormModel()
                {
                    ServiceList = await service.GetServicesAsync(),
                    CarList = await service.GetCustomerCarsViewAsync(customerId),
                    UserId = customerId
                };
                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Customer/BookToCar.cshtml", model);
                }
                return RedirectToAction("CustomerDetails", new { id = model.UserId });
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            };
        }

        [HttpPost]
        public async Task<IActionResult> BookConfirmed(AppointmentFormModel model)
        {
            try
            {
                await service.BookAsync(model);
                return RedirectToAction("CustomerDetails", new { id = model.UserId });
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
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
                    return View("~/Areas/Admin/Views/Customer/AppointTechnician.cshtml", model);
                }
                return RedirectToAction("CustomerDetails");
            }
            catch (Exception)
            {
                return BadRequest("Wrong data!");
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

                return BadRequest("Wrong data!");
            }
        }

        [HttpGet]
        public IActionResult EditCustomer(string id)
        {
            try
            {
                var model = new CustomerFormModel()
                {
                    Id = id
                };

                if (ModelState.IsValid)
                {
                    return View("~/Areas/Admin/Views/Customer/EditCustomer.cshtml", model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(CustomerFormModel model)
        {
            try
            {
                await service.EditCustomerAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return BadRequest("Wrong data!");
            }
        }

    }
}
