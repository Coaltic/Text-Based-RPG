using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {

        public char[,] map = new char[141, 21];
        public string[] mapData;
        private int x;
        private int y;



        public void LoadMap()
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

        public Map()
        {
            //DisplayMap();
        }

        public void DisplayMap()
        {
            for (int x = 0; x <= 19; x++)
            {

                for (int y = 0; y <= 49; y++)
                {
                    Console.Write(map[x, y]);          // displays every row and line of the map
                }

                Console.WriteLine("");
            }

        }

        public bool IsFloor(int y, int x)
        {
            if (map[y, x] == ' ')
            {
                return true;
            }
            else return false;

        }
    }
}
