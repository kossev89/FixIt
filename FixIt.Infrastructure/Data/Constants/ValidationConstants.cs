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
    }
}
