using Appstore.DataSqlite;
using Appstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreConsole
{
    public class DevViewer : Viewer
    {
        protected Dev dev { get; set; }
        protected List<Dev> devs { get; set; }

        public DevViewer() : base("Publishers") {
            Options = new List<string> { "Description" , "Email" , "Apps" };
            devs = new AppstoreContext().Devs.ToList();
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
                        dev = devs.ElementAt(key - 2);
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
            Console.WriteLine(" Choose a publisher");
            Console.WriteLine($"     1 : Back to main menu");
            Console.WriteLine("");
            for (int i = 1; i < devs.Count + 1; i++)
            {
                Console.WriteLine($"     {i + 1} : {devs[i - 1].Name}");
            }
            return 1;
        }

        protected override int OptionMenu()
        {
            NewInstruction();
            Console.WriteLine($"----- {MenuTitle} - {dev.Name} -----");
            Console.WriteLine(" Choose an option");
            for(int i = 1; i < Options.Count + 1; i++)
            {
                Console.WriteLine($"     {i} : {Options[i - 1]}");
            }
            Console.WriteLine($"     {Options.Count() + 1} : Back to publisher selection");

            return Options.Count + 1;

        }

        protected override void OptionSelected(int index)
        {
            switch (index)
            {
                case 0:
                    NewInstruction();
                    Console.WriteLine($"----- {dev.Name} - Description -----");
                    Console.Write(dev.Description);
                    break;
                case 1:
                    NewInstruction();
                    Console.WriteLine($"----- {dev.Name} - Email -----");
                    Console.Write(dev.Email);
                    break;
                case 2:
                    NewInstruction();
                    Console.WriteLine($"----- {dev.Name} - Apps -----");
                    foreach(var app in dev.Apps)
                    {
                        Console.WriteLine("----------------");
                        Console.WriteLine("Name : " + app.Name);
                        Console.Write("Description : " + app.Description);
                        Console.WriteLine("Category : " +app.Category);
                        Console.WriteLine("Downloads : " + app.Downloads);
                        Console.WriteLine("Price : "+app.Price + " $");
                        Console.WriteLine("Publish date : " +app.PublishDate);
                        
                    }
                    if(dev.Apps.Count < 1)
                    {
                        Console.WriteLine("   No app found");
                    }
                    break;
               
            }
        }
    }
}
