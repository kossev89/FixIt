﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.ServiceHistory;
using FixIt.Core.Models.Technician;
using FixIt.Infrastructure.Data;
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
        public AdminService(
            ApplicationDbContext _context,
            IHttpContextAccessor _httpContextAccessor,
            UserManager<IdentityUser> _userManager,
            IConfigurationProvider _config
            )
        {
            context = _context;
            httpContextAccessor = _httpContextAccessor;
            userManager = _userManager;
            config = _config;
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

        public async Task<IEnumerable<CarDetailedViewModel>> GetCustomerCarsAsync(string id)
        {
            return await context
                .Cars
                .AsNoTracking()
                .Where(x => x.UserId == id && x.IsDeleted == false)
                .ProjectTo<CarDetailedViewModel>(config)
                .ToArrayAsync();
        }

        public async Task<CustomerViewModel> GetCustomerDetailsAsync(string id)
        {
            var customer = userManager.GetUsersInRoleAsync("Customer").Result.FirstOrDefault();

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
             .OrderBy(d=>d.Date)
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
            await userManager.AddToRoleAsync(user, "Customer");

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
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