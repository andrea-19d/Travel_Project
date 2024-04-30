using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Bookings;

namespace BusinessLogic.DBModel
{
    public class BookingContext : DbContext
    {
        public BookingContext() : base("name = App")
        {
        }

        public virtual DbSet<UAddressTable> Bookings { get; set; }
    }

}
