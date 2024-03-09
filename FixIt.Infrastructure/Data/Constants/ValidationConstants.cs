using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Infrastructure.Data.Constants
{
    /// <summary>
    /// Validation constants
    /// </summary>
    public static class ValidationConstants
    {
        /// <summary>
        /// Car Make and Model minimum and maximum symbols
        /// </summary>
        public const int CarMin = 2;
        public const int CarMax = 20;
        /// <summary>
        /// Minimum manufacture year
        /// </summary>
        public const int YearMin = 1_886;
        public const int YearMax = 2_024;
        /// <summary>
        /// VIN number fixed length
        /// </summary>
        public const int VinLength = 17;
        /// <summary>
        /// Minimum and maximum mileage
        /// </summary>
        public const int MinMileage = 0;
        public const int MaxMileage = 2_000_000;
        /// <summary>
        /// Technician's name MIN and MAX symbols
        /// </summary>
        public const int TechnicianNameMin = 2;
        public const int TechnicianNameMax = 50;
        /// <summary>
        /// Error message constants
        /// </summary>
        public const string NameValidationError = "The {0} field should be between {2} and {1} symbols";
        public const string YearValidationError = "The {0} field should be between {1} and {2}";
        public const string VinValidationError = "The {0} field should be exactly {1} symbols";
        public const string MileageValidationError = "The {0} field should be between {1} and {2} kilometers";
        /// <summary>
        /// Display Constants
        /// </summary>
        public const string CarModelDisplay = "Car Model";
        public const string CarYearDisplay = "Year of Production";
        public const string CarPlateDisplay = "Registration Plate Number";
        public const string CarImageDisplay = "Car Image";
        /// <summary>
        /// Date Format
        /// </summary>
        public const string DateValidationFormat = "dd/MM/yyyy HH:mm";
        /// <summary>
        /// Error Validation
        /// </summary>
        public const string RequiredErrorMessage = "The {0} field is required!";
        /// <summary>
        /// Work Time Validation
        /// </summary>
        public const DayOfWeek FirstWorkDay = DayOfWeek.Monday;
        public const DayOfWeek LastWorkDay = DayOfWeek.Friday;
    }
}
