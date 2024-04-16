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
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(CarMax, MinimumLength = CarMin, ErrorMessage = NameValidationError)]
        public string Make { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName(CarModelDisplay)]
        [StringLength(CarMax, MinimumLength = CarMin, ErrorMessage = NameValidationError)]
        public string CarModel { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName(CarYearDisplay)]
        [Range(YearMin, YearMax)]
        public int Year { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName(CarPlateDisplay)]
        [StringLength(CarMax, MinimumLength = CarMin, ErrorMessage = NameValidationError)]
        public string PlateNumber { get; set; } = string.Empty;

        [StringLength(VinLength, MinimumLength = VinLength, ErrorMessage = VinValidationError)]
        public string? Vin { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName(CarImageDisplay)]
        [Range(MinMileage, MaxMileage, ErrorMessage =MileageValidationError)]
        public int Mileage { get; set; }

        public string? ImageUrl { get; set; }
    }
}
