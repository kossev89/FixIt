using FixIt.Infrastructure.Data.Enumerators;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FixIt.Core.Models.Customer;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;

namespace FixIt.Core.Models.Technician
{
    public class TechnicianFormModel
    {
        public int Id { get; set; }

        [Comment("Identity User Identification")]
        public string UserId { get; set; } = string.Empty;
        public CustomerViewModel User { get; set; } = null!;

        [Comment("Technician Name")]
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TechnicianNameMax, ErrorMessage = NameValidationError)]
        public string Name { get; set; } = string.Empty;

        [Comment("Technician Specialization")]
        [Required(ErrorMessage = RequiredErrorMessage)]
        public TechnicianSpecialization Specialization { get; set; }
    }
}
