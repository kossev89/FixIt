using FixIt.Core.Contracts.Appointment;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Infrastructure.Data;
using FixIt.Infrastructure.Data.Enumerators;
using FixIt.Infrastructure.Data.Models;
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

        public async Task CancelAsync(AppointmentViewModel model)
        {
            var entity = await context
            .Appointments
            .FindAsync(model.Id);

            if (entity == null || entity.Status == Canceled)
            {
                throw new ArgumentException("Appointment not found!");
            }

            if (entity.UserId != GetUserId())
            {
                throw new UnauthorizedAccessException("Acces not granted");
            }

            entity.Status = Canceled;
            await context.SaveChangesAsync();
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

        public async Task<AppointmentViewModel> GetModelByIdAsync(int id)
        {
            var model = await context
                .Appointments
                .AsNoTracking()
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
                .FirstOrDefaultAsync();

            if (model == null || model.Status == Canceled)
            {
                throw new ArgumentException("Appointment not found!");
            }

            if (model.UserId != GetUserId())
            {
                throw new UnauthorizedAccessException("Access not granted");
            }

            return model;

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
