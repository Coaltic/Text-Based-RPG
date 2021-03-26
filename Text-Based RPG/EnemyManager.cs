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
            enemies[0].SetEnemy(20, 10, 3);
        }

        public void Update(Map map, Player player, Item item)
        {
            for (int i = 0; i < EnemyLimit; i++)
            {
                enemies[i].Update(map, player, enemies[i], item);
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
                else
                {
                    return false;
                }
            }

            return false;

        }
    }
}
