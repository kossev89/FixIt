using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Core.Contracts.Appointment
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentViewModel>> GetAllAsync();
        Task BookAsync(AppointmentFormModel model);
        Task CancelAsync(AppointmentViewModel model);
        string GetUserId();
        Task<AppointmentViewModel> GetModelByIdAsync(int id);
        Task<IEnumerable<CarViewModel>> GetCars();
        Task<IEnumerable<ServiceViewModel>> GetServices();

    }
}
