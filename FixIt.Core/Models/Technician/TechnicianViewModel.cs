using FixIt.Core.Models.Customer;
using FixIt.Infrastructure.Data.Enumerators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Core.Models.Technician
{
    public class TechnicianViewModel
    {
        public int Id { get; set; }
        public CustomerViewModel User { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
