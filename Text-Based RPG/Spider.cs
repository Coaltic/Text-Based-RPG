using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Spider : Enemy
    {
        public Spider(int x, int y)
        {
            this.Icon = "S";
            this.x = x;
            this.y = y;
            this.speed = 3;
            this.alive = true;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

        /*public void Movement(Map map)
        {

            if (checkpoint == false)
            {

                right++;
                x++;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(Icon);                            // enemy moves right for 10 spaces 
                Console.SetCursorPosition(x - 1, y);
                Console.Write(map.mapArray[y, x - 1]);

                if (right > 9)
                {
                    right = 0;
                    checkpoint = true;
                }



            }
            else if (checkpoint == true)
            {
                left++;
                x--;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(Icon);                            // enemy moves back to the left for 10 spaces 
                Console.SetCursorPosition(x + 1, y);
                Console.Write(map.mapArray[y, x + 1]);

                if (left > 9)
                {
                    left = 0;
                    checkpoint = false;
                }
            }*/



        
    }
}
