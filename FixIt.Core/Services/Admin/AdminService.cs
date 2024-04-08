using AutoMapper;
using AutoMapper.QueryableExtensions;
using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.ServiceHistory;
using FixIt.Core.Models.Technician;
using FixIt.Infrastructure.Data;
using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Core.Services.User
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfigurationProvider config;
        private readonly IMapper mapper;
        public AdminService(
            ApplicationDbContext _context,
            IHttpContextAccessor _httpContextAccessor,
            UserManager<IdentityUser> _userManager,
            IConfigurationProvider _config,
            IMapper _mapper
            )
        {
            context = _context;
            httpContextAccessor = _httpContextAccessor;
            userManager = _userManager;
            config = _config;
            mapper = _mapper;
        }

        public async Task AddCarAsync(CarFormModel model)
        {
            var entity = mapper.Map<Infrastructure.Data.Models.Car>(model);

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
            .Where(x => x.UserId == model.UserId
            && x.Id == model.Id
            && x.IsDeleted == false
            )
            .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("The car does not exist");
            }

            entity.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task EditCustomerCarAsync(CarFormModel model)
        {
            var entity = await context
               .Cars
               .FindAsync(model.Id);

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("The car doesn't exist!");
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

        public async Task<IEnumerable<AppointmentViewModel>> GetAllAppointmentsAsync()
        {
            return await context
                .Appointments
                .AsNoTracking()
                .ProjectTo<AppointmentViewModel>(config)
                .OrderBy(x => x.Status)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync()
        {
            var customers = userManager.GetUsersInRoleAsync("Customer").Result;
            var customersId = customers
                .Select(x => x.Id);

            return await context
                .Users
                .AsNoTracking()
                .Where(x => customersId.Contains(x.Id))
                .ProjectTo<CustomerViewModel>(config)
                .ToArrayAsync();
        }

        public Task<IEnumerable<TechnicianViewModel>> GetAllTechniciansAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppointmentViewModel>> GetCustomerApointmentsAsync(string id)
        {
            return await context
            .Appointments
            .AsNoTracking()
            .Where(x => x.UserId == id
            && x.Status != Infrastructure.Data.Enumerators.AppointmentStatus.Canceled
            )
            .ProjectTo<AppointmentViewModel>(config)
            .ToArrayAsync();
        }

        public async Task<CarFormModel> GetCustomerCarFormAsync(string cutomerId, int carId)
        {
            var car = await context
            .Cars
            .AsNoTracking()
            .Where(x =>
            x.UserId == cutomerId
            && x.Id == carId
            && x.IsDeleted == false
            )
            .ProjectTo<CarFormModel>(config)
            .FirstOrDefaultAsync();

            if (car is CarFormModel)
            {
                return car;
            }
            throw new InvalidDataException("The car doesn't exist");
        }

        public async Task<IEnumerable<CarDetailedViewModel>> GetCustomerCarsAsync(string id)
        {
            return await context
                .Cars
                .AsNoTracking()
                .Where(x => x.UserId == id && x.IsDeleted == false)
                .ProjectTo<CarDetailedViewModel>(config)
                .ToArrayAsync();
        }

        public async Task<CarViewModel> GetCustomerCarViewAsync(string cutomerId, int carId)
        {
            var car = await context
            .Cars
            .AsNoTracking()
            .Where(x =>
            x.UserId == cutomerId
            && x.Id == carId
            && x.IsDeleted == false
            )
            .ProjectTo<CarViewModel>(config)
            .FirstOrDefaultAsync();

            if (car is CarViewModel)
            {
                return car;
            }
            throw new InvalidDataException("The car doesn't exist");
        }

        public async Task<CustomerViewModel> GetCustomerDetailsAsync(string id)
        {
            var customer = userManager.GetUsersInRoleAsync("Customer")
                .Result
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (customer == null)
            {
                throw new ArgumentException("Customer doesn't exist!");
            }

            var model = await context
                .Users
                .AsNoTracking()
                .Where(x => x.Id == customer.Id)
                .ProjectTo<CustomerViewModel>(config)
                .FirstOrDefaultAsync();

            if (model == null)
            {
                throw new ArgumentException("Customer doesn't exist!");
            }

            return model;
        }

        public async Task<IEnumerable<ServiceHistoryViewModel>> GetCustomerServicesAsync(string id)
        {
            return await context
             .ServiceHistories
             .AsNoTracking()
             .Where(x => x.UserId == id)
             .ProjectTo<ServiceHistoryViewModel>(config)
             .OrderBy(d => d.Date)
             .ToArrayAsync();
        }

        public async Task RegisterCustomerAsync(CustomerFormModel model)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser()
            {
                UserName = model.UserName,
                NormalizedUserName = model.NormalizedUserName,
                Email = model.Email,
                NormalizedEmail = model.NormalizedEmail
            };
            user.PasswordHash = hasher.HashPassword(user, model.Password);

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            await userManager.AddToRoleAsync(user, "Customer");
        }

        public async Task<IEnumerable<CustomerViewModel>> SearchIndexAsync(string filter)
        {
            return await context
                .Users
                .AsNoTracking()
                .Where(x => x.Email.Contains(filter))
                .ProjectTo<CustomerViewModel>(config)
                .ToArrayAsync();
        }
    }
}
