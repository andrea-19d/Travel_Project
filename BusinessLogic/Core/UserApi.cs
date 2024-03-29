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
using System.Data.Entity.Validation;
using System.Data.Entity.Migrations;


namespace BusinessLogic.Core
{
    public class UserApi
    {
        internal ActionStatus UserLogData(ULoginData login)
        {
            UDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);


                if (result == null)
                {
                    return new ActionStatus
                    {
                        Status = false,
                        StatusMessage = "The username or password is incorrect"
                    };
                };

                result.LastLogin = login.LoginDateTime;
                db.SaveChanges();
            }
            
            return new ActionStatus { Status = true };
        }

        public ActionStatus RegisterUserAction(URegisterData data)
        {
                using (var db = new UserContext())
                {
                    // Check if a user with the same credentials already exists
                    bool userExists = db.Users.Any(u => u.Email == data.Email);

                    if (userExists)
                    {
                        // Return error status if user already exists
                        return new ActionStatus
                        {
                            Status = false,
                            StatusMessage = "A user with the same username already exists."
                        };
                    }

                    var newUser = new UDbTable
                    {
                        Credentials = data.Username,
                        Email = data.Email,
                        Password = data.Password,
                        LastLogin = data.LastLogin,
                        level = data.level,
                    };
                    // Add the new user to the database
                    db.Users.Add(newUser);
                    db.SaveChanges();

                    // Return success status
                    return new ActionStatus
                    {
                        Status = true,
                        StatusMessage = "User registered successfully."
                    };
                }
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
