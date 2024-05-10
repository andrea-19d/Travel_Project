using BusinessLogic.Core;
using BusinessLogic.Interfaces;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DBModel
{
    public class UserMonitoringBL : AdminApi, IMonitoring
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

    }
}
