using Appstore.DataSqlite;
using Appstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appstore.Controllers
{
    public class PublishersController : Controller
    {

        AppstoreContext db = new AppstoreContext();
        // GET: Publishers

        // GET: Publishers/Details/5
        public ActionResult Details(int id)
        {
            var app = db.Apps.Where(c => c.DevId == id).Select(c => c).ToList();

            ViewBag.AppList = app;


            return View(db.Devs.First(x => x.Id == id));
        }

        // GET: Publishers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        public ActionResult Create(Dev dev)
        {
            try
            {
                // TODO: Add insert logic here
                db.Devs.Add(dev);
                db.SaveChanges();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Devs.First(x => x.Id == id));
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Dev dev)
        {
            try
            {
                // TODO: Add update logic here
                Dev d = db.Devs.First(x => x.Id == id);
                d.Name = dev.Name;
                d.Description = dev.Description;
                d.Email = dev.Email;
                db.SaveChanges();
                return RedirectToAction("Publishers", "Appstore");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publishers/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Devs.First(x => x.Id == id));
        }

        // POST: Publishers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var dev = db.Devs.First(x => x.Id == id);
                db.Devs.Remove(dev);
                db.SaveChanges();
                return RedirectToAction("Publishers", "Appstore");
            }
            catch
            {
                return View();
            }
        }
    }
}
