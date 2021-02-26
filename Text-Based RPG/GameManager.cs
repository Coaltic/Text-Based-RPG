using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    
    class GameManager
    {
        //
        public static bool gameplay = false;


        public void RunGame()
        {

            Console.CursorVisible = false;
            Map map = new Map();
            Hud hud = new Hud();
            Player player = new Player(10, 3);
            Spider spider = new Spider(11, 5);
            Zombie zombie = new Zombie(32, 15);
            Rat rat = new Rat(10, 16);

            hud.DisplayMenu();
            map.DisplayMap();

            while (gameplay == true)
            {
             

                if (player.alive == true)
                {
                    player.Movement(map);
                    player.Draw(player.x, player.y);
                    Player.CheckForEnemy(player, spider);
                    Player.CheckForEnemy(player, zombie);
                    Player.CheckForEnemy(player, rat);

                }
                else if (player.alive == false)
                {
                    gameplay = false;
                    Console.ReadKey(true);
                }
                
                    

                if (spider.alive == true)
                {
                    Enemy.CheckForPlayer(spider, player);
                    spider.Movement(map);
                    spider.Draw(spider.x, spider.y);
                    
                }


                if (zombie.alive == true)
                {
                    Enemy.CheckForPlayer(zombie, player);
                    zombie.Movement(map);
                    zombie.Draw(zombie.x, zombie.y);

                }

                if (rat.alive == true)
                {
                    Enemy.CheckForPlayer(rat, player);
                    rat.Movement(map);
                    rat.Draw(rat.x, rat.y);

                }

                




            }
        }
    }
}
