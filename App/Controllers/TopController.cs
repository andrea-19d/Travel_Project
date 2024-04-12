using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.DBModel;
using BusinessLogic.Interfaces;
using Domain.Entities.User;
using Domain.Entities.User;
using App.Models;
using BusinessLogic;
using System.Data.Entity;
using System.Data;
using System.IO;
using eUseControl.Web.Controllers.Attributes;

namespace App.Controllers
{
    public class TopController : BaseController
    {
        [AdminMod]
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
            {
                using (NewsContext dbModel = new NewsContext())
                {
                    return View(dbModel.New.ToList());
                }
            }
            return RedirectToAction("Index", "Login");
        }
        [AdminMod]
        public ActionResult Details(int id)
        {
            using (NewsContext dbModel = new NewsContext())
            {
                return View(dbModel.New.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [AdminMod]
        public ActionResult Edit(int id)
        {
            using (NewsContext dbModel = new NewsContext())
            {
                return View(dbModel.New.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [AdminMod]
        [HttpPost]
        public ActionResult Edit(int id, News login)
        {
            try
            {
                using (NewsContext dbModel = new NewsContext())
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
        public ActionResult Create(UserNews login)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(login.ImageFile.FileName);
                string extension = Path.GetExtension(login.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                login.Foto = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                login.ImageFile.SaveAs(fileName);
                using (NewsContext dbModel = new NewsContext())
                {
                    News new_table = new News();
                    new_table.Data = login.Data;
                    new_table.Noutati = login.Noutati;
                    new_table.Foto = login.Foto;
                    dbModel.New.Add(new_table);
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
            using (NewsContext dbModel = new NewsContext())
            {
                return View(dbModel.New.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [AdminMod]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (NewsContext dbModel = new NewsContext())
                {
                    News news = dbModel.New.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.New.Remove(news);
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
        public ActionResult Ad()
        {
            return RedirectToAction("Index", "Top");
        }

    }
}