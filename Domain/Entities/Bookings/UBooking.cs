using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Enums;

namespace Domain.Entities.Bookings
{
    public class UBooking
    {
        public int BookingId { get; set; }
        public int DestinationID { get; set; }
        public string DestinationName { get; set; }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalPeople { get; set; }
        public float TotalPrice { get; set; }
        public string Suggestions { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

/* --- TO DO: IMPLEMENT CORECLTY THE BOOKING PHASE --- */