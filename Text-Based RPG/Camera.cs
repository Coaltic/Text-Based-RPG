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

        public void Update()
        {
            if (offsetX <= -1)
            {
                offsetX = 0;
            }
            if (offsetY <= -1)
            {
                offsetY = 0;
            }
        }


    }

    
}
