using AutoMapper;
using AutoMapper.QueryableExtensions;
using FixIt.Core.Contracts.Technician;
using FixIt.Core.Models.Appointment;
using FixIt.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FixIt.Infrastructure.Data.Enumerators;
using FixIt.Infrastructure.Data.Models;
using FixIt.Core.Models.ServiceHistory;

namespace FixIt.Core.Services.Technician
{
    public class TechnicianService : ITechnicianService
    {
        private readonly ApplicationDbContext context;
        private readonly IConfigurationProvider config;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public TechnicianService(
            ApplicationDbContext _context,
            IHttpContextAccessor _httpContextAccessor,
            IConfigurationProvider _config,
            IMapper _mapper
            )
        {
            context = _context;
            config = _config;
            mapper = _mapper;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task AcceptAppointmentAsync(AppointmentViewModel model)
        {
            var entity = await context
                .Appointments
                .FindAsync(model.Id);

            if (entity == null)
            {
                throw new InvalidDataException("Appointment doesn't exist");
            }

            entity.Status = AppointmentStatus.InProgress;
            await context.SaveChangesAsync();
        }

        public async Task CompleteTaskAsync(AppointmentViewModel model)
        {
            var appointmentEntity = await context
                .Appointments
                .FindAsync(model.Id);

            var modelMapped = await context
                .Appointments
                .ProjectTo<AppointmentViewModel>(config)
                .FirstOrDefaultAsync();

            if (appointmentEntity==null)
            {
                throw new InvalidDataException();
            }
            appointmentEntity.Status = AppointmentStatus.Completed;

            var entity = mapper
                .Map<Infrastructure.Data.Models.ServiceHistory>(modelMapped);

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<AppointmentViewModel> GetAppointmentByIdAsync(int id)
        {
            var appointment = await context
                .Appointments
                .AsNoTracking()
                .ProjectTo<AppointmentViewModel>(config)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (!(appointment is AppointmentViewModel))
            {
                throw new InvalidDataException("Appointment does't exist");
            }

            return appointment;
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetMyAppointmentsAsync()
        {
            return await context
              .Appointments
              .AsNoTracking()
              .Where(x => x.Technician.UserId == GetUserId()
              && x.Status == AppointmentStatus.Idle
              && x.DateAndTime >= DateTime.Now
              )
              .ProjectTo<AppointmentViewModel>(config)
              .ToArrayAsync();
        }

        public async Task<IEnumerable<ServiceHistoryViewModel>> GetMyHistoryAsync()
        {
            return await context
             .ServiceHistories
             .AsNoTracking()
             .Where(x => x.Technician.UserId == GetUserId())
             .ProjectTo<ServiceHistoryViewModel>(config)
             .OrderBy(d=>d.Date)
             .ToArrayAsync();
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetTasksAsync()
        {
            return await context
           .Appointments
           .AsNoTracking()
           .Where(x => x.Technician.UserId == GetUserId()
           && x.Status == AppointmentStatus.InProgress
           )
           .ProjectTo<AppointmentViewModel>(config)
           .ToArrayAsync();
        }

        public string GetUserId()
        {
            var userId = httpContextAccessor
            .HttpContext
            .User
            .FindFirst(ClaimTypes.NameIdentifier)?
            .Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("User doesn't exist");
            }

            return userId;
        }
    }
}
