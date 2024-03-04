using FixIt.Infrastructure.Data.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;

namespace FixIt.Infrastructure.Data.Models
{
    [Comment("Technicians Table")]
    public class Technician
    {
        [Comment("Technician Identifier")]
        [Key]
        public int Id { get; set; }

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
    }
}