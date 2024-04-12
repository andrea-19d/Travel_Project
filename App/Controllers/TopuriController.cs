using System;
using System.Linq;
using System.Web.Mvc;
using BusinessLogic.DBModel;
using Domain.Entities.User;
using App.Models;
using System.Data.Entity;
using System.Data;
using System.IO;
//using App.Controllers.Attributes;
using System.Web;

namespace eUseControl.Web.Controllers
{
    public class TopuriController : BaseController
    {
        [AdminMod]
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
            {
                using (TopuriContext dbModel = new TopuriContext())
                {
                    return View(dbModel.Topuri.ToList());
                }
            }
            return RedirectToAction("Index", "Login");
        }
        [AdminMod]
        public ActionResult Details(int id)
        {
            using (TopuriContext dbModel = new TopuriContext())
            {
                return View(dbModel.Topuri.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [AdminMod]
        public ActionResult Edit(int id)
        {
            using (TopuriContext dbModel = new TopuriContext())
            {
                return View(dbModel.Topuri.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [AdminMod]
        [HttpPost]
        public ActionResult Edit(int id, Topuris login)
        {
            try
            {
                using (TopuriContext dbModel = new TopuriContext())
                {
                    dbModel.Entry(login).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [AdminMod]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [AdminMod]
        [HttpPost]
        public ActionResult Create(UserTopuri login)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(login.ImageFile.FileName);
                string extension = Path.GetExtension(login.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                login.Foto = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                login.ImageFile.SaveAs(fileName);
                using (TopuriContext dbModel = new TopuriContext())
                {
                    Topuris new_table = new Topuris();
                    new_table.Anul = login.Anul;
                    new_table.Data = login.Data;
                    new_table.Descriere = login.Descriere;
                    new_table.Nota = login.Nota;
                    new_table.Serii = login.Serii;
                    new_table.Status = login.Status;
                    new_table.Foto = login.Foto;
                    dbModel.Topuri.Add(new_table);
                    dbModel.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [AdminMod]
        public ActionResult Delete(int id)
        {
            using (TopuriContext dbModel = new TopuriContext())
            {
                return View(dbModel.Topuri.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [AdminMod]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (TopuriContext dbModel = new TopuriContext())
                {
                    Topuris news = dbModel.Topuri.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Topuri.Remove(news);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}