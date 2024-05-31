using BusinessLogic.Core;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Bookings;
using Domain.Entities.Res;
using System.Web;

namespace BusinessLogic
{
    public class ProductBL : BookingApi, IProduct
    {
        public List<ADestinations> GetPackages()
        {
            return GetAllDestinations();
        }

        public int GetCount() 
        { 
            return GetDestinationCount(); 
        }

        public ActionStatus UpdateDestination(ADestinations dest, HttpPostedFileBase file)
        {
            return UpdateDestinationPackages(dest, file);
        }
        public ADestinations GetADestination(int id)
        {
            return GetDestinationDetails(id);
        }
    }
}
