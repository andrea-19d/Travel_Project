using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Enums
{
    public enum BookingStatus
    {
        PENDING = 0,
        CONFIRMED = 1,
        IN_PROGRESS = 2,
        FINISHED = 3,
    }
}
