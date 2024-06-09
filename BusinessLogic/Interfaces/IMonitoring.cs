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
        /* --- MANAGE USERS --- */
        List<UserMinimal> GetCount();
        int ManageNrOfUsers();
        int TodaysUsers();
        decimal GetUserPercentage();
        LevelAcces ChangeUserRole(int userId, string newUserRole);

        /* --- MANAGE SALES --- */
        int TodaysSales();
        int TotalSales();
        decimal GetSalesPercentage();

        /* --- MANAGE DESTINATIONS --- */
        ActionStatus DeleteDestination(int ID);
        ActionStatus AddDestination(ADestinations destination, HttpPostedFileBase file);
        ActionStatus DeleteUser(int userId);

    }
  
    
}
