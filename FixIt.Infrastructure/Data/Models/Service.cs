using FixIt.Infrastructure.Data.Enumerators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace FixIt.Infrastructure.Data.Models
{
    [Comment("Table for Services")]
    public class Service
    {
        [Comment("Service Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Type of the Service")]
        [Required]
        public ServiceType Type { get; set; }

        [Comment("Detailed description of the service, if needed")]
        public string? Description { get; set; }

        [Comment("Price for the service")]
        [Required]
        public decimal Price { get; set; }
    }
}