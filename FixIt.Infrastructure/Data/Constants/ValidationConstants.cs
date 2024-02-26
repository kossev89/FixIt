using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Infrastructure.Data.Constants
{
    public static class ValidationConstants
    {
        public const int CarMin = 2;
        public const int CarMax = 20;

        public const int VinLength = 17;

        public const int MinMileage = 0;
        public const int MaxMileage = 2_000_000;
    }
}
