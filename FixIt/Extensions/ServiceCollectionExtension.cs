using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FixIt.Infrastructure.Data;
using FixIt.Infrastructure.Data.Models;
using FixIt.Core.Contracts.Car;
using FixIt.Core.Services.Car;
using FixIt.Core.Services.User;
using FixIt.Core.Contracts.Appointment;
using FixIt.Core.Services.Appointment;
using FixIt.Core.Contracts.ServiceHistory;
using FixIt.Core.Services.ServiceHistory;
using FixIt.Core.Contracts.User;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IServiceHistoryService, ServiceHistoryService>();
            services.AddScoped<IAdminService, FixIt.Core.Services.User.AdminService>();
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config
                .GetConnectionString("DefaultConnection");
            services
                .AddDbContext<ApplicationDbContext>(options =>
                options
                .UseSqlServer(connectionString));

            services
                .AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
                

            return services;
        }
    }
}
