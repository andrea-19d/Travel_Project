using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.User;

namespace BusinessLogic.DBModel.Seed
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name = App")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}
