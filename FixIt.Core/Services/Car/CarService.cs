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
                Model = model.CarModel,
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

        public async Task<CarDetailedViewModel> GetDetailsAsync(int id)
        {
            var entity = await context
                .Cars
                .FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("The car doesn't exist!");
            }

            if (entity.UserId!=GetUserId())
            {
                throw new UnauthorizedAccessException("Access not granted");
            }

            return new CarDetailedViewModel()
            {
                Id=entity.Id,
                Make = entity.Make,
                Model = entity.Model,
                Year = entity.Year,
                PlateNumber = entity.PlateNumber,
                Vin = entity.Vin,
                Mileage = entity.Mileage,
                ImageUrl = entity.ImageUrl
            };
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
