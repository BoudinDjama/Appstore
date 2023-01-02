using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appstore.DataSqlite.Migrations;
using Appstore.Models;


namespace Appstore.DataSqlite
{
    public class AppstoreContext : DbContext
    {
        static AppstoreContext()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion
                <AppstoreContext, AppstoreConfiguration>(true));
        }
        public AppstoreContext() : base("name=Appstore")
        {

        }

        public DbSet<App> Apps { get; set; }
        public DbSet<Dev> Devs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}

