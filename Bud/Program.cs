using Bud.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bud
{
    class Program
    {
        static void Main(string[] args)
        {
            Context.loadContext();
            mainLoop();
        }

        static void mainLoop()
        {
            while(true)
            {
                //todo, limit this to run at a max of... 10 fps? instead of just spinning
                Context.CURRENT_SCREEN.render();
                Context.CURRENT_SCREEN.processInput(Console.ReadKey());
            }
        }
    }
}
