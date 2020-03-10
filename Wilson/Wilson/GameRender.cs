using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilson
{
    class GameRender
    {
        int w, h;

        int xPos = 0, yPos = 0;

        char[,] lastFrame, lastInterfFrame;

        public GameRender(int _w, int _h)
        {
            w = _w;
            h = _h;
            lastFrame = new char[Console.WindowWidth,Console.WindowHeight];
            lastInterfFrame = new char[Console.WindowWidth, Console.WindowHeight];

        }

        public void Render(char[,] screen,char[,] interf)
        {
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    if ((x + xPos) < screen.GetLength(0) && (y + yPos) < screen.GetLength(1) && x+xPos>0&& y+yPos>0)
                    {
                        //if (screen[x+xPos,y+yPos] != lastFrame[x,y] || interf[x,y] != lastInterfFrame[x,y]) {
                            Console.SetCursorPosition(x, y);
                            if (interf != null)
                            {
                                Console.Write(interf[x, y] == '~' ? screen[x + xPos, y + yPos] : interf[x, y]);
                            }
                            else
                            {
                                Console.Write(screen[x + xPos, y + yPos]);
                            }

                            lastFrame[x, y] = screen[x + xPos, y + yPos];
                            lastInterfFrame[x, y] = interf[x, y];
                       // }
                       // else
                       // {

                           /* if(interf != null) {
                                if(interf[x,y]!= '~') {
                                    Console.SetCursorPosition(x, y);
                                    Console.Write(interf[x, y]);
                                }
                            }*/
                        //}

                    }
                }
        }

        public void SetCameraPos(int x, int y)
        {
            xPos = x;
            yPos = y;
        }
    }
}
