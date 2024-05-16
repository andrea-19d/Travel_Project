using AutoMapper;
using BusinessLogic.DBModel.Seed;
using Domain.Entities.Bookings;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Core
{
    public class BookingApi
    {
        public List<ADestinations> GetDestinationPackages()
        {
            using (var db = new DestinationContext())
            {
                var destinations = db.Destination.Select( u => new ADestinations
                {
                    DestinationName = u.DestinationName,
                    Country = u.Country,
                    City = u.City,
                    Days = u.Days,
                    NrOfPersons = u.NrOfPersons,
                    Price = u.Price,
                    Description = u.Description,
                    Rating = u.Rating,
                    Img = u.Img,
                }).ToList(); 


                return destinations;
            }
        }

        public int GetDestinationCount()
        {
            using (var dbContext = new DestinationContext())
            {
                var usersCount = dbContext.Destination.Count();

                return usersCount;
            }
        }
    }
}
