using System;
using System.Timers;

namespace Text_Based_RPG
{
    class Render 
    {
        private int mapXstart;
        private int mapYstart;
        private int mapXend;
        private int mapYend;

        public void Draw(int x, int y, string character, Camera camera)
        {
            mapXend = camera.Xend + camera.offsetX;
            mapYend = camera.Yend + camera.offsetY;
            mapXstart = camera.Xstart + camera.offsetX;
            mapYstart = camera.Ystart + camera.offsetY;

            if (x < mapXend && y < mapYend && x > mapXstart && y > mapYstart)
            {
                Console.SetCursorPosition(x - camera.offsetX, y - camera.offsetY);
                Console.Write(character);
            }
        }

        public void MapDraw(int x, int y, Camera camera, Map map)
        {
            string currentMapLine = map.mapData[y];

            if (x + camera.offsetX > currentMapLine.Length || x + camera.offsetX < 0)
            {
                Console.Write(" ");
            }
            else if (y + camera.offsetY > map.mapData.Length || y + camera.offsetY < 0)
            {
                Console.Write(" ");
            }
            else
            {
                Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);
            }
        }

        public void ScrollSetMap(Player player, Camera camera, Map map)
        {
            mapXend = camera.Xend + camera.offsetX;
            mapYend = camera.Yend + camera.offsetY;
            mapXstart = camera.Xstart + camera.offsetX;
            mapYstart = camera.Ystart + camera.offsetY;

            if (player.x == mapXend)
            {
                camera.offsetX = camera.offsetX + camera.Xend;
                MapDraw(player.x, player.y, camera, map);
            }
            else if (player.x == mapXstart)
            {
                camera.offsetX = camera.offsetX - camera.Xend;
                MapDraw(player.x, player.y, camera, map);
            }
            if (player.y == mapYend)
            {
                camera.offsetY = camera.offsetY + camera.Yend;
                MapDraw(player.x, player.y, camera, map);
            }
            if (player.y == mapYstart)
            {
                camera.offsetY = camera.offsetY - camera.Yend;
                MapDraw(player.x, player.y, camera, map);
            }
        }

        public void ScrollDrawMap(int direction, Camera camera, Player player, Map map)
        {
            if (direction == 1)
            {
                for (int i = 0; i < mapXend; i++)
                {
                    /*SetTimer();
                    scrollTimer.Elapsed += OnTimedEvent;
                    scrollTimer.AutoReset = true;
                    scrollTimer.Enabled = true;*/
                    camera.offsetX++;
                    MapDraw(player.x, player.y, camera, map);
                }
            }
        }
    }
}
