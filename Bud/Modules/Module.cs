using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bud.Screens;

namespace Bud.Modules
{
    //The idea of a Module is a potentially self contained collection of screens and logic, 
    //with the Module class itself maintaining any specific context info it would require.
    interface Module
    {
        //Called before loadScreen to do basic setup.
        void init();
        //Load a screen. Module logic handles what screen to show.
        Screen getScreen();
        //Render current screen.
        void render();
    }
}
