using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {

        public char[,] map = new char[160, 37];
        public string[] mapData;
        private int x;
        private int y;



        public Map()
        {
            mapData = System.IO.File.ReadAllLines("Map.txt");
            for (y = 0; y <= mapData.Length - 1; y++)
            {
                string currentMapLine = mapData[y];
                for (x = 0; x <= currentMapLine.Length - 1; x++)
                {
                    char mapTile = currentMapLine[x];
                    map[x, y] = mapTile;
                }
            }
        }


        public void DisplayMap()
        {
            Console.Clear();
            for (y = 0; y <= mapData.Length - 1; y++)
            {
                Console.WriteLine(mapData[y]);
            }

        }

        public bool IsFloor(int y, int x)
        {
            if (map[x, y] == ' ')
            {
                return true;
            }
            else if (map[x, y] == '█')
            {
                if (Key.hasKey == true)
                {
                    Key.hasKey = false;
                    return true;
                }
                else return false;
            }
            else return false;

        }
    }
}
