using FixIt.Infrastructure.Data.Enumerators;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;

namespace FixIt.Infrastructure.Data.Models
{
    [Comment("Technicians Table")]
    public class Technician
    {
        public Technician() 
        {
            IsDeleted = false;
            IsAvailable = true;
        }

        [Comment("Technician Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Identity User Identification")]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Comment("Technician Name")]
        [Required]
        [StringLength(TechnicianNameMax)]
        public string Name { get; set; } = string.Empty;

        [Comment("Technician Specialization")]
        [Required]
        public TechnicianSpecialization Specialization { get; set; }

        [Comment("Technician Soft Delete Property")]
        [Required]
        public bool IsDeleted { get; set; }

        [Comment("Technician Availability Property")]
        [Required]
        public bool IsAvailable { get; set; }
    }
}