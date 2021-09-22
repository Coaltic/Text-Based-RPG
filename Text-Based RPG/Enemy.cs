using System;

namespace Text_Based_RPG
{
    class Enemy : Character
    {
        static public int EnemyLimit = 20;
        public int deathTally;
        private bool checkpoint = false;
        private int right = 0;
        private int left = 0;

        public int enemyType;
        private int exp;

        Random rnd = new Random();


        public void SetEnemy(int x, int y, int type)
        {
            enemyType = type;
            this.x = x;
            this.y = y;
            alive = true;
            this.gold = rnd.Next(10);

            if (type == 1)
            {
                Icon = "S";
                health = 200;
                attack = 30;
                exp = 30;
                this.gold = rnd.Next(15, 20);
            }
            else if (type == 2)
            {
                Icon = "Z";
                health = 100;
                attack = 20;
                exp = 20;
                this.gold = rnd.Next(10, 15);
            }
            else if (type == 3)
            {
                Icon = "R";
                health = 50;
                attack = 15;
                exp = 15;
                this.gold = rnd.Next(5, 10);
            }
        }


        public void Update(Map map, Player player, Enemy enemy, Hud hud)
        {
            if (enemy.alive == true)
            {
                if (enemyType == 1)
                {
                    if (player.IsPlayerNear(enemy.x, enemy.y, player) == true)
                    {
                        player.TakeDamage(player, enemy, hud);
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
                        player.TakeDamage(player, enemy, hud);
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
                        player.TakeDamage(player, enemy, hud);
                        Console.Beep(100, 100);
                    }
                    else if (player.IsPlayerNear(enemy.x, enemy.y, player) == false)
                    {
                        EnemyAI3(map, enemy);
                    }
                }
            }
            
        }

        public void TakeDamage(Enemy enemy, Player player, Hud hud)
        {
            enemy.health = enemy.health - (player.attack + player.sword);

            if (enemy.health <= 0)
            {
                enemy.health = 0;
                enemy.alive = false;
                Icon = "";
                //Console.SetCursorPosition(enemy.x, enemy.y);
                //Console.Write(" ");
                enemy.x = 0;
                enemy.y = 0;

                player.exp = player.exp + enemy.exp;
                player.gold = player.gold + enemy.gold;
            }

            hud.ShowEnemyStats(enemy);
        }

        public void EnemyAI1(Map map, Enemy enemy)
        {
            int num = rnd.Next(5);

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
                    enemy.x++;
                }
                else { enemy.checkpoint = true; }
            }
            else if (enemy.checkpoint == true)
            {
                if (map.IsFloor(y, x - 1) == true)
                { 
                    x--;
                }
                else { enemy.checkpoint = false; }
            }
        }
    }
}
