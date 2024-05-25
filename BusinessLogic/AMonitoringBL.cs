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

        public List<ADestinations> GetDestinations()
        {
            return GetAllDestinations();
        }

        public ADestinations GetADestination(int id)
        {
            return GetDestinationDetails(id);
        }

        public ActionStatus DeleteDestination(int id) 
        {
            return DeleteSelectedDestination(id);   
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
       
        public LevelAcces ChangeUserRole(int userId, string newUserRole)
        {
            return ChangeAUserRole(userId, newUserRole);
        }
    }
}
