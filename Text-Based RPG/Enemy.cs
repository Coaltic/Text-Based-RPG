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
        public int right = 0;
        public int left = 0;

        private int enemyType;


        public void SetEnemy(int x, int y, int type)
        {
            enemyType = type;
            this.x = x;
            this.y = y;

            Console.Write("this is working");

            if (type <= 1)
            {
                Icon = "S";
                health = 100;
                attack = 25;
            }
            else if (type == 2)
            {
                Icon = "Z";
                health = 50;
                attack = 15;
            }
            else if (type == 3)
            {
                Icon = "R";
                health = 25;
                attack = 10;
            }

            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);

        }


        public void Update(Map map, Player player, Enemy enemy, Item item)
        {
            if (enemyType == 3)
            {
                if (player.IsPlayerNear(enemy.x, enemy.y, player) == true)
                {
                    player.TakeDamage(player, this);
                    Console.Beep(100, 100);
                }
                else if (player.IsPlayerNear(enemy.x, enemy.y, player) == false)
                {
                    EnemyAI3(map, item, enemy);
                }
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

        public void EnemyAI3(Map map, Item item, Enemy enemy)
        {
            if (enemy.checkpoint == false)
            {

                if (map.IsFloor(y + 1, x) == true)
                {
                    if (item.IsItem(enemy.x, enemy.y + 1, item) == true)
                    {
                        right = 10;
                    }

                    right = right + 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.map[x, y]);
                    x = x + 1;
                }
                else { right = 10; }


                if (right >= 10)
                {
                    right = 0;
                    enemy.checkpoint = true;
                }

            }
            else if (enemy.checkpoint == true)
            {
                if (map.IsFloor(y + 1, x) == true)
                {
                    left = left + 1;
                    Console.SetCursorPosition(x, y);
                    Console.Write(map.map[x, y]);
                    x = x - 1;
                }
                else { left = 10; }


                if (left >= 10)
                {
                    left = 0;
                    enemy.checkpoint = false;
                }
            }
        }
    }
}
