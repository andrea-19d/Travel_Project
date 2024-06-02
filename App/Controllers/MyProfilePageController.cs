using BusinessLogic.DBModel.Seed;
using BusinessLogic.Interfaces;
using BusinessLogic;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System.Linq;
using System.Web.Mvc;
using App.Models;
using AutoMapper;
using Domain.Entities.User;
using Domain.Entities.Res;
using System.Web;

namespace App.Controllers
{
    public class MyProfilePageController : Controller
    {
        private BusinessLogic.DBModel.Seed.UserContext _userContext;
        private ISession _session;

        public MyProfilePageController()
        {
            var bl = new BussinesLogic();
            _userContext = new BusinessLogic.DBModel.Seed.UserContext();
            _session = bl.GetSessionBL();
        }

        [HttpGet]
        [Authorize]
        public ActionResult MyProfile()
        {
            var currentUser = User.Identity.Name;
            var user = _userContext.Users.FirstOrDefault(u => u.Email == currentUser);

            if (user != null)
            {
                string base64String = _session.GetUserPhoto(user.UserId);
                ViewBag.UserPhoto = base64String;
                ViewBag.UserFirstName = user.FirstName;
                ViewBag.UserLastName = user.LastName;
                ViewBag.Username = user.Username;
                ViewBag.Email = user.Email;
                ViewBag.Role = user.Level;
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("Create")]
        public ActionResult UpdateUserProfile(user currentUser)
        {
            HttpPostedFileBase file = Request.Files["profilePicture"];

            if (ModelState.IsValid)
            {
                var updateUser = Mapper.Map<UpdateUserData>(currentUser);

                if (updateUser != null)
                {
                    ActionStatus resp = _session.UpdateProfile(updateUser, file);
                    if (resp.Status)
                    {
                        ViewBag.Status = resp.Status;
                    }
                }
            }
            
            return RedirectToAction("MyProfile");
        }

        public ActionResult Booked
    }
}
