using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Bookings;
using Domain.Entities.Product;

namespace BusinessLogic.Interfaces
{
    public interface IProduct
    {
        List<ADestinations> GetPackages();

        int GetCount();
    }
}
