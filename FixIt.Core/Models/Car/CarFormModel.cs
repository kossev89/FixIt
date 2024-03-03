using FixIt.Infrastructure.Data.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static FixIt.Infrastructure.Data.Constants.ValidationConstants;

namespace FixIt.Core.Models.Car
{
    /// <summary>
    /// Model for the AddCar form
    /// </summary>
    public class CarFormModel
    {
        [Required]
        [StringLength(CarMax, MinimumLength = CarMin, ErrorMessage = NameValidationError)]
        public string Make { get; set; } = string.Empty;

        [Required]
        [DisplayName(CarModelDisplay)]
        [StringLength(CarMax, MinimumLength = CarMin, ErrorMessage = NameValidationError)]
        public string CarModel { get; set; } = string.Empty;

        [Required]
        [DisplayName(CarYearDisplay)]
        [Range(YearMin, YearMax)]
        public int Year { get; set; }

        [Required]
        [DisplayName(CarPlateDisplay)]
        [StringLength(CarMax, MinimumLength = CarMin, ErrorMessage = NameValidationError)]
        public string PlateNumber { get; set; } = string.Empty;

        [StringLength(VinLength, MinimumLength = VinLength, ErrorMessage = VinValidationError)]
        public string? Vin { get; set; }

        [Required]
        [DisplayName(CarImageDisplay)]
        [Range(MinMileage, MaxMileage, ErrorMessage =MileageValidationError)]
        public int Mileage { get; set; }

        public string? ImageUrl { get; set; }
    }
}
