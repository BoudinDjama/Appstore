using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreConsole
{
    public class MainMenu
    {
        IEnumerable<Viewer> viewers = typeof(Viewer)
   .Assembly.GetTypes()
   .Where(t => t.IsSubclassOf(typeof(Viewer)) && !t.IsAbstract)
   .Select(t => (Viewer)Activator.CreateInstance(t));


        public void Select()
        {
            do
            {
                int o = Menu();

                try
                {
                    int.TryParse(Console.ReadLine(), out int key);
                    if (key == o)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        viewers.ElementAt(key - 1).Select();
                        
                    }
                }
                catch
                {
                    continue;
                }
            } while (true);

        }



        public int Menu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(new string(' ', 100));
            Console.ResetColor();
            Console.WriteLine($"----- Main menu -----");
            Console.WriteLine(" Choose an option");
            for (int i = 1; i < viewers.Count() + 1; i++)
            {
                Console.WriteLine($"     {i} : {viewers.ElementAt(i - 1).MenuTitle}");
            }
            Console.WriteLine($"     {viewers.Count() + 1} : Quit");

            return viewers.Count() + 1;
        }
    }
}
