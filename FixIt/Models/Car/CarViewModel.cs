using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;

namespace FixIt.Models.Car
{
    /// <summary>
    /// Model View for Car Entity
    /// </summary>
    public class CarViewModel
    {
            public int Id { get; set; }
            public string Make { get; set; } = string.Empty;
            public string Model { get; init; } = string.Empty;
            public int Year { get; init; }
            public string PlateNumber { get; init; } = string.Empty;
            public string? Vin { get; init; }
            public int Mileage { get; set; }
            public string UserId { get; init; } = string.Empty;
            public string? ImageUrl { get; set; }
        }
    }
