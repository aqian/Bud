using Bud.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bud.Modules;

namespace Bud
{
    static class Context
    {
        public static int SCREEN_WIDTH { get; set; }
        public static int SCREEN_HEIGHT { get; set; }
        public static Screen CURRENT_SCREEN { get; set; }

        public static ConsoleColor COLOR_BACKGROUND { get; set; }
        public static ConsoleColor COLOR_FOREGROUND { get; set; }
        public static ConsoleColor COLOR_SELECTED { get; set; }
        public static ConsoleColor COLOR_DEBUG { get; set; }
        public static ConsoleColor COLOR_ERROR { get; set; }

        public static string NAME { get; set; }

        public static bool DEBUG { get; set; }
        public static bool ERROR { get; set; }

        public static bool isCursorVisible() { return Console.CursorVisible; }
        public static void setCursorVisible(bool visible) {
            Console.CursorVisible = visible;
        }

        //contains all previous screens. current screen is available through CURRENT_SCREEN
        private static Stack<Screen> screenStack;

        //initialize the program. Must run first.
        public static void loadContext()
        {
            NAME = "Alex";
            setCursorVisible(false);
            COLOR_BACKGROUND = ConsoleColor.Black;
            COLOR_FOREGROUND = ConsoleColor.White;
            COLOR_SELECTED = ConsoleColor.Cyan;
            COLOR_DEBUG = ConsoleColor.Yellow;
            COLOR_ERROR = ConsoleColor.Red;
            screenStack = new Stack<Screen>();
            CURRENT_SCREEN = new MainScreen();
            DEBUG = true;
        }

        //Print a debug message at the current cursor location if the DEBUG flag is set
        public static void debug(string message)
        {
            if (DEBUG)
            {
                Console.ForegroundColor = COLOR_DEBUG;
                Console.WriteLine(message);
                Console.ForegroundColor = COLOR_FOREGROUND;
            }
        }

        //Print an error message at the current cursor location if the ERROR flag is set 
        public static void error(string message, Exception e = null)
        {
            if (ERROR)
            {
                Console.ForegroundColor = COLOR_DEBUG;
                Console.WriteLine(message);
                if (e != null) Console.WriteLine(e.Message);
                Console.ForegroundColor = COLOR_FOREGROUND;
            }
        }

        //Transition to a new screen within a module.
        public static void transition(Screen toScreen)
        {
            //push the origin screen onto stack
            screenStack.Push(CURRENT_SCREEN);
            CURRENT_SCREEN = toScreen;            
            //CURRENT_SCREEN.render();
        }

        //Move back to the previous screen and cleanup the current screen.
        public static void backScreen()
        {
            try
            {
                CURRENT_SCREEN.cleanup();
                CURRENT_SCREEN = screenStack.Pop();
                //CURRENT_SCREEN.render();
            }
            catch (InvalidOperationException e)
            {
                error("ERROR: No screen to go back to.", e);
            }
        }

        //load a module and transition to module's main screen
        public static void loadModule(Module m)
        {
            m.init();
            screenStack.Push(CURRENT_SCREEN);
            CURRENT_SCREEN = m.getScreen();
        }

        //todo: unload module / cleanup

    }
}
