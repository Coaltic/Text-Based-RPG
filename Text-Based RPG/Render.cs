using System;

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
            //Console.SetCursorPosition(x + camera.offsetX, y + camera.offsetY);
            //Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);

            if (x < mapXend && y < mapYend && x > mapXstart && y > mapYstart)
            {
                Console.SetCursorPosition(x - camera.offsetX, y - camera.offsetY);
                Console.Write(character);
            }
        }

        public void MapDraw(int x, int y, Camera camera, Map map)
        {
            
            Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);
        }
    }
}
