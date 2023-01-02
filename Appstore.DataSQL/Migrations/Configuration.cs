namespace Appstore.DataSqlite.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;
 
    using Appstore.Models;




    internal sealed class AppstoreConfiguration : DbMigrationsConfiguration<Appstore.DataSqlite.AppstoreContext>
    {
        public AppstoreConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());

        }
        protected override void Seed(Appstore.DataSqlite.AppstoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (context.Devs.Any())
                return;

            //--------------------------------------------------------------------------------------------------------------------
            //Creating Application, Autors and Categories upon running the project for the first time

            //Authors

            var microsoft = new Dev { Name = "Microsoft" };
            var apple = new Dev { Name = "Apple" };
            var activision = new Dev { Name = "Activision" };

            //Categories

            var other = new Category { CategoryId = 1, Name = "Other", Description = " " };
            var games = new Category { CategoryId = 2, Name = "Games", Description = " " };
            var education = new Category { CategoryId = 3, Name = "Education", Description = " " };
            var entertainment = new Category { CategoryId = 4, Name = "Entertainment", Description = " " };
            var music = new Category { CategoryId = 5, Name = "Music", Description = " " };
            var sports = new Category { CategoryId = 6, Name = "Sports", Description = " " };
            var weather = new Category { CategoryId = 7, Name = "Weather", Description = " " };

            //Application
            var office = new App { 
                Name = "Office" , 
                Description = "Library of software", 
                Price = 399 , 
                Downloads = 3000000, 
                Category = education 
            };

            var cod = new App {
                Name = "Call of duty",
                Description = "First person shooter",
                Price = 70,
                Downloads = 90000000,
                Category = games,
                
            };

            var itunes = new App
            {
                Name = "Itunes",
                Description = "Media player software",
                Price = 5,
                Downloads = 5982982,
                Category = music
            };



            //Providing authors with apps
            microsoft.Apps.Add(office);
            apple.Apps.Add(itunes);
            activision.Apps.Add(cod);

            
            


            context.Devs.Add(microsoft);
            context.Devs.Add(apple);
            context.Devs.Add(activision);
            context.Categories.Add(games);
            context.Categories.Add(education);
            context.Categories.Add(entertainment);
            context.Categories.Add(music);
            context.Categories.Add(sports);
            context.Categories.Add(weather);
            context.Categories.Add(other);
            

        }
    }

}
