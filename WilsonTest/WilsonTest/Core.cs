using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wilson;

namespace WilsonTest
{
    class Core:IWilson
    {
        Game g;
        CaveGen cave;
        bool menu = false, init = false;
        int x = 0, y = 0;

        public Core()
        {
            g = new Game(this);
            cave = new CaveGen(1200,500);
            g.CreateScene(cave.map);
            int w = Console.WindowWidth, h = Console.WindowHeight;
            g.Start();
            
            
        }

        public void Loop()
        {
            if (menu)
            {
                g.EnableGUI();
                init = true;
            }
            else
            {
                if (init)
                {
                    g.DisableGUI();
                }
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo k = Console.ReadKey(true);
                if (k.Key==ConsoleKey.T)
                {
                    menu = !menu;
                }
            }

            x++;
            y++;
            g.SetCameraPos(x,y);
        }
    }
}
