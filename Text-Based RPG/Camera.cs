using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Camera
    {
        public int offsetX;
        public int offsetY;


        public int Xstart;
        public int Xend = 50;

        public int Ystart;
        public int Yend = 24;

        /*public void Draw(Character character)
        {
            Console.SetCursorPosition(character.x + offsetX, character.y + offsetY);
        }*/

        /*public void Update()
        {
            if (offsetX <= -1)
            {
                Xstart = Xstart + 1;
                offsetX = offsetX + 1;
            }
            if (offsetY <= -1)
            {
                Ystart = Ystart + 1;
                offsetY = offsetY + 1;
            }
            if (offsetX >= 1)
            {
                Xstart = Xstart - 1;
                offsetX = offsetX - 1;
            }
            if (offsetY >= 1)
            {
                Ystart = Ystart - 1;
                offsetY = offsetY - 1;
            }
            if (Xstart <= 0)
            {
                Xstart = 0;
            }
            if (Ystart <= 0)
            {
                Ystart = 0;
            }
        }*/


    }

    
}
