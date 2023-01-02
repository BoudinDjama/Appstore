using Appstore.DataSqlite;
using Appstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreConsole
{
    public class CategoryViewer : Viewer
    {


        protected Category category { get; set; }
        protected List<Category> categories { get; set; }

        public CategoryViewer() : base("Categories")
        {
            Options = new List<string> { "Description", "Apps" };
            categories = new AppstoreContext().Categories.ToList();
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
                        category = categories.ElementAt(key - 2);
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
            Console.WriteLine(" Choose a category");
            Console.WriteLine($"     1 : Back to main menu");
            Console.WriteLine("");
            for (int i = 1; i < categories.Count + 1; i++)
            {
                Console.WriteLine($"     {i + 1} : {categories[i - 1].Name}");
            }
            return 1;
        }

        protected override int OptionMenu()
        {
            NewInstruction();
            Console.WriteLine($"----- {MenuTitle} - {category.Name} -----");
            Console.WriteLine(" Choose an option");
            for (int i = 1; i < Options.Count + 1; i++)
            {
                Console.WriteLine($"     {i} : {Options[i - 1]}");
            }
            Console.WriteLine($"     {Options.Count() + 1} : Back to category selection");

            return Options.Count + 1;

        }

        protected override void OptionSelected(int index)
        {
            switch (index)
            {
                case 0:
                    NewInstruction();
                    Console.WriteLine($"----- {category.Name} - Description -----");
                    Console.Write(category.Description);
                    break;
                case 1:
                    NewInstruction();
                    Console.WriteLine($"----- {category.Name} - Apps -----");
                    foreach (var app in category.Apps)
                    {
                        Console.WriteLine("----------------");
                        Console.WriteLine("Name : " + app.Name);
                        Console.Write("Description : " + app.Description);
                        Console.WriteLine("Category : " + app.Category);
                        Console.WriteLine("Downloads : " + app.Downloads);
                        Console.WriteLine("Price : " + app.Price + " $");
                        Console.WriteLine("Publish date : " + app.PublishDate);

                    }
                    if (category.Apps.Count < 1)
                    {
                        Console.WriteLine("   No app found");
                    }
                    break;

            }
        }
    }
}

