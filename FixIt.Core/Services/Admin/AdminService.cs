﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.ServiceHistory;
using FixIt.Core.Models.Technician;
using FixIt.Infrastructure.Data;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;
using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixIt.Core.Models.Service;

namespace FixIt.Core.Services.User
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;
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
            userManager = _userManager;
            config = _config;
            mapper = _mapper;
        }

        //Customer manipulation from the Admin User
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
        public async Task EditCustomerAsync(CustomerFormModel model)
        {
            var entity = await context
                .Users
                .FindAsync(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("User not found!");
            }

            entity.PhoneNumber = model.PhoneNumber;
            await context.SaveChangesAsync();
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

        //Car manupulation from the Admin User
        public async Task AddCarAsync(CarFormModel model)
        {
            var entity = mapper
                .Map<Infrastructure.Data.Models.Car>(model);
            await context.AddAsync(entity);
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
        public async Task<IEnumerable<CarViewModel>> GetCustomerCarsViewAsync(string customerId)
        {
            var models = await context
            .Cars
            .AsNoTracking()
            .Where(x =>
            x.UserId == customerId
            && x.IsDeleted == false
            )
            .ProjectTo<CarViewModel>(config)
            .ToArrayAsync();

            if (models.Any())
            {
                return models;
            }

            throw new InvalidDataException("The customer has no cars!");
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
        public async Task<IEnumerable<CarViewModel>> GetAllCarsAsync()
        {
            return await context
                .Cars
                .AsNoTracking()
                .ProjectTo<CarViewModel>(config)
                .OrderBy(x => x.Make)
                .ToArrayAsync();
        }
        public async Task<CarDetailedViewModel> GetCarDetailsAsync(int id)
        {
            var car = await context
                .Cars
                .AsNoTracking()
                .ProjectTo<CarDetailedViewModel>(config)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (car is CarDetailedViewModel)
            {
                return car;
            }
            throw new InvalidDataException("Car doesn't exist!");
        }

        //Appointment manupulation from the Admin User
        public async Task BookAsync(AppointmentFormModel model)
        {
            var entity = mapper
                .Map<Infrastructure.Data.Models.Appointment>(model);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Appointment Information");
            }

            if (entity.DateAndTime.DayOfWeek > LastWorkDay || entity.DateAndTime.Hour < 8 || entity.DateAndTime.Hour > 17)
            {
                throw new ArgumentException("The appointment date is outside working hours");
            }

            await context.Appointments.AddAsync(entity);
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
        public async Task<AppointmentViewModel> GetAppointmentAsync(int appointmentId)
        {
            var appointment = await context
                .Appointments
                .AsNoTracking()
                .ProjectTo<AppointmentViewModel>(config)
                .FirstOrDefaultAsync(x => x.Id == appointmentId);

            if (appointment == null)
            {
                throw new ArgumentException("Appointment does not exist");
            }

            return appointment;
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

        //Technician manupulation from the Admin User
        public async Task<IEnumerable<TechnicianViewModel>> GetAllTechniciansAsync()
        {
            var allTechnicians = await context
                .Technicians
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Name)
                .ProjectTo<TechnicianViewModel>(config)
                .ToArrayAsync();

            if (allTechnicians == null)
            {
                throw new InvalidDataException("No technicians availabe");
            }

            return allTechnicians;
        }
        public async Task AppointTechnicianAsync(int appointmentId, TechnicianViewModel model)
        {
            var entity = await context
                .Appointments
                .FindAsync(appointmentId);

            if (entity == null)
            {
                throw new InvalidDataException("Appoitnment doesn't exist!");
            }

            entity.TechnicianId = model.Id;
            await context.SaveChangesAsync();
        }
        public async Task RegisterTechnicianUserAsync(CustomerFormModel model)
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
            await userManager.AddToRoleAsync(user, "Technician");
        }
        public async Task AddTechnicianInfoAsync(TechnicianFormModel model)
        {
            var entity = mapper
                    .Map<FixIt.Infrastructure.Data.Models.Technician>(model);

            if (entity == null)
            {
                throw new InvalidDataException("Invalid data!");
            }

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

        }
        public async Task<string> GetTechnicinUserIdAsync(string email)
        {
            var technicianUser = await context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);

            if (technicianUser == null)
            {
                throw new InvalidDataException("The user doesn't exist!");
            }

            return technicianUser.Id;
        }
        public async Task DeleteTechnicianAsync(TechnicianViewModel model)
        {
            var technicianEntity = await context
                .Technicians
                .FindAsync(model.Id);

            if (technicianEntity == null)
            {
                throw new InvalidDataException("Technician doesn't exist!");
            }

            var userEntity = await context
                .Users
                .Where(x => x.Id == technicianEntity.UserId)
                .FirstOrDefaultAsync();

            if (userEntity == null)
            {
                throw new InvalidDataException("User doesn't exist!");
            }

            var userRole = await context
                .UserRoles
                .Where(x => x.UserId == userEntity.Id)
                .FirstOrDefaultAsync();

            if (userRole == null)
            {
                throw new InvalidDataException("UserRole doesn't exist!");
            }

            context.Remove(userRole);
            context.Remove(userEntity);
            technicianEntity.IsDeleted = true;

            await context.SaveChangesAsync();
        }
        public async Task<TechnicianViewModel> GetTechnicianViewModelAsync(int id)
        {
            var model = await context
                .Technicians
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<TechnicianViewModel>(config)
                .FirstOrDefaultAsync();

            if (!(model is TechnicianViewModel))
            {
                throw new InvalidDataException("Technician doesn't exist");
            }
            return model;
        }

        //Service manupulation from the Admin User
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
        public async Task<IEnumerable<ServiceViewModel>> GetServicesAsync()
        {
            var services = await context
            .Services
            .AsNoTracking()
            .Where(x => x.IsDeleted == false)
            .ProjectTo<ServiceViewModel>(config)
            .OrderBy(n => n.Type)
            .ToArrayAsync();

            if (services == null)
            {
                throw new ArgumentException("There are no services added!");
            }

            return services;
        }
        public async Task<IEnumerable<ServiceHistoryViewModel>> GetCarHistory(int id)
        {
            return await context
                .ServiceHistories
                .AsNoTracking()
                .Where(x => x.CarId == id)
                .ProjectTo<ServiceHistoryViewModel>(config)
                .OrderBy(d => d.Date)
                .ToArrayAsync();
        }

        public async Task AddServiceAsync(ServiceFormModel model)
        {
            var entity = mapper
            .Map<Service>(model);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Service Information");
            }

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditServiceAsync(ServiceFormModel model)
        {
            var entity = await context
              .Services
              .Where(x => x.IsDeleted == false)
              .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                throw new ArgumentException("The Service doesn't exist!");
            }

            entity.Description = model.Description;
            entity.Price = model.Price;
            await context.SaveChangesAsync();
        }
        public async Task<ServiceFormModel> GetServiceFormAsync(int id)
        {
            var model = await context
                .Services
                .AsNoTracking()
                .Where(d => d.IsDeleted == false && d.Id == id)
                .ProjectTo<ServiceFormModel>(config)
                .FirstOrDefaultAsync();

            if (!(model is ServiceFormModel))
            {
                throw new InvalidDataException("The service doesn't exist");
            }

            return model;
        }

        public async Task DeleteServiceAsync(ServiceViewModel model)
        {
            var entity = await context
            .Services
            .Where(x => x.Id == model.Id
            && x.IsDeleted == false
            )
            .FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new ArgumentException("The Service does not exist");
            }

            entity.IsDeleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<ServiceViewModel> GetServiceViewModelAsync(int id)
        {
            var model = await context
               .Services
               .AsNoTracking()
               .Where(x => x.Id == id
               && x.IsDeleted == false
               )
               .ProjectTo<ServiceViewModel>(config)
               .FirstOrDefaultAsync();

            if (!(model is ServiceViewModel))
            {
                throw new InvalidDataException("Service doesn't exist");
            }
            return model;
        }
    }
}
