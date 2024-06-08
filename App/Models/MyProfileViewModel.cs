using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class MyProfileViewModel
    {
        public user User { get; set; }
        public List<Domain.Entities.Bookings.UBooking> Bookings { get; set; }
    }
}