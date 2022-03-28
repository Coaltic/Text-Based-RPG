using System;

namespace Text_Based_RPG
{
    class Map
    {
        public char[,] map = new char[240, 58];
        public string[] mapData;

        public Map()
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
            if (map[x, y] == ' ' || (map[x, y] == '–'))
            {
                return true;
            }

            else return false;
        }

        public bool IsDoor(int y, int x)
        {
            if (map[x, y] == '–')
            {
                map[x, y] = ' ';
                return true;
            }

            else return false;
        }

        public bool IsLockedDoor(int y, int x)
        {
            if (map[x, y] == '█')
            {
                map[x, y] = ' ';
                return true;
            }

            else return false;
        }

    }
}
