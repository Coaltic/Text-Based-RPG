using System;

namespace Text_Based_RPG
{
    class EnemyManager : Enemy
    {
        public Enemy[] enemies = new Enemy[EnemyLimit];
        public string[] data = System.IO.File.ReadAllLines("EnemyLocationData.txt");
        public string[] gottenData;

        public void InitEnemies()
        {
            for (int i = 0; i < EnemyLimit; i++)
            {
                enemies[i] = new Enemy();
            }

            LoadEnemy();
        }

        public bool CheckForEnemy(Char character, int x, int y)
        {
            //ToEnemy(x, y, 3);
            if (character == 'R')
            {
                ToEnemy(x, y, 3);
                return true;
            }
            return false;
        }

        public void ToEnemy(int x, int y, int type)
        {
            //enemies[i] = new Enemy();
            //enemies[i].SetEnemy(x, y, type);
        }


        public void LoadEnemy()
        {
            
            for (int i = 0; i < EnemyLimit; i++)
            {
                gottenData = data[i].Split(';');
                int x = int.Parse(gottenData[0]);
                int y = int.Parse(gottenData[1]);
                int type = int.Parse(gottenData[2]);
                enemies[i].SetEnemy(x, y, type);
            }

        }

        public void Update(Map map, Player player, Hud hud)
        {
            for (int i = 0; i < EnemyLimit; i++)
            {
                enemies[i].Update(map, player, enemies[i], hud);
                endGameCheck(player);
            }
        }

        public override void Draw(Camera camera, Render render)
        {
            for (int i = 0; i < EnemyLimit; i++)
            {
                enemies[i].Draw(camera, render);
            }
        }

        public bool IsEnemy(int x, int y, Player player, Hud hud)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].x == x && enemies[i].y == y)
                {
                    enemies[i].TakeDamage(enemies[i], player, hud);
                    return true;
                }
            }

            return false;
        }

        public void endGameCheck(Player player)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.alive == false)
                {
                    deathTally++;
                }
            }

            if (deathTally >= EnemyLimit)
            {
                player.alive = false;
                Hud.YouWin();
            }

            else deathTally = 0;
        }
    }
}
