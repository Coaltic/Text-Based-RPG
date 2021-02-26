using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player : Character
    {
        //public string playerIcon = "@";
        //static public ConsoleKeyInfo input;
        //public bool moving = true;



        public Player(int x, int y)
        {
            this.Icon = "@";
            this.x = x;
            this.y = y;
            this.alive = true;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

        

        public void Movement(Map map)
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            if (input.KeyChar == 'w')
            {
                if (map.IsFloor(y - 1, x) == true)
                {

                    //y = y - 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.mapArray[y, x]);                            // player moves up
                    y = y - 1;
                    
                          // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 'd')
            {
                if (map.IsFloor(y, x + 1) == true)
                {
                    
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.mapArray[y, x]);
                    x = x + 1;                                  // player moves right
                    
                                                        // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 's')
            {
                if (map.IsFloor(y + 1, x) == true)
                {
                    
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.mapArray[y, x]);                             // player moves left
                    y = y + 1;
                    
                                                        // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 'a')
            {
                if (map.IsFloor(y, x - 1) == true)
                {
                    
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.mapArray[y, x]);                         // player moves down
                    x = x - 1;
                    
                                                        // previous tile is replaced by map tile
                }
                else { Collision(); }
            }



        }

        public void Collision()
        {
            Console.Beep(100, 200);                                     // left as a method for future possible additions
        }

        public static void CheckForEnemy(Player player, Enemy enemy)
        {
            
            if (enemy.x == player.x)
            {
                if (enemy.y == player.y)
                {
                    Console.SetCursorPosition(51, 1);   // player checks if they have attacked the enemy
                    Console.WriteLine("Enemy hit");
                    enemy.alive = false;  
                                                        // enemy = null; <---- save for future use
                }
            }
        }


    }
}
