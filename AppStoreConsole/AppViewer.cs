using Appstore.DataSqlite;
using Appstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreConsole
{
    public class AppViewer : Viewer
    {

        protected App app { get; set; }
        protected List<App> apps { get; set; }

        public AppViewer() : base("Apps")
        {
            Options = new List<string> { "Description", "Publisher" , "Reviews" };
            apps = new AppstoreContext().Apps.ToList();
        }
        protected override void SelectOption()
        {
            do
            {
                int o = OptionMenu();

                try
                {
                    int.TryParse(Console.ReadLine(), out int key);
                    if (key == o)
                    {
                        return;
                    }
                    else
                    {
                        OptionSelected(key - 1);
                        Console.ReadKey();
                    }
                }
                catch
                {
                    continue;
                }
            } while (true);
        }
        public override void Select()
        {
            do
            {
                int o = Menu();

                try
                {
                    int.TryParse(Console.ReadLine(), out int key);
                    if (key == o)
                    {
                        return;
                    }
                    else
                    {
                        app = apps.ElementAt(key - 2);
                        SelectOption();
                    }
                }
                catch
                {
                    continue;
                }
            } while (true);
        }

        protected override int Menu()
        {

            NewInstruction();
            Console.WriteLine($"----- {MenuTitle} -----");
            Console.WriteLine(" Choose an app");
            Console.WriteLine($"     1 : Back to main menu");
            Console.WriteLine("");
            for (int i = 1; i < apps.Count + 1; i++)
            {
                Console.WriteLine($"     {i + 1} : {apps[i - 1].Name}");
            }
            return 1;
        }

        protected override int OptionMenu()
        {
            NewInstruction();
            Console.WriteLine($"----- {MenuTitle} - {app.Name} -----");
            Console.WriteLine("Category : " + app.Category);
            Console.WriteLine("Downloads : " + app.Downloads);
            Console.WriteLine("Price : " + app.Price + " $");
            Console.WriteLine("Publish date : " + app.PublishDate);
            Console.WriteLine("----------------");
            Console.WriteLine(" Choose an option");
            for (int i = 1; i < Options.Count + 1; i++)
            {
                Console.WriteLine($"     {i} : {Options[i - 1]}");
            }
            Console.WriteLine($"     {Options.Count() + 1} : Back to apps selection");

            return Options.Count + 1;

        }

        protected override void OptionSelected(int index)
        {
            switch (index)
            {
                case 0:
                    NewInstruction();
                    Console.WriteLine($"----- {app.Name} - Description -----");
                    Console.Write(app.Description);
                    break;
                case 1:
                    NewInstruction();
                    Console.WriteLine($"----- {app.Name} - Publisher -----");
                    Console.WriteLine("Name : " + app.Dev.Name);
                    Console.WriteLine("----------------");
                    Console.Write("Description : " + app.Dev.Description);
                    Console.WriteLine("----------------");
                    Console.WriteLine("Email : " + app.Dev.Email);
                    break;
                case 2:
                    NewInstruction();
                    Console.WriteLine($"----- {app.Name} - Reviews -----");
                    foreach(var review in app.Reviews)
                    {
                        Console.WriteLine("----------------");
                        Console.WriteLine("Author : " + review.Author);
                        Console.Write("Description : " + review.Description);
                        Console.WriteLine("Rating : " + review.Rating);
                        Console.WriteLine("Publish date : " + review.PublishDate);
                    }
                    break;
            }
        }
    }
}
