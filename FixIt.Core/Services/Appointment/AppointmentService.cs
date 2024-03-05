using FixIt.Core.Contracts.Appointment;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static FixIt.Infrastructure.Data.Enumerators.AppointmentStatus;

namespace FixIt.Core.Services.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AppointmentService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor)
        {
            context = _context;
            httpContextAccessor = _httpContextAccessor;
        }
        public Task BookAsync(AppointmentFormModel model)
        {
            throw new NotImplementedException();
        }

        public Task CancelAsync(AppointmentViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetAllAsync()
        {
            return await context
                .Appointments
                .AsNoTracking()
                .Where(x => x.UserId == GetUserId() && x.Status != Canceled)
                .Select(e => new AppointmentViewModel()
                {
                    Id = e.Id,
                    UserId = e.UserId,
                    CarId = e.CarId,
                    CarMake = e.Car.Make,
                    CarModel = e.Car.Model,
                    CarRegPlate = e.Car.PlateNumber,
                    ServiceId = e.ServiceId,
                    ServiceType = e.Service.Type.ToString(),
                    TechnicianId = e.TechnicianId,
                    TechnicianName = e.Technician.Name,
                    DateAndTime = e.DateAndTime,
                    Status = e.Status
                })
                .ToArrayAsync();
        }

        public string GetUserId()
        {
            return httpContextAccessor
               .HttpContext
               .User
               .FindFirst(ClaimTypes.NameIdentifier)?
               .Value;
        }
    }
}
