using Appstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStoreConsole
{
    public abstract class Viewer
    {
        public List<string> Options { get; protected set; }
        public string MenuTitle { get; private set; }
        public Viewer(string menutitle)
        {
            MenuTitle = menutitle;
        }
        public void NewInstruction()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(new string(' ', 100));
            Console.ResetColor();
        }

        
        public abstract void Select();
        protected abstract int Menu();

        protected abstract void SelectOption();
        protected abstract int OptionMenu();

        protected abstract void OptionSelected(int index);
    }
}
