using Domain.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DBModel.Seed
{
    public class DestinationContext : DbContext
    {
        public DestinationContext() :base("name = App") { }

        public virtual DbSet<DestDbTable> Destination {  get; set; }
    }
}
