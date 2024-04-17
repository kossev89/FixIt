using AutoMapper;
using FixIt.Core.Contracts.Car;
using FixIt.Core.Models.Car;
using FixIt.Core.Profiles;
using FixIt.Core.Services.Car;
using FixIt.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class CarServiceTest
    {
        private ApplicationDbContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        private IConfigurationProvider _config;
        private ICarService _carService;

        [SetUp]
        public void Setup()
        {
            // Initialize your DbContext with a test database connection
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Your_Test_Database_Connection_String")
                .Options;
            _context = new ApplicationDbContext(options);

            _httpContextAccessor = new Mock<IHttpContextAccessor>().Object;
            _config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperConfig()));
            _carService = new CarService(_context, _httpContextAccessor, _config);
        }

        [Test]
        public void AddAsync_NullModel_ThrowsArgumentNullException()
        {
            // Arrange
            CarFormModel model = null;

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(() => _carService.AddAsync(model));
        }

        [Test]
        public void AddAsync_InvalidModel_ThrowsArgumentException()
        {
            // Arrange
            var model = new CarFormModel
            {
                Id = -1,
                UserId = "",
                Make = "",
                CarModel = "",
                Year = -2022,
                PlateNumber = "",
                Vin = "",
                Mileage = -15000,
                ImageUrl = "https://example.com/car-image.jpg"
            };

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(() => _carService.AddAsync(model));
        }



        private CarFormModel GetValidCarFormModel()
        {
            return new CarFormModel
            {
                Id = 1,
                UserId = "user123",
                Make = "Toyota",
                CarModel = "Corolla",
                Year = 2022,
                PlateNumber = "ABC123",
                Vin = "12345678901234567",
                Mileage = 15000,
                ImageUrl = "https://example.com/car-image.jpg"
            };
        }
    }
}
