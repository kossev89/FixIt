using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;

namespace FixIt.Infrastructure.Data.Models
{
    [Comment("Cars Table")]
    public class Car
    {
        [Comment("Car Identifier")]
        [Key]
        public int Id { get; init; }

        [Comment("Car Manufacturer Information")]
        [Required]
        [StringLength(CarMax)]
        public string Make { get; init; } = string.Empty;

        [Comment("Car Model Information")]
        [Required]
        [StringLength(CarMax)]
        public string Model { get; init; } = string.Empty;

        [Comment("Car Year of Manufacture")]
        [Required]
        public DateTime Year { get; init; }

        [Comment("Car Registration Plate Number")]
        [Required]
        [StringLength(CarMax)]
        public string PlateNumber { get; init; } = string.Empty;

        [Comment("Car Vehicle Identification Number")]
        [StringLength(VinLength)]
        public string? Vin { get; init; }

        [Comment("Car Current Mileage in km")]
        [Required]
        [Range(VinLength,VinLength)]
        public int Mileage { get; set; }

        [Comment("Car's owner")]
        [Required]
        public string UserId { get; init; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public ICollection<ServiceHistory> ServiceHistories { get; set; } = new List<ServiceHistory>();
    }
}
