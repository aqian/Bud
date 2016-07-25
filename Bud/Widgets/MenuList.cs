using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bud.Widgets
{
    class MenuList : Widget
    {
        private List<string> items;
        private int selected;

        public MenuList()
        {
            selected = 0;
            items = new List<string>();
        }

        public string getSelectedOption() { return items[selected]; }
        public int getSelectedOptionInt() { return selected; }
        
        public void addOption(string name)
        {
            items.Add(name);
        }

        public void addOptionList(List<string> options)
        {
            items.AddRange(options);
        }

        public void removeOption(string name)
        {
            items.Remove(name);
        }

        public void render()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (selected == i)
                {
                    Console.ForegroundColor = Context.COLOR_SELECTED;
                    Console.WriteLine("-" + items[i] + "-");
                    Console.ForegroundColor = Context.COLOR_FOREGROUND;
                } else
                {
                    Console.WriteLine(items[i]);
                }
                
            }
            Context.debug("Selected: " + selected);
        }

        public void processInput(ConsoleKeyInfo input)
        {
            switch(input.Key)
            {
                case ConsoleKey.UpArrow:
                    selected = (selected == 0) ? items.Count - 1 : selected-=1;
                    break;
                case ConsoleKey.DownArrow:
                    selected = (selected == items.Count - 1) ? 0 : selected+=1;
                    break;
            }
        }
    }
}
