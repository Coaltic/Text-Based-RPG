using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Render 
    {
        public void Draw(int x, int y, string character, Camera camera, Map map)
        {
            //Console.SetCursorPosition(x + camera.offsetX, y + camera.offsetY);
            //Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);

            Console.SetCursorPosition(x - camera.offsetX, y - camera.offsetY);
            Console.Write(character);
        }

        public void MapDraw(int x, int y, Camera camera, Map map)
        {
            
            Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);
        }
    }
}
