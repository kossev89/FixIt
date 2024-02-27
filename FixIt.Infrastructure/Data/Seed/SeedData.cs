using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Infrastructure.Data.Seed
{
    internal class SeedData
    {
        public SeedData()
        {
            SeedUsers();
            SeedCars();
            SeedServices();
            SeedTechnicians();
            SeedServiceHistories();
        }

        public IdentityUser AdminUser { get; set; }
        public IdentityUser CustomerUser { get; set; }
        public Car FirstCar { get; set; }
        public Car SecondCar { get; set; }
        public Service TireRotation { get; set; }
        public Service OilChange { get; set; }
        public Service Diagnostics { get; set; }
        public Service EngineRepair { get; set; }
        public Service SuspensionRepair { get; set; }
        public Service BodyRepair { get; set; }
        public Service Paint { get; set; }
        public ServiceHistory FirstCarHistory { get; set; }
        public Technician FirstTechnician { get; set; }
        public Technician SecondTechnician { get; set; }
        public Technician ThirdTechnician { get; set; }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            AdminUser = new IdentityUser() 
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082", 
                UserName = "admin@mail.com", NormalizedUserName = "admin@mail.com", 
                Email = "admin@mail.com", 
                NormalizedEmail = "admin@mail.com"
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");

            CustomerUser = new IdentityUser() 
            { 
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "customer@mail.com", 
                NormalizedUserName = "customer@mail.com",
                Email = "customer@mail.com", 
                NormalizedEmail = "customer@mail.com"
            };

            CustomerUser.PasswordHash = hasher.HashPassword(CustomerUser, "customer123");
        }

        private void SeedCars()
        {
            FirstCar = new Car()
            {
                Id = 1,
                Make = "Toyota",
                Model = "Avensis",
                Year = 2005,

            };
        }
        private void SeedServices()
        {

        }
        private void SeedServiceHistories()
        {

        }
        private void SeedTechnicians()
        {

        }


    }
}