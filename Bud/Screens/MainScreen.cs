using Bud.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bud.Screens
{
    class MainScreen : Screen
    {
        MenuList menu;
        List<string> optionList;

        public MainScreen()
        {
            menu = new MenuList();
            optionList = new List<string>() { "Option 1", "Option 2", "Option 3" };
            menu.addOptionList(optionList);
        }

        public void render()
        {
            Console.Clear();
            Console.WriteLine("Hello, " + Context.NAME + "!\nWelcome to Bud!");
            Console.SetCursorPosition(0, 5);
            menu.render();
        }

        public void processInput(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.Enter:
                    break;
                default:
                    menu.processInput(input);
                    break;
            }
        }
    }
}
