using FixIt.Core.Contracts.Appointment;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Service;
using FixIt.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;
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
        public async Task BookAsync(AppointmentFormModel model)
        {
            var currentUserId = GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new UnauthorizedAccessException("Authorization error");
            }

            var entity = new Infrastructure.Data.Models.Appointment()
            {
                UserId = currentUserId,
                CarId = model.CarId,
                DateAndTime = model.DateAndTime,
                ServiceId = model.ServiceId,
                Status = Idle
            };

            if (entity == null)
            {
                throw new ArgumentException("Invalid Appointment Information");
            }

            if (entity.DateAndTime.DayOfWeek > LastWorkDay || entity.DateAndTime.Hour < 8 || entity.DateAndTime.Hour > 17)
            {
                throw new ArgumentException("The appointment date is outside working hours");
            }

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
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

        public async Task<IEnumerable<CarViewModel>> GetCarsAsync()
        {
            return await context
                .Cars
                .AsNoTracking()
                .Where(x => x.UserId == GetUserId() && x.IsDeleted == false)
                .Select(e => new CarViewModel()
                {
                    Id = e.Id,
                    PlateNumber = e.PlateNumber
                })
                .OrderBy(p => p.PlateNumber)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<CarViewModel>> GetCarByIdAsync(int id)
        {
            var model = await context
                .Cars
                .AsNoTracking()
                .Where(x => x.UserId == GetUserId() && x.IsDeleted == false && x.Id == id)
                .Select(e => new CarViewModel()
                {
                    Id = e.Id,
                    PlateNumber = e.PlateNumber
                })
                .ToArrayAsync();

            if (model == null)
            {
                throw new ArgumentException("The car doesn't exist");
            }

            return model;
        }

        public async Task<AppointmentViewModel> GetModelByIdAsync(int id)
        {
            var model = await context
                .Appointments
                .AsNoTracking()
                .Where(x => x.Id == id)
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

        public async Task<IEnumerable<ServiceViewModel>> GetServicesAsync()
        {
            return await context
                .Services
                .AsNoTracking()
                .Select(e => new ServiceViewModel()
                {
                    Id = e.Id,
                    Type = e.Type
                })
                .OrderBy(n => n.Type)
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
