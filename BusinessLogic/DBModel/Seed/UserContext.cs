using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DBModel.Seed
{
    public class UserContext : DbContext
    {
        public UserContext() :
        base("name = eUseControl") //conection string name define in your web.config
        {
        }

        public virtual DbSet<UBbTable> Users { get; set; }
    }

}
