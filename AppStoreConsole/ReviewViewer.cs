using Appstore.DataSqlite;
using Appstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreConsole
{
    public class ReviewViewer : Viewer
    {

        protected Review review { get; set; }
        protected List<Review> reviews { get; set; }

        public ReviewViewer() : base("Reviews")
        {
            Options = new List<string> { "Description", "App" };
            reviews = new AppstoreContext().Reviews.ToList();
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
                        review = reviews.ElementAt(key - 2);
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
            Console.WriteLine(" Choose a review");
            Console.WriteLine($"     1 : Back to main menu");
            Console.WriteLine("");
            for (int i = 1; i < reviews.Count + 1; i++)
            {
                Console.WriteLine($"     {i + 1} : {reviews[i - 1].App.Name} - {reviews[i - 1].Rating}");
            }
            return 1;
        }

        protected override int OptionMenu()
        {
            NewInstruction();
            Console.WriteLine($"----- {MenuTitle} - {review.App.Name} - {review.Rating} -----");
            Console.WriteLine("Rating : " + review.Rating);
            Console.WriteLine("Author : " + review.Author);
            Console.WriteLine("Publish date : " + review.PublishDate);
            Console.WriteLine("----------------");
            Console.WriteLine(" Choose an option");
            for (int i = 1; i < Options.Count + 1; i++)
            {
                Console.WriteLine($"     {i} : {Options[i - 1]}");
            }
            Console.WriteLine($"     {Options.Count() + 1} : Back to reviews selection");

            return Options.Count + 1;

        }

        protected override void OptionSelected(int index)
        {
            switch (index)
            {
                case 0:
                    NewInstruction();
                    Console.WriteLine($"----- {review.App.Name} -Review description -----");
                    Console.Write(review.Description);
                    break;
                case 1:
                    NewInstruction();
                    Console.WriteLine("----------------");
                    Console.WriteLine("Name : " + review.App.Name);
                    Console.Write("Description : " + review.App.Description);
                    Console.WriteLine("Category : " + review.App.Category);
                    Console.WriteLine("Downloads : " + review.App.Downloads);
                    Console.WriteLine("Price : " + review.App.Price + " $");
                    Console.WriteLine("Publish date : " + review.App.PublishDate);
                    break;
              
            }
        }
    }
}
