using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.Service;
using FixIt.Core.Models.ServiceHistory;
using FixIt.Core.Models.Technician;

namespace FixIt.Core.Contracts.User
{
    public interface IAdminService
    {
        //Customer manipulation from the Admin User
        Task<IEnumerable<CustomerViewModel>> SearchIndexAsync(string filter);
        Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync();
        Task<CustomerViewModel> GetCustomerDetailsAsync(string id);
        Task RegisterCustomerAsync(CustomerFormModel model);
        Task EditCustomerAsync(CustomerFormModel model);

        //Car manupulation from the Admin User
        Task<CarFormModel> GetCustomerCarFormAsync(string cutomerId, int carId);
        Task<CarViewModel> GetCustomerCarViewAsync(string cutomerId, int carId);
        Task<IEnumerable<CarViewModel>> GetCustomerCarsViewAsync(string cutomerId);
        Task EditCustomerCarAsync(CarFormModel model);
        Task<IEnumerable<CarDetailedViewModel>> GetCustomerCarsAsync(string id);
        Task AddCarAsync(CarFormModel model);
        Task DeleteAsync(CarViewModel model);
        Task<IEnumerable<CarViewModel>> GetAllCarsAsync();
        Task<CarDetailedViewModel> GetCarDetailsAsync(int id);

        //Appointment manupulation from the Admin User
        Task<IEnumerable<AppointmentViewModel>> GetAllAppointmentsAsync();
        Task<AppointmentViewModel> GetAppointmentAsync(int id);
        Task<IEnumerable<AppointmentViewModel>> GetCustomerApointmentsAsync(string id);
        Task BookAsync(AppointmentFormModel model);

        //Technician manupulation from the Admin User
        Task<IEnumerable<TechnicianViewModel>> GetAllTechniciansAsync();
        Task AppointTechnicianAsync(int appointmentId, TechnicianViewModel model);
        Task RegisterTechnicianUserAsync(CustomerFormModel model);
        Task AddTechnicianInfoAsync(TechnicianFormModel model);
        Task <string> GetTechnicinUserIdAsync(string email);
        Task<TechnicianViewModel> GetTechnicianViewModelAsync(int id);
        Task DeleteTechnicianAsync(TechnicianViewModel model);

        //Service manupulation from the Admin User
        Task<IEnumerable<ServiceHistoryViewModel>> GetCustomerServicesAsync(string id);
        Task<IEnumerable<ServiceViewModel>> GetServicesAsync();
        Task<IEnumerable<ServiceHistoryViewModel>> GetCarHistory(int id);
        Task AddServiceAsync(ServiceFormModel model);
    }
}
