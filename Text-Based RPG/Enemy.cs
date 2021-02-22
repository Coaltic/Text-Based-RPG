using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : Character
    {


        public bool checkpoint = false;
        public bool checkpoint2 = false;
        public int point1 = 35;
        public int point2 = 25;
        int right = 0;
        int left = 0;

        public Enemy(int x, int y)
        {
            this.Icon = "E";
            this.EnemyX = x;
            this.EnemyY = y;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

        public void Movement(Map map)
        {

            

            if (checkpoint == false)
            {

                right++;
                EnemyX++;
                Console.SetCursorPosition(EnemyX, EnemyY);
                Console.WriteLine(Icon);                            // enemy moves right for 10 spaces 
                Console.SetCursorPosition(EnemyX - 1, EnemyY);
                Console.Write(map.mapArray[EnemyY, EnemyX - 1]);

                if (right > 9)
                {
                    right = 0;
                    checkpoint = true;
                }

                
                
            }
            else if (checkpoint == true)
            {
                left++;
                EnemyX--;
                Console.SetCursorPosition(EnemyX, EnemyY);
                Console.WriteLine(Icon);                            // enemy moves back to the left for 10 spaces 
                Console.SetCursorPosition(EnemyX + 1, EnemyY);
                Console.Write(map.mapArray[EnemyY, EnemyX + 1]);

                if (left > 9)
                {
                    left = 0;
                    checkpoint = false;
                }
            }




            /*ConsoleKeyInfo input;
            input = Player.input;


            if (input.KeyChar == 'w')
            {
                y = y + 1; Console.SetCursorPosition(x, y);
                Console.WriteLine(enemyIcon);
            }
            else if (input.KeyChar == 'd')
            {
                x = x - 1; Console.SetCursorPosition(x, y);         // original enemy AI concept, could be used for a 2-player mode
                Console.WriteLine(enemyIcon);
            }
            else if (input.KeyChar == 's')
            {
                y = y - 1; Console.SetCursorPosition(x, y);
                Console.WriteLine(enemyIcon);
            }
            else if (input.KeyChar == 'a')
            {
                x = x + 1; Console.SetCursorPosition(x, y);
                Console.WriteLine(enemyIcon);
            }*/

            



        }
    }
}
