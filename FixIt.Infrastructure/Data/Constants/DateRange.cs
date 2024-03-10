using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Infrastructure.Data.Constants
{
    public class DateRange: RangeAttribute
    {
        public DateRange()
    : base(typeof(DateTime),
            DateTime.Today.AddDays(1).ToString(),
            DateTime.Now.AddMonths(6).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture))
        { }
    }
}
