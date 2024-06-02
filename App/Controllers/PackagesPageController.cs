using BusinessLogic;
using BusinessLogic.Interfaces;
using Domain.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ActionResult Index() 
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Packages()
        {
            await Task.Delay(1000);
            var prodDetail =  await _product.GetPackages();
            return View(prodDetail);
        }

    }
}