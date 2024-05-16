using Domain.Entities.Bookings;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class HomePageModels
    {
        public ADestinations ADestinations { get; set; }
        public UserMinimal UserMinimal { get; set; }
    }
}