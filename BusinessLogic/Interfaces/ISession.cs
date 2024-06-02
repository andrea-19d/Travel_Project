using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Enums;
using Domain.Entities.Res;
using Domain.Entities.User;
using Domain.Entities.User.Global;
using BusinessLogic.Core;
using System.Web;

namespace BusinessLogic.Interfaces
{
    public interface ISession
    {
        ActionStatus UserLogin(ULoginData data);
        UserMinimal GetUserByCookie(string apiCookieValue);
        HttpCookie GenCookie(string loginCredential);
        ActionStatus RegisterNewUserAction(URegisterData regData);
        string GetUserPhoto(int userID);
        ActionStatus UpdateProfile(UpdateUserData user, HttpPostedFileBase file);
        UpdateUserData GetCurrentUser(string email);
    };
}
