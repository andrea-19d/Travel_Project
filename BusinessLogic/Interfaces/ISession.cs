using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Enums;
using Domain.Entities.Res;
using Domain.Entities.User;
using Domain.Entities.User.Global;

namespace BusinessLogic.Interfaces
{
    public interface ISession
    {
        ActionStatus UserLogin(ULoginData data);
        LevelStatus CheckLevel(string key);
        RResponceData RegisterNewUserAction(URegisterData regData)
    }
}
