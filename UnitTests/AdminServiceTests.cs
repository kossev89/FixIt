using System;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FixIt.Core.Contracts.User;
using FixIt.Infrastructure.Data;
using FixIt.Core.Profiles;
using FixIt.Core.Services.User;
using FixIt.Core.Models.Appointment;
using FixIt.Core.Services.Appointment;
using Moq;
using Microsoft.AspNetCore.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using FixIt.Infrastructure.Data.Models;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;
using NUnit.Framework.Constraints;
namespace UnitTests
{
    [TestFixture]
    public class AdminServiceTests
    {
        private ApplicationDbContext _context;
        private Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private IMapper _mapper;
        private AdminService _adminService;

        [SetUp]
        public void Setup()
        {
            // Create an instance of ApplicationDbContext using a real database or an in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationDbContext(options);

            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperConfig>();
            });
            _mapper = mapperConfig.CreateMapper();

            _adminService = new AdminService(_context, _httpContextAccessorMock.Object, null, null, _mapper);
        }


        [Test]
        public async Task BookAsync_ValidAppointment_Success()
        {
            // Arrange
            var rightDateTime = new DateTime(2024, 4, 15, 09, 0, 0);
            var validModel = new AppointmentFormModel
            {
                UserId = "qwewqeqweq",
                CarId = 1,
                ServiceId = 1,
                DateAndTime = rightDateTime
            };

            // Act
            await _adminService.BookAsync(validModel);

            // Assert
            var savedAppointment = await _context.Appointments.FirstOrDefaultAsync();
            Assert.NotNull(savedAppointment);
        }

        [Test]
        public void BookAsync_InvalidAppointment_ThrowsArgumentException()
        {
            // Arrange
            var invalidModel = new AppointmentFormModel
            {
                ServiceId = 1,
                DateAndTime = DateTime.Now
            };

            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(() => _adminService.BookAsync(invalidModel));
            Assert.That(exception.Message, Is.EqualTo("The appointment date is outside working hours"));
        }
    }
}