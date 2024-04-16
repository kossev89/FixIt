using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.ServiceHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Core.Contracts.Technician
{
    public interface ITechnicianService
    {
        Task<IEnumerable<AppointmentViewModel>> GetMyAppointmentsAsync();
        string GetUserId();
        Task AcceptAppointmentAsync(AppointmentViewModel model);
        Task<AppointmentViewModel> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<AppointmentViewModel>> GetTasksAsync();
        Task CompleteTaskAsync(AppointmentViewModel model);
        Task<IEnumerable<ServiceHistoryViewModel>> GetMyHistoryAsync();
    }
}
