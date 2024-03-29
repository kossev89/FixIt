using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Customer;
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
    }
}
