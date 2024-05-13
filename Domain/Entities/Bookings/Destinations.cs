using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Bookings
{
    public class Destinations
    {
        public int ID { get; set; }
        public string AttractionTitle { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public byte[] Photo { get; set; } 
        public string Description { get; set; }
    }
}
