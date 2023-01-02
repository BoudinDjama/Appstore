
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Appstore.DataSqlite;
using Appstore.Models;
using System.Data.Entity;

namespace Appstore.Controllers
{
    public class AppStoreController : Controller
    {

        AppstoreContext db = new AppstoreContext();
        // GET: Apps
       
        public ActionResult Apps()
        {

            var app = db.Apps.Include("Category").ToList();


            return View("Apps", app);
        }
        
        
        public ActionResult Today()
        {
            //Select a random category from the database
            Random rnd = new Random();
            int number = rnd.Next(2, 7);
            var category = db.Categories.Where(c => c.CategoryId == number).Select(c => c).FirstOrDefault();
            

            var app = db.Apps.Include("Category").ToList().OrderByDescending(x => x.PublishDate).Select(x=>x).Take(4);

            ViewBag.RndCategory = category;

            return View("Today",app);
        }
      
        
        public ActionResult Publishers()
        {
            var publishers = db.Devs.ToList();
            return View("Publishers",publishers);
        }

        [HttpPost]
        public ViewResult Publishers(string filter)
        {

            if (string.IsNullOrWhiteSpace(filter))
            {
                return View(db.Devs.ToList());
            }
            filter.ToLower().Trim();

            var publishers = db.Devs.Where(x =>
            x.Name.ToLower().Contains(filter) ||
            x.Description.ToLower().Contains(filter) ||
            x.Email.ToLower().Contains(filter)).ToList();
            return View(publishers);
        }
       

        [HttpPost]
        public ViewResult Apps(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return View(db.Apps.ToList());
            }
            filter.ToLower().Trim();

       
            var apps = db.Apps.Where(x =>
            x.Name.ToLower().Contains(filter) ||
            x.Description.ToLower().Contains(filter)).ToList();
            return View(apps);
        }
    }
}