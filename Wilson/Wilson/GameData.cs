using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilson
{
    class GameData
    {
        public class GameObj
        {

        }

        IWilson interf;

        public char[,] scene;

        int w, h;

        public GameData(int _w, int _h, IWilson _interf)
        {
            w = _w;
            h = _h;
            scene = new char[w, h];
            interf = _interf;
        }

        public GameData(char[,] _scene, IWilson _interf)
        {
            w = _scene.GetLength(0);
            h = _scene.GetLength(1);
            scene = _scene;
            interf = _interf;
        }

        public void Tick()
        {
            interf.Loop();
        }

        void CheckWindowSize()
        {
            if (w != Console.WindowWidth || h != Console.WindowHeight)
            {

            }
        }
    }
}
