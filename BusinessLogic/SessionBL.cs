using BusinessLogic.Core;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Enums;
using Domain.Entities.Res;
using Domain.Entities.User;
using Domain.Entities.User.Global;
using System.Web;



namespace BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public ActionStatus UserLogin(ULoginData data)
        {
            return UserLogData(data);
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public ActionStatus RegisterNewUserAction (URegisterData regData)
        {
            return RegisterUserAction(regData);
        }

        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }

        public string GetUserPhoto(int userID)
        {
            return GetUserPhotoBase64(userID);
        }

        public ActionStatus UpdateProfile(UpdateUserData data, HttpPostedFileBase file)
        {
            return UpdateUserProfile(data, file);
        }

        public UpdateUserData GetCurrentUser(string email)
        {
            return GetCurrentUserMinimal(email);
        }

    }
}
