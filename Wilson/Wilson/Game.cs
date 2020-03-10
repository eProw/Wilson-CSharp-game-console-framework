using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilson
{
    public class Game
    {
        GameRender gr;
        GameData gd;

        int w = Console.WindowWidth, h = Console.WindowHeight;

        Interface GUI;

        IWilson interf;

        public Game(IWilson _interf)
        {
            interf = _interf;
            Console.CursorVisible = false;
            gr = new GameRender(w, h);
            GUI = new Interface();
        }

        bool run;

        public void Start()
        {
            if (gd != null)
            {
                Console.Title = "Game";
                run = true;
                Run();
            }
            else
            {
                Console.WriteLine("No existe una escena establecida.\nUtiliza la función 'CreateScene' para generar una nueva escena.\nPush any key to continue...");
                Console.ReadKey();
            }
        }

        void Run()
        {
            GUI.CreateInterface();

            while (run)
            {
                try
                {
                    gd.Tick();
                    gr.Render(gd.scene,GUI.gInterf);
                }
                catch (Exception e)
                {
                    Stop(e.ToString());
                }
            }
        }

        public void Stop(string exception)
        {
            run = false;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game has stopped running.\nPlease push a key to continue...\n" + exception);
            Console.ReadKey();
        }

        public void Stop()
        {
            run = false;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game has succesfully closed. Exit code 0");
            Console.ReadKey();
        }

        public void CreateScene(char[,] scene)
        {
            gd = new GameData(scene, interf);
        }

        public void CreateScene(int width, int height)
        {
            gd = new GameData(width, height, interf);
        }

        public void SetCameraPos(int x, int y)
        {
            gr.SetCameraPos(x, y);
        }

        public void EnableGUI()
        {
            GUI.LoadInterface();
        }

        public void DisableGUI()
        {
            GUI.CreateInterface(new char[Console.WindowWidth, Console.WindowHeight]);
            GUI.ClearInterface();
        }

        class Interface
        {

            public char[,] gInterf;

            public void CreateInterface(char[,] interf)
            {
                gInterf = interf;
            }

            public void CreateInterface()
            {
                gInterf = new char[Console.WindowWidth, Console.WindowHeight];
                
                ClearInterface();
                
            }

            public void LoadInterface()
            {
                for (int x = 0; x < Console.WindowWidth; x++)
                    for (int y = 0; y < Console.WindowHeight; y++)
                    {
                        if (y == Console.WindowHeight - 5)
                        {
                            gInterf[x, y] = '-';
                        }
                        else if (y > Console.WindowHeight - 5)
                        {
                            gInterf[x, y] = ' ';
                        }
                    }
            }

            public void ClearInterface()
            {
                for (int x = 0; x < Console.WindowWidth; x++)
                    for (int y = 0; y < Console.WindowHeight; y++)
                    {
                        gInterf[x, y] = '~';
                    }
            }
        }
    }
}
