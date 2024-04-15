using FixIt.Infrastructure.Data.Enumerators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Core.Models.Service
{
    public class ServiceFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public ServiceType Type { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(0.01, double.MaxValue, ErrorMessage = PriceValidationError)]
        public decimal Price { get; set; }
    }
}
