using FixIt.Infrastructure.Data.Enumerators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;

namespace FixIt.Core.Models.Service
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public ServiceType Type { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
