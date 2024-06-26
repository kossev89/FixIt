﻿using FixIt.Infrastructure.Data.Enumerators;
using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace FixIt.Infrastructure.Data.Seed
{
    /// <summary>
    /// Initial database seed
    /// </summary>
    internal class SeedData
    {
        public SeedData()
        {
            SeedUsers();
            SeedCars();
            SeedServices();
            SeedTechnicians();
            SeedServiceHistories();
            SeedAppointments();
        }

        public IdentityUser AdminUser { get; set; } = null!;
        public IdentityUser CustomerUser { get; set; } = null!;
        public IdentityUser TechnicianUser1 { get; set; } = null!;
        public IdentityUser TechnicianUser2 { get; set; } = null!;
        public IdentityUser TechnicianUser3 { get; set; } = null!;
        public Car FirstCar { get; set; } = null!;
        public Car SecondCar { get; set; } = null!;
        public Service TireRotation { get; set; } = null!;
        public Service OilChange { get; set; } = null!;
        public Service Diagnostics { get; set; } = null!;
        public Service EngineRepair { get; set; } = null!;
        public Service SuspensionRepair { get; set; } = null!;
        public Service BodyRepair { get; set; } = null!;
        public Service Paint { get; set; } = null!;
        public ServiceHistory FirstCarHistory { get; set; } = null!;
        public Technician FirstTechnician { get; set; } = null!;
        public Technician SecondTechnician { get; set; } = null!;
        public Technician ThirdTechnician { get; set; } = null!;
        public Appointment FirstAppointment { get; set; } = null!;

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            AdminUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
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

            TechnicianUser1 = new IdentityUser()
            {
                Id = "99ae7f52-08a1-4c41-98f6-0934ab9eeced",
                UserName = "technician1@mail.com",
                NormalizedUserName = "technician1@mail.com",
                Email = "technician1@mail.com",
                NormalizedEmail = "technician1@mail.com"
            };
            TechnicianUser1.PasswordHash = hasher.HashPassword(TechnicianUser1, "Tech123@");

            TechnicianUser2 = new IdentityUser()
            {
                Id = "3e0f5536-ea82-4817-9d63-861cc93427c6",
                UserName = "technician2@mail.com",
                NormalizedUserName = "technician2@mail.com",
                Email = "technician2@mail.com",
                NormalizedEmail = "technician2@mail.com"
            };
            TechnicianUser2.PasswordHash = hasher.HashPassword(TechnicianUser2, "Tech123@");

            TechnicianUser3 = new IdentityUser()
            {
                Id = "b98a765c-94d6-4520-95ae-42503a95445d",
                UserName = "technician3@mail.com",
                NormalizedUserName = "technician3@mail.com",
                Email = "technician3@mail.com",
                NormalizedEmail = "technician3@mail.com"
            };
            TechnicianUser3.PasswordHash = hasher.HashPassword(TechnicianUser3, "Tech123@");
        }

        private void SeedCars()
        {
            FirstCar = new Car()
            {
                Id = 1,
                Make = "Toyota",
                Model = "Avensis",
                Year = 2005,
                PlateNumber = "P3366BC",
                Mileage = 180_000,
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fimg.autoabc.lv%2FToyota-Avensis%2FToyota-Avensis_2003_Hecbeks_15102250637_3.jpg&tbnid=3pELpEqszmhQ8M&vet=12ahUKEwiHqLvu_s6EAxX74bsIHVDBCw8QMygIegQIARBf..i&imgrefurl=https%3A%2F%2Fwww.auto-abc.eu%2FToyota-Avensis%2Fg275-2003&docid=Hbz18f1fC2wffM&w=1000&h=547&q=avensis%20t25&ved=2ahUKEwiHqLvu_s6EAxX74bsIHVDBCw8QMygIegQIARBf"
            };

            SecondCar = new Car()
            {
                Id = 2,
                Make = "Renault",
                Model = "Clio",
                Year = 2008,
                PlateNumber = "P1917BX",
                Mileage = 120_000,
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fautomedia.investor.bg%2Fmedia%2Ffiles%2Fresized%2Fuploadedfiles%2F640x0%2F244%2F5afbc0f7c9b507828db312f5101c9244-98.JPG&tbnid=EkO4b49Jvg6aaM&vet=12ahUKEwjr9Zuy_86EAxXSgv0HHawqCAoQMygBegQIARBN..i&imgrefurl=https%3A%2F%2Fautomedia.investor.bg%2Fa%2F2-novini%2F43784-upotrebyavano-renault-clio-iii-struva-li-si&docid=rme63mMTwMi2YM&w=640&h=463&q=renault%20clio%203&ved=2ahUKEwjr9Zuy_86EAxXSgv0HHawqCAoQMygBegQIARBN"
            };
        }
        private void SeedServices()
        {
            TireRotation = new Service()
            {
                Id = 1,
                Type = ServiceType.TireRotation,
                Price = 80.00m
            };

            OilChange = new Service()
            {
                Id = 2,
                Type = ServiceType.OilChange,
                Price = 150.00m
            };

            Diagnostics = new Service()
            {
                Id = 3,
                Type = ServiceType.Diagnostics,
                Price = 60.00m
            };

            EngineRepair = new Service()
            {
                Id = 4,
                Type = ServiceType.EngineRepair,
                Price = 2000.00m
            };

            SuspensionRepair = new Service()
            {
                Id = 5,
                Type = ServiceType.SuspensionRepair,
                Price = 1300.00m
            };

            BodyRepair = new Service()
            {
                Id = 6,
                Type = ServiceType.BodyRepair,
                Price = 2420.00m
            };
        }
        private void SeedServiceHistories()
        {
            FirstCarHistory = new ServiceHistory()
            {
                Id = 1,
                CarId = 1,
                ServiceId = 6,
                TechnicianId = 2,
                Date = DateTime.Today.AddMonths(-3),
                Mileage = 180_000,
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Price = 2420
            };
        }
        private void SeedTechnicians()
        {
            FirstTechnician = new Technician()
            {
                Id = 1,
                Name = "John Doe",
                Specialization = TechnicianSpecialization.Mechanics,
                UserId = "99ae7f52-08a1-4c41-98f6-0934ab9eeced"
            };

            SecondTechnician = new Technician()
            {
                Id = 2,
                Name = "Jane Doe",
                Specialization = TechnicianSpecialization.Electronics,
                UserId= "3e0f5536-ea82-4817-9d63-861cc93427c6"
            };

            ThirdTechnician = new Technician()
            {
                Id = 3,
                Name = "Don Johns",
                Specialization = TechnicianSpecialization.Body,
                UserId= "b98a765c-94d6-4520-95ae-42503a95445d"
            };
        }

        private void SeedAppointments()
        {
            FirstAppointment = new Appointment()
            {
                Id = 1,
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                CarId = 1,
                ServiceId = 1,
                TechnicianId = 1,
                DateAndTime = DateTime.Now.AddDays(1),
                Status = AppointmentStatus.Idle
            };
        }


    }
}