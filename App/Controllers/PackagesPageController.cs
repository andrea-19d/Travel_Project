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
    public class PackagesPageController : BaseController
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
            SessionStatus();
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Packages()
        {
            SessionStatus();
            await Task.Delay(1000);
            var prodDetail =  await _product.GetPackages();
            return View(prodDetail);
        }

    }
}