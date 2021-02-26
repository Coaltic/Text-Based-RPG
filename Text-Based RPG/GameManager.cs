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

            Map map = new Map();
            Hud hud = new Hud();

            hud.DisplayMenu();
            map.DisplayMap();

            
            Player player = new Player(10, 3);
            Spider spider = new Spider(12, 18);
            Zombie zombie = new Zombie(100, 15);
            Rat rat = new Rat(14, 5);

            Healthpack healthpack = new Healthpack(38, 2);
            Sword sword = new Sword(34, 28);
            Key key = new Key(50, 19);
            Key key2 = new Key(140, 1);
            //key.MakeLockedDoor(62, 13);


            while (gameplay == true)
            {
                Console.CursorVisible = false;



                if (player.alive == true)
                {
                    
                    player.Update(map);
                    player.Draw(player.x, player.y);
                    sword.Update(player, sword);
                    key.Update(player, key);
                    Player.CheckForEnemy(player, spider);
                    Player.CheckForEnemy(player, zombie);
                    Player.CheckForEnemy(player, rat);
                    Hud.ShowPlayerStats(player);

                }
                else if (player.alive == false)
                {
                    gameplay = false;
                    Console.ReadKey(true);
                }

                if (spider.alive == true)
                {
                    Enemy.CheckForPlayer(spider, player);
                    spider.Update(map);
                    spider.Draw(spider.x, spider.y);

                }

                if (zombie.alive == true)
                {
                    Enemy.CheckForPlayer(zombie, player);
                    zombie.Update(map);
                    zombie.Draw(zombie.x, zombie.y);

                }

                if (rat.alive == true)
                {
                    Enemy.CheckForPlayer(rat, player);
                    rat.Update(map);
                    rat.Draw(rat.x, rat.y);

                }






            }
        }
    }
}
