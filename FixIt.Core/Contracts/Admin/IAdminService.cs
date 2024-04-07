using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.ServiceHistory;
using FixIt.Core.Models.Technician;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Core.Contracts.User
{
    public interface IAdminService
    {
        Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync();
        Task<IEnumerable<AppointmentViewModel>> GetAllAppointmentsAsync();
        Task<IEnumerable<TechnicianViewModel>> GetAllTechniciansAsync();
        Task<IEnumerable<CustomerViewModel>> SearchIndexAsync(string filter);
        Task<CustomerViewModel> GetCustomerDetailsAsync(string id);
        Task<IEnumerable<CarDetailedViewModel>> GetCustomerCarsAsync(string id);
        Task<IEnumerable<AppointmentViewModel>> GetCustomerApointmentsAsync(string id);
        Task<IEnumerable<ServiceHistoryViewModel>> GetCustomerServicesAsync(string id);
        Task RegisterCustomerAsync(CustomerFormModel model);
        Task <CarFormModel> GetCustomerCarAsync(string cutomerId, int carId);
        Task EditCustomerCarAsync(CarFormModel model);
        Task AddCarAsync(CarFormModel model);
    }
}
