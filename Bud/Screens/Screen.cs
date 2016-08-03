using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bud.Screens
{
    interface Screen
    {
        void render();
        void processInput(ConsoleKeyInfo input);
        void cleanup();
    }
}
