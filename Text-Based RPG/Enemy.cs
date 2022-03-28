using System;

namespace Text_Based_RPG
{
    class Enemy : Character
    {
        static public string[] data = System.IO.File.ReadAllLines("EnemyData.txt");
        static public string[] gottenData = data[1].Split(';');

        static public int EnemyLimit = int.Parse(gottenData[1]);
        public int deathTally;
        private bool checkpoint = false;

        public int enemyType;
        private int exp;

        Random rnd = new Random();


        public void SetEnemy(int x, int y, int type)
        {
            enemyType = type;
            this.x = x;
            this.y = y;
            alive = true;

            gottenData = data[type + 1].Split(';');

            Icon = gottenData[1];
            health = int.Parse(gottenData[2]);
            attack = int.Parse(gottenData[3]);
            exp = int.Parse(gottenData[4]);
            gold = rnd.Next(int.Parse(gottenData[5]), int.Parse(gottenData[6]));
        }


        public void Update(Map map, Player player, Enemy enemy, Hud hud)
        {
            if (enemy.alive == true)
            {

                Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

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
            enemy.health = enemy.health - (player.attack + player.weaponAttack);

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
