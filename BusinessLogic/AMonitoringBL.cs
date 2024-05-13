using BusinessLogic.Core;
using BusinessLogic.Interfaces;
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

namespace BusinessLogic.DBModel
{
    public class AMonitoringBL : AdminApi, IMonitoring
    {
        public List<UserMinimal> GetCount()
        {
            return GetAllUsers();
        }

        public int GetNumberOfUsers()
        {
            return ManageNrOfUsers();
        }

        public int NewUsers()
        {
            return ManageNewUsersCount();
        }

        public ActionStatus AddDestination(ADestinations data, HttpPostedFileBase file)
        {
            return AddNewDestination(data, file);
        }
        public ActionStatus DeleteUser(int userId)
        {
            return DeleteAUser(userId);
        }
        public ActionStatus ChangeUserLevel(int userId, LevelAcces newLevel)
        {
            return ChangeAUserLevel(userId, newLevel);
        }

    }
}
