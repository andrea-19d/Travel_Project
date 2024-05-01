using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMonitoring
    {
        List<UserMinimal> GetCount();
        int ManageNrOfUsers();
        int ManageNewUsersCount();
    }

}
