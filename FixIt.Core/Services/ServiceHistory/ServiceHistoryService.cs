using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IConfigurationProvider config;
        public ServiceHistoryService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor, IConfigurationProvider _config)
        {
            context = _context;
            httpContextAccessor = _httpContextAccessor;
            config = _config;
        }

        public async Task<IEnumerable<ServiceHistoryViewModel>> GetAllAsync()
        {
            return await context
                .ServiceHistories
                .AsNoTracking()
                .Where(x => x.Car.UserId == GetUserId())
                .ProjectTo<ServiceHistoryViewModel>(config)
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
