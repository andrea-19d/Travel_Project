using App.Controllers.Atrributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AccountSettingsController : Controller
    {
        // GET: AccountSettings
        [UserMod]
        public ActionResult AccountSettings()
        {
            return View();
        }
    }
}