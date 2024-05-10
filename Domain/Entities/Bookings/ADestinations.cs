using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bookings
{
    public class ADestinations
    {
        public string DestinationID { get; set; }
        public string DestinationName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Days { get; set; }
        public int NrOfPersons { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Review {  get; set; }
        
    }
}
