using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : Character
    {

        static public int EnemyLimit = 10;
        public int deathTally;
        public bool checkpoint = false;
        public int right = 0;
        public int left = 0;

        private int enemyType;

        Random rnd = new Random();

        public void SetEnemy(int x, int y, int type)
        {
            enemyType = type;
            this.x = x;
            this.y = y;
            alive = true;


            if (type == 1)
            {
                Icon = "S";
                health = 200;
                attack = 30;
            }
            else if (type == 2)
            {
                Icon = "Z";
                health = 100;
                attack = 20;
            }
            else if (type == 3)
            {
                Icon = "R";
                health = 50;
                attack = 15;
            }

            /*Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);*/

        }


        public void Update(Map map, Player player, Enemy enemy, Camera camera)
        {
            if (enemy.alive == true)
            {
                if (enemyType == 1)
                {
                    if (player.IsPlayerNear(enemy.x, enemy.y, player) == true)
                    {
                        player.TakeDamage(player, enemy);
                        Console.Beep(100, 100);
                    }
                    else if (player.IsPlayerNear(enemy.x, enemy.y, player) == false)
                    {
                        EnemyAI1(map, enemy);
                    }
                }
                else if (enemyType == 2)
                {
                    if (player.IsPlayerNear(enemy.x, enemy.y, player) == true)
                    {
                        player.TakeDamage(player, enemy);
                        Console.Beep(100, 100);
                    }
                    else if (player.IsPlayerFar(enemy.x, enemy.y, player) == true)
                    {
                        EnemyAI2(map, enemy, player);
                    }
                }
                else if (enemyType == 3)
                {
                    if (player.IsPlayerNear(enemy.x, enemy.y, player) == true)
                    {
                        player.TakeDamage(player, enemy);
                        Console.Beep(100, 100);
                    }
                    else if (player.IsPlayerNear(enemy.x, enemy.y, player) == false)
                    {
                        EnemyAI3(map, enemy);
                    }
                }
            }
            
        }

        public void TakeDamage(Enemy enemy, Player player)
        {
            if (player.hasSword == true)
            {
                enemy.health = enemy.health - (player.attack + 15);
            }
            else if (player.hasSword == false)
            {
                enemy.health = enemy.health - player.attack;
            }

            

            if (enemy.health <= 0)
            {
                enemy.health = 0;
                enemy.alive = false;
                Icon = "";
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(" ");
                enemy.x = 0;
                enemy.y = 0;

                
                
            }

            Hud.ShowEnemyStats(enemy);

        }

        public void EnemyAI1(Map map, Enemy enemy)
        {
            int num = rnd.Next(5);

            //Console.Write(enemy.x + ", " + enemy.y);

            if (num == 1 && map.IsFloor(enemy.y - 1, enemy.x) == true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(map.map[x, y]);
                enemy.y--;
            }
            else if (num == 2 && map.IsFloor(enemy.y, enemy.x + 1) == true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(map.map[x, y]);
                enemy.x++;
            }
            else if (num == 3 && map.IsFloor(y + 1, x) == true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(map.map[x, y]);
                enemy.y++;
            }
            else if (num == 4 && map.IsFloor(y, x - 1) == true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(map.map[x, y]);
                enemy.x--;
            }

        }

        public void EnemyAI2(Map map, Enemy enemy, Player player)
        {
            if (enemy.y < player.y && map.IsFloor(y + 1, x) == true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(map.map[x, y]);
                enemy.y++;
            }
            else if (enemy.y > player.y && map.IsFloor(y - 1, x) == true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(map.map[x, y]);
                enemy.y--;
            }
            else if (enemy.x < player.x && map.IsFloor(y, x + 1) == true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(map.map[x, y]);
                enemy.x++;
            }
            else if (enemy.x > player.x && map.IsFloor(y, x - 1) == true)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(map.map[x, y]);
                enemy.x--;
            }
        }

        public void EnemyAI3(Map map, Enemy enemy)
        {
            if (enemy.checkpoint == false)
            {

                if (map.IsFloor(y, x + 1) == true)
                {
                    /*if (item.IsItem(enemy.x, enemy.y + 1, item) == true)
                    {
                        right = 10;
                    }*/

                    //right = right + 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.map[x, y]);
                    enemy.x++; ;
                }
                else { enemy.checkpoint = true; }


                /*if (right >= 10)
                {
                    right = 0;
                    enemy.checkpoint = true;
                }*/

            }
            else if (enemy.checkpoint == true)
            {
                if (map.IsFloor(y, x - 1) == true)
                {
                    //left = left + 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.map[x, y]);
                    x--;
                }
                else { enemy.checkpoint = false; }


                /*if (left >= 10)
                {
                    left = 0;
                    enemy.checkpoint = false;
                }*/
            }
        }

        
    }
}
