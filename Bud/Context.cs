using Bud.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string NAME { get; set; }

        public static bool DEBUG { get; set; }

        public static bool isCursorVisible() { return Console.CursorVisible; }
        public static void setCursorVisible(bool visible) {
            Console.CursorVisible = visible;
        }

        public static void loadContext()
        {
            NAME = "Alex";
            setCursorVisible(false);
            COLOR_BACKGROUND = ConsoleColor.Black;
            COLOR_FOREGROUND = ConsoleColor.White;
            COLOR_SELECTED = ConsoleColor.Cyan;
            COLOR_DEBUG = ConsoleColor.Yellow;
            CURRENT_SCREEN = new MainScreen();
            DEBUG = true;
        }

        public static void debug(string message)
        {
            if (DEBUG)
            {
                Console.ForegroundColor = COLOR_DEBUG;
                Console.WriteLine(message);
                Console.ForegroundColor = COLOR_FOREGROUND;
            }
        }

    }
}
