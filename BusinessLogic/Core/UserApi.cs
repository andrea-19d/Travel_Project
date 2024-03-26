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

        internal new RResponceData RegisterUserAction(URegisterData login) 
        {
            var newUser = new ULoginData
            { 
                Credential = login.Credential,
                Password = login.Password,
                LoginIp = Request.UserHostAddress,
                LoginDateTime = DateTime.Now,
            };
            using (var db = new UserContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
            return new RResponceData();
        }
       
        internal ProductDetail GetProdUser(int id)
        {
            return new ProductDetail();
        }
        public bool UserSessionStatus()
        {
            return true;
        }

        internal ULoginResp UserSessionData(ULoginData data)
        {
            UBbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password ==
                data.Password);
            }
            if (result == null)
            {
                return new ULoginResp
                {
                    Status = false,
                    StatusMsg = "The username or password is incorrect"
                };
            }
            return new ULoginResp { Status = true };
        }

    }
}
