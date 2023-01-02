using Appstore.DataSqlite;
using Appstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appstore.Controllers
{
    public class CategoriesController : Controller
    {
        AppstoreContext db = new AppstoreContext();
        // GET: Categories

        public ActionResult Category()
        {
            var category = db.Categories.ToList();
            return View("Category", category);
        }

        //GET: Apps by Category
        public ActionResult CategoryView(int id) 
        { 
        
            var apps = db.Apps.Include("Category").Where(c => c.CategoryId == id).ToList();
            var category = db.Categories.Where(c=> c.CategoryId == id).Select(c => c.Name).FirstOrDefault();
            ViewBag.CategoryName = category; 


            return View("CategoryView", apps); 
        }
        

       
    }
}