using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bud.Screens;
using Bud.Widgets;

namespace Bud.Modules.Navigator
{
    class NavigatorMainScreen : Screen
    {
        MenuList menu;
        List<string> optionList;

        public NavigatorMainScreen(Screen returnScreen = null)
        {
            optionList = new List<string>() { "My Computer", "Sample Bookmark 1", "Sample Bookmark 2" };
            menu = new MenuList();
            menu.addOptionList(optionList);
        }

        public void render()
        {
            Console.Clear();
            Console.WriteLine("*** NAVIGATOR ***\n");
            Console.WriteLine("Launch from:");
            menu.render();
        }

        public void processInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.B:
                    Context.backScreen();
                    break;
                case ConsoleKey.W:
                case ConsoleKey.S:
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                    menu.processInput(key);
                    break;
            }
        }

        public void cleanup() { }
    }
}
