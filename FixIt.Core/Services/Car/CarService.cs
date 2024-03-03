using FixIt.Core.Contracts.Car;
using FixIt.Core.Models.Car;
using FixIt.Infrastructure.Data;
using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Core.Services.Car
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        public CarService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor)
        {
            context = _context;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task AddAsync(CarFormModel model)
        {
            var currentUserId = GetUserId();
            if (string.IsNullOrEmpty(currentUserId))
            {
                throw new UnauthorizedAccessException("Authorization error");
            }

            var entity = new Infrastructure.Data.Models.Car()
            {
                Make = model.Make,
                Model = model.Model,
                Year = model.Year,
                PlateNumber = model.PlateNumber,
                Vin = model.Vin,
                Mileage = model.Mileage,
                UserId = currentUserId,
                ImageUrl = model.ImageUrl
            };

            if (entity == null)
            {
                throw new ArgumentException("Invalid Car Information");
            }

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarViewModel>> GetAllAsync()
        {
            return await context
                .Cars
                .AsNoTracking()
                .Where(x => x.UserId == GetUserId())
                .Select(e => new CarViewModel()
                {
                    Id = e.Id,
                    Make = e.Make,
                    Model = e.Model,
                    ImageUrl = e.ImageUrl,
                    PlateNumber = e.PlateNumber
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
