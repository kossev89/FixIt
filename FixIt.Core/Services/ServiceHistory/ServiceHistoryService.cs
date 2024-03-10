using FixIt.Core.Contracts.ServiceHistory;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.ServiceHistory;
using FixIt.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Core.Services.ServiceHistory
{
    public class ServiceHistoryService : IServiceHistoryService
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ServiceHistoryService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor)
        {
            context = _context;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<IEnumerable<ServiceHistoryViewModel>> GetAllAsync()
        {
            return await context
                .ServiceHistories
                .AsNoTracking()
                .Where(x => x.Car.UserId == GetUserId())
                .Select(e => new ServiceHistoryViewModel()
                {
                    Id = e.Id,
                    CarId = e.CarId,
                    Car = new CarViewModel()
                    {
                        Make = e.Car.Make,
                        Model = e.Car.Model,
                        PlateNumber = e.Car.PlateNumber,
                        Mileage = e.Mileage
                    },
                    ServiceId = e.ServiceId,
                    Service = new Models.Service.ServiceViewModel()
                    {
                        Type = e.Service.Type,
                        Price = e.Service.Price
                    },
                    TechnicianId = e.TechnicianId,
                    Technician = new Models.Technician.TechnicianViewModel()
                    {
                        Name = e.Technician.Name,
                        Specialization = e.Technician.Specialization.ToString()
                    },
                    Date = e.Date
                })
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
