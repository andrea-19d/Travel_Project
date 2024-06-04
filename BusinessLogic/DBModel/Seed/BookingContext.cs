using Domain.Entities;
using Domain.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DBModel.Seed
{
    public class BookingContext : DbContext
    {
        public BookingContext() : base("name = App") { }

        public virtual DbSet<BookingDB> Bookings { get; set; }
    }
}
