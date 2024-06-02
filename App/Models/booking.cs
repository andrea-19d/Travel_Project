using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class booking
    {
        public int BookingId { get; set; }
        public int DestinationID { get; set; }
        public int UserId { get; set; }
        public int NrOfPeople { get; set; }
        public float Price { get; set; }
        public string Specialrequest { get; set; }
    }
}