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
                if (map.IsFloor(y + 1, x) == true)
                {
                    right = right + 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.map[x, y]);
                    x = x + 1;                              // player moves right
                }
                else { right = 10; }


                if (right >= 10)
                {
                    right = 0;
                    checkpoint = true;
                }



            }
            else if (checkpoint == true)
            {
                if (map.IsFloor(y + 1, x) == true)
                {
                    left = left + 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.map[x, y]);                         // player moves down
                    x = x - 1;
                }
                else { left = 10; }
                

                if (left >= 10)
                {
                    left = 0;
                    checkpoint = false;
                }
            }
        }

        public bool IsEnemy(int y, int x, Enemy enemy)
        {
            if (enemy.x == x && enemy.y == y)
            {
                return true;

            }
            else
            {
                return false;
            }

        }


        public static void CheckForPlayer(Enemy enemy, Player player)
        {
            
            
                if (enemy.x == player.x && enemy.y == player.y)
                {
                    
                    

                        player.TakeDamage(player, enemy);

                    
                }
                

            
        }

        



        public void TakeDamage(Enemy enemy, Player player)
        {

            enemy.health = enemy.health - player.attack;
            

            if (enemy.health <= 0)
            {
                enemy.health = 0;
                enemy.alive = false;
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(" ");
                enemy.x = 0;
                enemy.y = 0;



            }

            Hud.ShowEnemyStats(enemy);

        }
    }
}
