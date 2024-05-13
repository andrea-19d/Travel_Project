using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App.Models
{
    public class DestinationsModel 
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Attraction { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public byte[] Photo { get; set; }
    }
}