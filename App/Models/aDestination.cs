using Domain.Entities.User.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class aDestination
    {
        public int DestinationID { get; set; }
        public string DestinationName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Days { get; set; }
        public int NrOfPeople { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public byte[] Img { get; set; }
        public DestinationStatus Status { get; set; }
    }
}