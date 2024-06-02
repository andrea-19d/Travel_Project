using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Res;
using Domain.Entities.User;
using Domain.Entities.User.Global;
using BusinessLogic.DBModel.Seed;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Helpers;
using System.Web;
using Domain.Entities.Enums;
using AutoMapper;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Configuration;


namespace BusinessLogic.Core
{
    public class UserApi
    {
        public ActionStatus UserLogData(ULoginData login)
        {
            UDbTable result;

            var pass = LoginHelper.HashGen(login.Password);
            /*var isValidEmail = new EmailAddressAttribute().IsValid(login.Email);*/
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(e => e.Email == login.Email || e.Username == login.Username );
            }
            if (result.Email != null || result.Username != null && result.Password == pass)
            {
                using (var todo = new UserContext())
                { 
                    result.LastLogin = login.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }
                return new ActionStatus { Status = true, StatusMessage = result.Level.ToString() };

            }
            else
            {
                return new ActionStatus
                {
                    Status = false,
                    StatusMessage = "The username or password is incorrect"
                };
            }

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
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                }

                db.SaveChanges();
            }

            return apiCookie;
        }

        public ActionStatus RegisterUserAction(URegisterData data)
        {

            string predefinedPhotoPath = "D:\\andre\\Univer\\Anul II\\sem II\\pr\\TravelWebsite\\App\\Content\\ADMIN\\assets\\img\\ivana-square.jpg";
            byte[] predefinedPhotoBytes = File.ReadAllBytes(predefinedPhotoPath);

            try
            {
                using (var db = new UserContext())
                {
                    bool emailExists = db.Users.Any(u => u.Email == data.Email);
                    bool usernameExists = db.Users.Any(u => u.Username == data.Username);

                    if (emailExists || usernameExists)
                    {
                        return new ActionStatus { Status = false, StatusMessage = "User with the provided email or username already exists" };
                    }
                }

                var hashedPassword = LoginHelper.HashGen(data.Password);

                var newUser = Mapper.Map<UDbTable>(data);
                newUser.Password = hashedPassword;
                newUser.LastLogin = DateTime.Now;
                newUser.RegisterDate = DateTime.Now;
                newUser.UserPhoto = predefinedPhotoBytes;
                newUser.Level = LevelAcces.User;



                using (var db = new UserContext())
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }

                return new ActionStatus { Status = true, StatusMessage = "User registered successfully" };
            }
            catch (Exception ex)
            {
                return new ActionStatus { Status = false, StatusMessage = $"An error occurred: {ex.Message}" };
            }
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            var userminimal = Mapper.Map<UserMinimal>(curentUser);

            return userminimal;
        }

        public string GetUserPhotoBase64(int userId)
        {
            try
            {
                byte[] userPhotoBytes;
                using (var db = new UserContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.UserId == userId);
                    if (user != null && user.UserPhoto != null)
                    {
                        userPhotoBytes = user.UserPhoto;
                    }
                    else
                    {
                        string defaultPhotoPath = "path_to_default_photo.jpg";
                        userPhotoBytes = File.ReadAllBytes(defaultPhotoPath);
                    }
                }

                string base64String = Convert.ToBase64String(userPhotoBytes);

                return base64String;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionStatus UpdateUserProfile(UpdateUserData user, HttpPostedFileBase file)
        {
            try
            {
                using (var db = new UserContext())
                {
                    var existingUser = db.Users.FirstOrDefault(u => u.Email == user.Email);

                    if (existingUser == null)
                    {
                        return new ActionStatus { Status = false, StatusMessage = "User not found." };
                    }

                    if (file != null && file.ContentLength > 0)
                    {
                        // Handle file upload
                        string filename = Path.GetFileName(file.FileName);
                        string filepath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/User"), filename);
                        file.SaveAs(filepath);

                        // Convert the uploaded image to byte array
                        byte[] imageBytes = File.ReadAllBytes(filepath);

                        user.UserPhoto = imageBytes;
                    }
                    else
                    {
                        user.UserPhoto = existingUser.UserPhoto;
                    }

                    Mapper.Map(user, existingUser);

                    var entry = db.Entry(existingUser);
                    if (entry.State == EntityState.Unchanged)
                    {
                        return new ActionStatus { Status = true, StatusMessage = "No changes detected." };
                    }

                    entry.State = EntityState.Modified;
                    db.SaveChanges();

                    return new ActionStatus { Status = true, StatusMessage = "Profile updated successfully." };
                }
            }
            catch (Exception ex)
            {
                return new ActionStatus { Status = false, StatusMessage = ex.Message };
            }
        }

        public UpdateUserData GetCurrentUserMinimal(string username)
        {
            using (var dbcontext = new UserContext())
            {
                var user = dbcontext.Users.FirstOrDefault(x => x.Username == username);
                if (user == null)
                {
                    return null;
                }

                var currentUser = Mapper.Map<UpdateUserData>(user);
                return currentUser;
            }
        }

    }
}
