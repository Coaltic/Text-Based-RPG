using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {

        public char[,] map = new char[220, 58];
        public string[] mapData;
        public int x;
        public int y;



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
            for (y = 0; y <= 57; y++)
            {
                for (x = 0; x <= 209; x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
                x = 0;
            }

            y = 0;

        }

        public bool IsFloor(int y, int x)
        {
            if (map[x, y] == ' ')
            {
                return true;
            }
            else return false;

        }

        public bool IsDoor(int y, int x, Player player)
        {
            
            if (map[x, y] == '█')
            {
                if (player.hasKey == true)
                {
                    map[x, y] = ' ';
                }
                return true;
            }
            else return false;

        }

    }
}
