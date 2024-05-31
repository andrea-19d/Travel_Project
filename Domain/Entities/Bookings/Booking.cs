using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bookings
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int DestinationID { get; set; }
        public int Id { get; set; }
        public int NrOfKids { get; set; }
        public string Specialrequest { get; set; }
    }
}
