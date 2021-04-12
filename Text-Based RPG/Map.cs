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



        public Map(Camera camera)
        {
            mapData = System.IO.File.ReadAllLines("Map.txt");
            for (int y = 0; y <= mapData.Length - 1; y++)
            {
                string currentMapLine = mapData[y];
                for (int x = 0; x <= currentMapLine.Length - 1; x++)
                {
                    char mapTile = currentMapLine[x];
                    map[x, y] = mapTile;
                }
            }
            
        }


        public void DisplayMap(Camera camera, Render render, Map map)
        { 
            Console.SetCursorPosition(0, 0);

            for (int y = camera.Ystart; y < camera.Yend; y++)
            {
                for (int x = camera.Xstart; x < camera.Xend; x++)
                {
                    render.MapDraw(x, y, camera, map);
                }
                Console.WriteLine();
                
            }

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
