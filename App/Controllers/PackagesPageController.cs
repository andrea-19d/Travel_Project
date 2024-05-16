using BusinessLogic;
using BusinessLogic.Interfaces;
using Domain.Entities.Bookings;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class PackagesPageController : Controller
    {
        // GET: PackagesPage
        private IProduct _product;
        public PackagesPageController()
        {
            var bussinesl = new BussinesLogic();
            _product = bussinesl.GetProductBL();    
        }

        [HttpGet]
        public ActionResult PackagePage()
        {
            var prodDetail = _product.GetPackages();
            return View(prodDetail);
        }

    }
}