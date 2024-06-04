using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class BookingViewModel
    {
        /*--- DESTINATION DETAILS ----*/
        public int DestinationID { get; set; }
        public string DestinationName { get; set; }
        public int NrOfPeople { get; set; }
        public float Price { get; set; }
        public int Days { get; set; }

        /* --- USER DETAILS ---*/
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        /* --- BOOKING DETAILS --- */
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalPeople { get; set; }
        public float TotalPrice { get; set; }
        public string Suggestions { get; set; }
    }
}