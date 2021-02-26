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
        //public bool checkpoint2 = false;
        //public int point1 = 35;
        //public int point2 = 25;
        public int right = 0;
        public int left = 0;
        public int speed;

        public Enemy()
        {
            
        }

        public void Movement(Map map)
        {

            if (checkpoint == false)
            {
                for (int movementLoop = 0; movementLoop <= speed; movementLoop++)
                {
                    right = right + 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.mapArray[y, x]);
                    x = x + 1;                                  // player moves right
                }
                


                if (right > 10)
                {
                    right = 0;
                    checkpoint = true;
                }



            }
            else if (checkpoint == true)
            {
                for (int movementLoop = 0; movementLoop <= speed; movementLoop++)
                {
                    left = left + 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.mapArray[y, x]);                         // player moves down
                    x = x - 1;
                }
                

                if (left > 10)
                {
                    left = 0;
                    checkpoint = false;
                }
            }
        }



        public static void CheckForPlayer(Enemy enemy, Player player)
        {
            for (int loop = 0; loop <= enemy.speed; loop++)
            {
                if ((enemy.x + loop == player.x) || (enemy.x - loop == player.x))
                {
                    if (enemy.y == player.y)
                    {
                        Console.SetCursorPosition(51, 1);
                        Console.WriteLine("Player hit");
                        Console.SetCursorPosition(51, 2);   // enemy checks if they have attacked the player
                        Console.WriteLine("GAME OVER");
                        //GameManager.gameplay = false;
                        player.alive = false;
                        //Console.ReadKey(true);
                    }
                }
                

            }
        }
    }
}
