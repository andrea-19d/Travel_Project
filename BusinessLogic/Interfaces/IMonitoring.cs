using Domain.Entities.Bookings;
using Domain.Entities.Enums;
using Domain.Entities.Res;
using Domain.Entities.User;
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
        int ManageNrOfUsers();
        int ManageNewUsersCount();
        ActionStatus AddDestination(ADestinations destination, HttpPostedFileBase file);
        ActionStatus DeleteUser(int userId);
        ActionStatus ChangeUserLevel(int userId, LevelAcces newLevel);
    }
  
    
}
