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

            
            Player player = new Player(22, 14);
            Spider spider = new Spider(12, 18);
            Zombie zombie = new Zombie(20, 10);
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
                    
                    player.Update(map, player, zombie, spider, rat, key);
                    player.Draw();
                    /*Item.Update(player, key);
                    key.Draw();
                    Item.Update(player, key2);
                    key2.Draw();
                    Item.Update(player, healthpack);
                    healthpack.Draw();
                    Item.Update(player, sword);
                    sword.Draw();
                    Player.CheckForEnemy(player, spider);
                    Player.CheckForEnemy(player, zombie);
                    Player.CheckForEnemy(player, rat);*/





                    Hud.ShowPlayerStats(player, map);

                }
                /*else if (player.alive == false)
                {
                    gameplay = false;
                    Console.ReadKey(true);
                }

                if (spider.alive == true)
                {
                    
                    spider.Update(map);
                    spider.Draw();
                    Enemy.CheckForPlayer(spider, player);

                }

                if (zombie.alive == true)
                {
                    
                    zombie.Update(map);
                    zombie.Draw();
                    Enemy.CheckForPlayer(zombie, player);

                }

                if (rat.alive == true)
                {
                    rat.Update(map);
                    rat.Draw();
                    Enemy.CheckForPlayer(rat, player);

                }*/

                





            }
        }
    }
}
