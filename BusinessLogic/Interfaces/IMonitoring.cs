using Domain.Entities.Bookings;
using Domain.Entities.Enums;
using Domain.Entities.Res;
using Domain.Entities.User;
using Domain.Entities.User.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogic.Interfaces
{
    public interface IMonitoring
    {
        List<UserMinimal> GetCount();
        ActionStatus DeleteDestination(int ID);
        int ManageNrOfUsers();
        int ManageNewUsersCount();
        ActionStatus AddDestination(ADestinations destination, HttpPostedFileBase file);
        ActionStatus DeleteUser(int userId);
        LevelAcces ChangeUserRole(int userId, string newUserRole);
    }
  
    
}
