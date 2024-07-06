using App.Controllers.Atrributes;
using App.Models;
using AutoMapper;
using BusinessLogic;
using BusinessLogic.Interfaces;
using Domain.Entities.Res;
using Domain.Entities.User;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class MyProfilePageController : BaseController
    {
        private BusinessLogic.DBModel.Seed.UserContext _userContext;
        private ISession _session;

        public MyProfilePageController()
        {
            var bl = new BussinesLogic();
            _userContext = new BusinessLogic.DBModel.Seed.UserContext();
            _session = bl.GetSessionBL();
        }

        [UserMod]
        [Authorize]
        public ActionResult MyProfile()
        {
            SessionStatus();
            var currentUser = User.Identity.Name;
            var user = _userContext.Users.FirstOrDefault(u => u.Email == currentUser);

            // Retrieve bookings for the current user
            List<Domain.Entities.Bookings.UBooking> bookings = _session.CreatedBookings(user.UserId); // Assuming such a method exists

            var viewModel = new MyProfileViewModel
            {
                User = new user
                {
                    UserId = user.UserId,
                    UserPhoto = user.UserPhoto,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Email = user.Email,
                },
                Bookings = bookings
            };

            return View(viewModel);
        }

        [HttpPost]
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

        public ActionResult ShowUserBookings(int id)
        {
            var resp = _session.CreatedBookings(id);
            return PartialView("ShowUserBookings", resp);
        }
    }
}
