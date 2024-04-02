using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixIt.Infrastructure.Data.Models
{
    [Comment("Table for the ServiceHistory")]
    public class ServiceHistory
    {
        [Comment("ServiceHistory Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("ServceHistory Customer Identifier")]
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Comment("Car Identifier")]
        [Required]
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        [Comment("Service Identifier")]
        [Required]
        public int ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; } = null!;

        [Comment("Technician Identifier")]
        [Required]
        public int TechnicianId { get; set; }
        [ForeignKey(nameof(TechnicianId))]
        public Technician Technician { get; set; } = null!;

        [Comment("Date of the service")]
        [Required]
        public DateTime Date { get; set; }

        [Comment("Current car mileage")]
        [Required]
        public int Mileage { get; init; }

        [Comment("Price of the service performed")]
        [Required]
        public decimal Price => Service.Price;
    }
}