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

        public void Update(Map map)
        {

            if (checkpoint == false)
            {
                
                
                    right = right + 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.map[x, y]);
                    x = x + speed;                                  // player moves right
                
                


                if (right >= 10)
                {
                    right = 0;
                    checkpoint = true;
                }



            }
            else if (checkpoint == true)
            {
                
                
                    left = left + 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.map[x, y]);                         // player moves down
                    x = x - speed;
                
                

                if (left >= 10)
                {
                    left = 0;
                    checkpoint = false;
                }
            }
        }



        public static void CheckForPlayer(Enemy enemy, Player player)
        {
            
            
                if (player.x == enemy.x && player.y == enemy.y)
                {
                    
                    

                        player.TakeDamage(player, enemy);

                    
                }
                

            
        }

        public void TakeDamage(Enemy enemy, Player player)
        {
            if (Sword.hasSword)
            {
                player.sword = 15;
            }

            enemy.health = enemy.health - (player.sword + player.attack);
            

            if (enemy.health <= 0)
            {
                enemy.health = 0;
                enemy.alive = false;
                
                
            }

            Hud.ShowEnemyStats(enemy);

        }
    }
}
