using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Enums;
using Domain.Entities.Res;
using Domain.Entities.User;
using Domain.Entities.User.Global;
using Domain.Entities.Product;


namespace BusinessLogic.Core
{
    public class UserApi
    {
        internal ActionStatus UserLogData(ULoginData data)
        {
            return new ActionStatus();
        }
        internal LevelStatus CheckLevelLogic(string keySession)
        {
            return new LevelStatus();
        }
        internal ProductDetail GetProdUser(int id)
        {
            return new ProductDetail();
        }
    }
}
