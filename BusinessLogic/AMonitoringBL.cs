using BusinessLogic.Core;
using BusinessLogic.Interfaces;
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

namespace BusinessLogic.DBModel
{
    public class AMonitoringBL : AdminApi, IMonitoring
    {
        public List<UserMinimal> GetCount()
        {
            return GetAllUsers();
        }

        public ActionStatus DeleteDestination(int id) 
        {
            return DeleteSelectedDestination(id);   
        }

        public int TodaysSales()
        {
            return GetTodaysSalesAdmin();
        }

        public int TotalSales()
        {
            return GetTotalSalesAdmin(); 
        }

        public int TodaysUsers()
        {
            return ManageTodaysUsers();
        }

        public int NewUsers()
        {
            return ManageNrOfUsers();
        }

        public ActionStatus AddDestination(ADestinations data, HttpPostedFileBase file)
        {
            return AddNewDestination(data, file);
        }
        public ActionStatus DeleteUser(int userId)
        {
            return DeleteAUser(userId);
        }
       
        public LevelAcces ChangeUserRole(int userId, string newUserRole)
        {
            return ChangeAUserRole(userId, newUserRole);
        }
    }
}
