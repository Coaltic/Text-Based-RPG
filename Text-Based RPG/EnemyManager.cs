using System;

namespace Text_Based_RPG
{
    class EnemyManager : Enemy
    {
        public Enemy[] enemies = new Enemy[EnemyLimit];
        //private int i = 0;
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
            

            enemies[0].SetEnemy(105, 6, 3);
            enemies[1].SetEnemy(66, 3, 3);
            enemies[2].SetEnemy(98, 13, 2);
            enemies[3].SetEnemy(69, 13, 1);
            enemies[4].SetEnemy(110, 28, 1);
            enemies[5].SetEnemy(44, 30, 2);
            enemies[6].SetEnemy(67, 27, 2);
            enemies[7].SetEnemy(124, 34, 2);
            enemies[8].SetEnemy(142, 20, 1);
            enemies[9].SetEnemy(120, 7, 1);
            enemies[10].SetEnemy(137, 11, 3);
            enemies[11].SetEnemy(169, 7, 3);
            enemies[12].SetEnemy(195, 29, 2);
            enemies[13].SetEnemy(196, 18, 3);
            enemies[14].SetEnemy(39, 24, 3);
            enemies[15].SetEnemy(14, 14, 3);
            enemies[16].SetEnemy(104, 20, 3);
            enemies[17].SetEnemy(197, 37, 3);
            enemies[18].SetEnemy(169, 25, 3);
            enemies[19].SetEnemy(174, 41, 2);
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
