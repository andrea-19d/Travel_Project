using BusinessLogic.Core;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;
using Domain.Entities.Bookings;

namespace BusinessLogic
{
    public class ProductBL : BookingApi, IProduct
    {
        public List<ADestinations> GetPackages()
        {
            return GetDestinationPackages();
        }

        public int GetCount() 
        { 
            return GetDestinationCount(); 
        }
    }
}
