using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Program : GameManager
    {

        static public bool moving = true;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Map map = new Map();
            map.DisplayMap();
            Player player = new Player(10, 3);
            Enemy enemy = new Enemy(11, 5);

            while (moving == true)
            {

                if (Character.PlayerAlive == true)
                { player.Movement(map);
                  //Character.CheckForEnemy(player.PlayerX, enemy.EnemyX, player.PlayerY, enemy.EnemyY);
                }

                if (Character.EnemyAlive == true)
                { enemy.Movement(map);
                  //Character.CheckForPlayer(player.PlayerX, enemy.EnemyX, player.PlayerY, enemy.EnemyY);
                }

                if (Character.EnemyAlive == false)
                {
                    enemy = new Enemy(32, 15);
                    Character.EnemyAlive = true;  //prototype spawning new enemy
                }
                



            }


        }

        
    }
}
