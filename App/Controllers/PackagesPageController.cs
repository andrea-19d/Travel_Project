using BusinessLogic;
using BusinessLogic.Interfaces;
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
        PackagesPageController()
        {
            BussinesLogic bussinesl = new BussinesLogic();
            _product = bussinesl.GetProductBL();
        }
        public ActionResult Packages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetProduct(int id)
        {
            ProductDetail prodDetail = _product.GetDetailProduct(id);
            return View();
        }
    }
}