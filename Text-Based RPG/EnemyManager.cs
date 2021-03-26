using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class EnemyManager : Enemy
    {
        private static int EnemyLimit = 10;
        public Enemy[] enemies = new Enemy[EnemyLimit];

        public void InitEnemies()
        {
            for (int i = 0; i < EnemyLimit; i++)
            {
                enemies[i] = new Enemy();
            }

            LoadEnemy();
        }

        public void LoadEnemy()
        {
            enemies[0].SetEnemy(90, 6, 3);
            enemies[1].SetEnemy(66, 3, 3);
            enemies[2].SetEnemy(98, 13, 2);
            enemies[3].SetEnemy(69, 13, 1);
            enemies[4].SetEnemy(11, 28, 1);
            enemies[5].SetEnemy(44, 30, 2);
            enemies[6].SetEnemy(67, 27, 2);
            enemies[7].SetEnemy(124, 34, 2);
            enemies[8].SetEnemy(142, 20, 1);
            enemies[9].SetEnemy(120, 7, 1);


        }

        public void Update(Map map, Player player)
        {
            for (int i = 0; i < EnemyLimit; i++)
            {
                enemies[i].Update(map, player, enemies[i]);
            }
        }

        public new void Draw()
        {
            for (int i = 0; i < EnemyLimit; i++)
            {
                enemies[i].Draw();
            }
        }

        public bool IsEnemy(int y, int x, Player player)
        {
            for (int i = 0; i < EnemyLimit; i++)
            {
                if (enemies[i].x == x && enemies[i].y == y)
                {
                    enemies[i].TakeDamage(enemies[i], player);
                    return true;
                }
            }

            return false;

        }
    }
}
