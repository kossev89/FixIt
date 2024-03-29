using AutoMapper;
using AutoMapper.QueryableExtensions;
using FixIt.Core.Contracts.User;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Models.Customer;
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
                .OrderBy(x=>x.Status)
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
    }
}
