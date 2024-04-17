using FixIt.Infrastructure.Data.Enumerators;
using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixIt.Core.Models.Car;
using FixIt.Core.Models.Customer;
using FixIt.Core.Models.Service;
using FixIt.Core.Models.Technician;

namespace FixIt.Core.Models.Appointment
{
    public class AppointmentViewModel
    {
        public int Id { get; init; }
        public string UserId { get; init; } = string.Empty;
        public CustomerViewModel User { get; set; } = null!;
        public int CarId { get; init; }
        public CarDetailedViewModel Car { get; set; } = null!;
        public int ServiceId { get; init; }
        public ServiceViewModel Service { get; set; } = null!;
        public string ServiceType { get; init; } = string.Empty;
        public int TechnicianId { get; set; }
        public TechnicianViewModel Technician { get; set; } = null!;
        public string TechnicianName { get; set; } = string.Empty;
        public DateTime DateAndTime { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Idle;
    }
}
