using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Domain.Entities.Bookings;
using Domain.Entities.Res;

namespace BusinessLogic.Interfaces
{
    public interface IProduct
    {
        List<ADestinations> GetPackages();
        int GetCount();
        ActionStatus UpdateDestination(ADestinations dest, HttpPostedFileBase file);
        ADestinations GetADestination(int id);
    }
}
