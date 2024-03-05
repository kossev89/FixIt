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

namespace FixIt.Core.Models.Appointment
{
    public class AppointmentViewModel
    {
        public int Id { get; init; }
        public string UserId { get; init; } = string.Empty;
        public int CarId { get; init; }
        public string CarMake { get; set; } = string.Empty;
        public string CarModel { get; set; } = string.Empty;
        public string CarRegPlate { get; set; } = string.Empty;
        public int ServiceId { get; init; }
        public string ServiceType { get; init; } = string.Empty;
        public int? TechnicianId { get; set; }
        public string TechnicianName { get; set; } = string.Empty;
        public DateTime DateAndTime { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Idle;
    }
}
