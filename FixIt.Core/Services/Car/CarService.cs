using AutoMapper;
using AutoMapper.QueryableExtensions;
using FixIt.Core.Contracts.Car;
using FixIt.Core.Models.Car;
using FixIt.Core.Profiles;
using FixIt.Infrastructure.Data;
using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FixIt.Core.Services.Car
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfigurationProvider config;
        public CarService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor, IConfigurationProvider _config)
        {
            context = _context;
            httpContextAccessor = _httpContextAccessor;
            config = _config;
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
                .Where(x => x.UserId == GetUserId() && x.IsDeleted == false)
                .AsNoTracking()
                .ProjectTo<CarViewModel>(config)
                .ToListAsync();
        }

        public async Task<CarDetailedViewModel> GetDetailsAsync(int id)
        {
            var car = await context
                .Cars
                .Where(x => x.UserId == GetUserId() && x.IsDeleted == false)
                .ProjectTo<CarDetailedViewModel>(config)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (car is CarDetailedViewModel == false)
            {
                throw new ArgumentException("Car does not exist");
            }
            return car;
        }

        public async Task<CarFormModel> GetFormByIdAsync(int id)
        {
            var carForm = await context
                .Cars
                .Where(x => x.UserId == GetUserId() && x.IsDeleted == false)
                .ProjectTo<CarFormModel>(config)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (carForm is CarFormModel == false)
            {
                throw new ArgumentException("Car does not exist");
            }
            return carForm;
        }

        public async Task<CarViewModel> GetModelByIdAsync(int id)
        {
            var carView = await context
                .Cars
                .Where(x => x.UserId == GetUserId() && x.IsDeleted == false)
                .ProjectTo<CarViewModel>(config)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (carView is CarViewModel == false)
            {
                throw new ArgumentException("Car does not exist");
            }
            return carView;
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
