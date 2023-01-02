using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Appstore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
         // Path for games 
            routes.MapRoute(
             name: "Today",
             url: "AppStore/Today",
             defaults: new { controller = "AppStore", action = "Today", id = UrlParameter.Optional }
         );

         // Path for category name
            routes.MapRoute(
             name: "Category",
             url: "AppStore/Category/{id}",
             defaults: new { controller = "AppStore", action = "Category", id = UrlParameter.Optional }
         );
         // Path for applications
            routes.MapRoute(
             name: "Apps",
             url: "AppStore/Apps",
             defaults: new { controller = "AppStore", action = "Apps", id = UrlParameter.Optional }
         );
         // Path for Search Bar
            routes.MapRoute(
               name: "SearchRoute",
               url: "Applications/NewApp/{id}",
               defaults: new { controller = "Applications", action = "NewApp", id = UrlParameter.Optional }
           );

         // Defaut
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AppStore", action = "Today", id = UrlParameter.Optional }
            );
            
        }
    }
}
