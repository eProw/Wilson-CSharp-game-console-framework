using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilsonTest
{
    class CaveGen
    {
        int w, h;
        public char[,] map;

        public CaveGen(int _w, int _h)
        {
            w = _w;
            h = _h;
            map = new char[w, h];
            GenerateMap();
        }
        Random r = new Random();

        public void GenerateMap()
        {
            SetRandomMap();
            for (int i = 0; i < 3; i++)
            {
                SmoothMap();
            }
        }

        void SetRandomMap()
        {
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    map[x, y] = r.Next(0, 100) > 50 ? 'O' : ' ';
                }
            }
        }

        void SmoothMap()
        {
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    int neighbours = GetNeighBours(x, y);

                    if (neighbours > 4)
                        map[x, y] = 'O';
                    else if (neighbours < 4)
                        map[x, y] = ' ';
                }
            }
        }

        int GetNeighBours(int offsetX, int offsetY)
        {
            int neighbours = 0;
            for (int x = offsetX - 1; x <= offsetX + 1; x++)
                for (int y = offsetY - 1; y <= offsetY + 1; y++)
                {
                    if (x >= 0 && x < w && y >= 0 && y < h)
                    {
                        if (x != offsetX || y != offsetY)
                        {
                            if (map[x, y] == 'O')
                                neighbours++;
                        }
                    }
                    else
                        neighbours++;
                }

            return neighbours;
        }
    }
}
