using FixIt.Core.Contracts.User;
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
    public class UserSevice : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<IdentityUser> userManager;
        public UserSevice(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor, UserManager<IdentityUser> _userManager)
        {
            context = _context;
            httpContextAccessor = _httpContextAccessor;
            userManager = _userManager;
        }

        public async Task<IEnumerable<IdentityUser>> GetAllCustomersAsync()
        {
            var customers = userManager.GetUsersInRoleAsync("Customer").Result;
            var customersId = customers
                .Select(x => x.Id);

            return await context
                .Users
                .Where(x => customersId.Contains(x.Id))
                .ToListAsync();
        }
    }
}
