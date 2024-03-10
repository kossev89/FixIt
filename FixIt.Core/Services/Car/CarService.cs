using FixIt.Core.Contracts.Car;
using FixIt.Core.Models.Car;
using FixIt.Infrastructure.Data;
using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task DeleteAsync(CarViewModel model)
        {
            var entity = await context
                .Cars
                .FindAsync(model.Id);

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("The car does not exist");
            }

            if (entity.UserId != GetUserId())
            {
                throw new UnauthorizedAccessException("Acces not granted");
            }

            entity.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarViewModel>> GetAllAsync()
        {
            return await context
                .Cars
                .AsNoTracking()
                .Where(x => x.UserId == GetUserId() && x.IsDeleted == false)
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

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("The car does not exist");
            }

            if (entity.UserId != GetUserId())
            {
                throw new UnauthorizedAccessException("Acces not granted");
            }


            return new CarDetailedViewModel()
            {
                Id = entity.Id,
                Make = entity.Make,
                Model = entity.Model,
                Year = entity.Year,
                PlateNumber = entity.PlateNumber,
                Vin = entity.Vin,
                Mileage = entity.Mileage,
                ImageUrl = entity.ImageUrl
            };
        }

        public async Task<CarFormModel> GetFormByIdAsync(int id)
        {
            var entity = await context
                .Cars
                .FindAsync(id);

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("The car doesn't exist!");
            }

            if (entity.UserId != GetUserId())
            {
                throw new UnauthorizedAccessException("Access not granted");
            }

            return new CarFormModel()
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                Mileage = entity.Mileage,
                PlateNumber = entity.PlateNumber,
                Vin = entity.Vin
            };
        }

        public async Task<CarViewModel> GetModelByIdAsync(int id)
        {
            var entity = await context
            .Cars
            .FindAsync(id);

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("The car doesn't exist!");
            }

            if (entity.UserId != GetUserId())
            {
                throw new UnauthorizedAccessException("Access not granted");
            }

            return new CarViewModel()
            {
                Id = entity.Id,
                Make = entity.Make,
                Model = entity.Model,
                ImageUrl = entity.ImageUrl
            };
        }

        public string GetUserId()
        {
            var userId= httpContextAccessor
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

        public async Task UpdateAsync(CarFormModel model)
        {
            var entity = await context
                .Cars
                .FindAsync(model.Id);

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("The car doesn't exist!");
            }

            if (entity.UserId != GetUserId())
            {
                throw new UnauthorizedAccessException("Access not granted");
            }

            entity.PlateNumber = model.PlateNumber;
            entity.ImageUrl = model.ImageUrl;
            if (entity.Mileage > model.Mileage)
            {
                throw new ArgumentException($"The new Mileage should be more or equal to {entity.Mileage}");
            }
            entity.Mileage = model.Mileage;
            entity.Vin = model.Vin;

            await context.SaveChangesAsync();
        }
    }
}
