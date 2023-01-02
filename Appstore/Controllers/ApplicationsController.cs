using Appstore.DataSqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Appstore.Models;
using Appstore.DataSqlite;

namespace Appstore.Controllers
{
    public class ApplicationsController : Controller
    {
        AppstoreContext db = new AppstoreContext();
        
        // GET: Applications
        public ActionResult NewApp()
        {
            var category = db.Categories.ToList();
            var publisher = db.Devs.ToList();

            ViewBag.CategoryList = new SelectList(category, "Name", "Name");
            ViewBag.PublisherList = new SelectList(publisher, "Name", "Name");

            return View();
        }
        //post
        [HttpPost]
        public ActionResult NewApp(App app)
        {
            try
            {
                var ubisoft = new Dev { Name = "Ubisoft" };             
                var query = db.Categories.Where(c => c.Name == app.Category.Name).Select(c => c).FirstOrDefault();
                var query2 = db.Devs.Where(c => c.Name == app.Dev.Name).Select(c => c).FirstOrDefault();



                app.PublishDate = DateTime.Now;
                app.Category = query;
                app.Dev = query2;
                db.Apps.Add(app);
                db.SaveChanges();
                return RedirectToAction("Apps", "Appstore");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Publishers/Edit/5
        public ActionResult AppDetails(int id)
        {
            
            return View(db.Apps.Include("Category").Include("Dev").First(x => x.Id == id));
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        public ActionResult AppDetails(int id, App app)
        {
            var query = db.Categories.Where(c => c.Name == app.Category.Name).Select(c => c).FirstOrDefault();

            try
            {
                App d = db.Apps.First(x => x.Id == id);
                d.Name = app.Name;
                d.Description = app.Description;
                d.Price = app.Price;
                d.Downloads = app.Downloads;
                d.ImagePath = app.ImagePath;
                d.Dev = app.Dev;
                d.PublishDate = app.PublishDate;
                d.Category = app.Category;

                db.SaveChanges();
                return RedirectToAction("Apps", "Appstore");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditApp(int id)
        {
            var category = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(category, "Name", "Name");

            var app= db.Apps.Include("Category").First(x => x.Id == id);
            

            return View(app);
        }

        [HttpPost]
        public ActionResult EditApp(int id, App app)
        {
            try
            {
                App d = db.Apps.First(x => x.Id == id);
                var query = db.Categories.Where(c => c.Name == app.Category.Name).Select(c => c).FirstOrDefault();

                d.Name = app.Name;
                d.Description = app.Description;
                d.Price = app.Price;
                d.Downloads = app.Downloads;
                d.ImagePath = app.ImagePath;
                d.Category = query;
                d.Dev = app.Dev;
                d.Reviews = app.Reviews;
                db.SaveChanges();
                return RedirectToAction("Apps", "Appstore");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteApp(int id)
        {
            return View(db.Apps.First(x => x.Id == id));
        }
        
        [HttpPost]
        public ActionResult DeleteApp(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var app = db.Apps.First(x => x.Id == id);
                db.Apps.Remove(app);
                db.SaveChanges();
                return RedirectToAction("Apps", "Appstore");
            }
            catch
            {
                return View();
            }
        }

    }
}