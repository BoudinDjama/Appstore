using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appstore.DataSqlite;
using Appstore.Models;
using static System.Net.Mime.MediaTypeNames;

namespace AppStoreConsole
{
    public class Program
    {
        static void Main(string[] args)
        {

            MainMenu starter = new MainMenu();
            starter.Select();
            
            

        }
        
        
    }
}
