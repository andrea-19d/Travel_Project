using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Res;
using Domain.Entities.User;
using Domain.Entities.User.Global;
using Domain.Entities.Product;
using BusinessLogic.DBModel.Seed;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Helpers;
using System.Web;
using Domain.Entities.Enums;


namespace BusinessLogic.Core
{
    public class UserApi
    {
        internal ActionStatus UserLogData(ULoginData login)
        {
            UDbTable result;
            var pass = LoginHelper.HashGen(login.Password);
            var validate = new EmailAddressAttribute();
            var isValidEmail = validate.IsValid(login.Username);

            using (var db = new UserContext())
            {
                result = isValidEmail
                    ? db.Users.FirstOrDefault(u => u.Email == login.Username)
                    : db.Users.FirstOrDefault(u => u.Credentials == login.Username && u.Password == pass);
            }

            if (result == null)
            {
                return new ActionStatus
                {
                    Status = false,
                    StatusMessage = "The username or password is incorrect"
                };
            }

            using (var db = new UserContext())
            {
                result.LastLogin = DateTime.Now;
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
            }

            return new ActionStatus { Status = true };
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                var isValidEmail = new EmailAddressAttribute().IsValid(loginCredential);
                var curent = db.Sessions.FirstOrDefault(e => e.Username == loginCredential);

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(1);
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(1)
                    });
                }

                db.SaveChanges();
            }

            return apiCookie;
        }

        public ActionStatus RegisterUserAction(URegisterData data)
        {
            try
            {
                using (var db = new UserContext())
                {
                    bool emailExists = db.Users.Any(u => u.Email == data.Email);
                    bool usernameExists = db.Users.Any(u => u.Credentials == data.Username);

                    if (emailExists || usernameExists)
                    {
                        return new ActionStatus { Status = false, StatusMessage = "User with the provided email or username already exists" };
                    }
                }

                var hashedPassword = LoginHelper.HashGen(data.Password);
                var newUser = new UDbTable
                {

                    Credentials = data.Username,
                    Password = hashedPassword,
                    Email = data.Email,
                    LastLogin = DateTime.Now,
                    level = LevelAcces.User
                };

                using (var db = new UserContext())
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }

                return new ActionStatus { Status = true, StatusMessage = "User registered successfully" };
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in an appropriate way
                return new ActionStatus { Status = false, StatusMessage = $"An error occurred: {ex.Message}" };
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
