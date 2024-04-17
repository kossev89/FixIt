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
using FixIt.Infrastructure.Data.Enumerators;
using NUnit.Framework.Constraints;
using FixIt.Core.Models.Car;
namespace UnitTests
{
    [TestFixture]
    public class AdminServiceTests
    {
        private ApplicationDbContext context;
        private Mock<IHttpContextAccessor> httpContextAccessorMock;
        private IMapper mapper;
        private AdminService adminService;

        [SetUp]
        public void Setup()
        {
            // Create an instance of ApplicationDbContext using a real database or an in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            context = new ApplicationDbContext(options);

            httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperConfig>();
            });
            mapper = mapperConfig.CreateMapper();

            adminService = new AdminService(context, httpContextAccessorMock.Object, null, null, mapper);
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
            await adminService.BookAsync(validModel);

            // Assert
            var savedAppointment = await context.Appointments.FirstOrDefaultAsync();
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
            var exception = Assert.ThrowsAsync<ArgumentException>(() => adminService.BookAsync(invalidModel));
            Assert.That(exception.Message, Is.EqualTo("The appointment date is outside working hours"));
        }

        [Test]
        public async Task GetAllAppointmentsAsync_ReturnsAllAppointments()
        {
            // Arrange
            var appointments = new Appointment[]
        {
        new Appointment { Id = 200, Status = AppointmentStatus.Scheduled },
        new Appointment { Id = 201, Status = AppointmentStatus.Completed },
        new Appointment { Id = 202, Status = AppointmentStatus.Idle }
        };
            await context.Appointments.AddRangeAsync(appointments);
            await context.SaveChangesAsync();

            // Act
            var result = await adminService.GetAllAppointmentsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetAllAppointmentsAsync_ReturnsAppointmentsOrderedByStatus()
        {
            // Arrange
            var appointments = new Appointment[]
        {
        new Appointment { Id = 203, Status = AppointmentStatus.Scheduled },
        new Appointment { Id = 204, Status = AppointmentStatus.Completed },
        new Appointment { Id = 205, Status = AppointmentStatus.Idle }
        };
            await context.Appointments.AddRangeAsync(appointments);
            await context.SaveChangesAsync();

            // Act
            var result = await adminService.GetAllAppointmentsAsync();

            // Assert
            Assert.That(result.First().Status, Is.EqualTo(AppointmentStatus.Completed));
            Assert.That(result.Last().Status, Is.EqualTo(AppointmentStatus.Idle));
        }

        [Test]
        public async Task GetAppointmentAsync_ExistingAppointment_ReturnsAppointment()
        {
            // Arrange
            var appointments = new List<Appointment>
    {
        new Appointment { Id = 1, Status = AppointmentStatus.Scheduled },
        new Appointment { Id = 2, Status = AppointmentStatus.Completed },
        new Appointment { Id = 3, Status = AppointmentStatus.Idle }
    };
            await context.Appointments.AddRangeAsync(appointments);
            await context.SaveChangesAsync();

            // Act
            var appointmentId = 2;
            var result = await adminService.GetAppointmentAsync(appointmentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(appointmentId, result.Id);
        }

        [Test]
        public async Task GetAppointmentAsync_NonExistingAppointment_ThrowsArgumentException()
        {
            // Arrange - No need to arrange anything specific for this case

            // Act & Assert
            var nonExistingAppointmentId = 999; // Assuming this ID doesn't exist
            var exception = Assert.ThrowsAsync<ArgumentException>(() => adminService.GetAppointmentAsync(nonExistingAppointmentId));
            Assert.AreEqual("Appointment does not exist", exception.Message);
        }

        [Test]
        public async Task AddCarAsync_InvalidModel_ThrowsArgumentException()
        {
            // Arrange
            var model = new CarFormModel
            {
                // Set properties of an invalid car model
            };

            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(() => adminService.AddCarAsync(model));
            Assert.That(exception.Message, Is.EqualTo("Invalid Car Information"));
        }

    }
}