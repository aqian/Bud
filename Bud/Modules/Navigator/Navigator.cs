using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bud.Screens;

namespace Bud.Modules.Navigator
{
    class NavigatorModule : Module
    {
        private static string SCREEN_MAIN = "main";

        private Dictionary<string, Screen> screens = new Dictionary<string, Screen>();
        private Screen currentScreen;

        public void init()
        {
            screens.Add(SCREEN_MAIN, new NavigatorMainScreen());
            currentScreen = screens[SCREEN_MAIN];
        }

        public Screen getScreen()
        {
            return currentScreen;
        }

        public void render()
        {
            currentScreen.render();
        }
    }
}
