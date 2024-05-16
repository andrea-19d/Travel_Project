using System.Collections.Generic;
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
        public ActionResult Index()
        {
            SessionStatus();
            var prodDetail = _product.GetPackages();
            return View(prodDetail);
        }

        [HttpGet]
        public ActionResult PackagePage()
        {
            var prodDetail = _product.GetPackages();
            var count = _product.GetCount();
            ViewBag.Count = count; 
            return PartialView("PackagePage", prodDetail);
        }

        public ActionResult Carousel()
        {

            return View();
        }

        public ActionResult SearchBar()
        {
            return View();
        }

        public ActionResult Destination()
        {
            return View();
        }

        public ActionResult ExploreTur()
        {
            return View();
        }

        public ActionResult TurBooking()
        {
            return View();
        }


    }
}
