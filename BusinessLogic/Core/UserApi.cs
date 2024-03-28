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
using BusinessLogic.DBModel.Seed;
using System.Net;
using System.ComponentModel.DataAnnotations;


namespace BusinessLogic.Core
{
    public class UserApi
    {
        internal ActionStatus UserLogData(ULoginData login)
        {
            UDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Credentials == login.Credential && u.Password == login.Password);
            }
            if (result == null)
            {
                return new ActionStatus
                {
                    Status = false,
                    StatusMessage = "The username or password is incorrect"
                };
            };
            return new ActionStatus { Status = true };
        }

        public ActionStatus RegisterUserAction(URegisterData data)
        {
            UDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault();
            }

            return null;
        }
        internal LevelStatus CheckLevelLogic(string keySession)
        {
            return new LevelStatus();
        }

        internal ProductDetail GetProdUser(int id)
        {
            return new ProductDetail();
        }


        public bool UserSessionStatus()
        {
            return true;
        }

    }
}
