using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player : Character
    {
        public int sword = 0;
        static public bool hasSword = false;
        static public bool hasKey = false;

        public Player(int x, int y)
        {
            this.Icon = "@";
            this.x = x;
            this.y = y;
            this.attack = 25;
            this.health = 100;
            this.alive = true;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

        

        public void Update(Map map)
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            if (input.KeyChar == 'w')
            {
                if (map.IsFloor(y - 1, x) == true)
                {

                    //y = y - 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.map[x, y]);                            // player moves up
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
                    Console.Write(map.map[x, y]);
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
                    Console.Write(map.map[x, y]);                             // player moves left
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
                    Console.Write(map.map[x, y]);                         // player moves down
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
            
            if (enemy.x == player.x && enemy.y == player.y)
            {
                
                
                    enemy.TakeDamage(enemy, player);
                                                        // enemy = null; <---- save for future use
                
            }
        }

        public void TakeDamage(Player player, Enemy enemy)
        {
            player.health = player.health - enemy.attack;
            

            if (player.health <= 0)
            {
                player.health = 0;
                player.alive = false;
                
                player = null;
            }

            //Hud.ShowPlayerStats(player, map);

        }


    }
}
