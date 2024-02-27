using FixIt.Infrastructure.Data.Enumerators;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixIt.Infrastructure.Data.Models
{
    [Comment("Appointments table")]
    public class Appointment
    {
        [Comment("Appointment Identifier")]
        [Key]
        public int Id { get; init; }

        [Comment("Customer Identifier")]
        [Required]
        public string UserId { get; init; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Comment("Car Identifier")]
        [Required]
        public int CarId { get; init; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        [Comment("Service Identifier")]
        [Required]
        public int ServiceId { get; init; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; } = null!;


        [Comment("Technician Identifier")]
        [Required]
        public int TechnicianId { get; set; }
        [ForeignKey(nameof(TechnicianId))]
        public Technician Technician { get; set; } = null!;

        [Comment("Appointment Date")]
        [Required]
        public DateOnly Date { get; set; }

        [Comment("Appointment Time")]
        [Required]
        public TimeOnly Time { get; set; }

        [Comment("Appointment Status")]
        [Required]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
    }
}