using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FixIt.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<ServiceHistory> ServiceHistories { get; set; } = null!;
        public DbSet<Technician> Technicians { get; set; } = null!;
    }
}
