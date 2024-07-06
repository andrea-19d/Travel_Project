using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessLogic;
using BusinessLogic.Interfaces;
using Domain.Entities.Bookings;

namespace App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProduct _product;

        public HomeController()
        {
            var bl = new BussinesLogic();
            _product = bl.GetProductBL();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            string role = SessionStatus();
            ViewData["UserRole"] = role;
            var prodDetail = await _product.GetPackages();
            return View(prodDetail);
        }

        [HttpGet]
        public async Task<ActionResult> PackagePage()
        {
            SessionStatus();
            var prodDetail = await _product.GetPackages();
            var count = _product.GetCount();
            ViewBag.Count = count; 
            return PartialView("PackagePage", prodDetail);
        }

        public ActionResult Carousel()
        {
            SessionStatus();
            return View();
        }

        public ActionResult SearchBar()
        {
            return View();
        }

        public ActionResult Destination()
        {
            SessionStatus();

            return View();
        }

        public ActionResult ExploreTur()
        {
            SessionStatus();
            return View();
        }

        public ActionResult TurBooking()
        {
            SessionStatus();
            return View();
        }


    }
}
