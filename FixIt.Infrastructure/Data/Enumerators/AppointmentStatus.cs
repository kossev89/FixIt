using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixIt.Infrastructure.Data.Enumerators
{
    public enum AppointmentStatus
    {
        Idle,
        Scheduled,
        InProgress,
        Completed,
        Canceled
    }
}
