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
            map.DisplayMap();
            Player player = new Player(10, 3);
            Spider spider = new Spider(11, 5);
            Zombie zombie = new Zombie(32, 15);

            gameplay = true;

            while (gameplay == true)
            {

                if (player.alive == true)
                {
                    player.Movement(map);
                    
                }

                if (spider.alive == true)
                {
                    Player.CheckForEnemy(player.x, spider.x, player.y, spider.y, spider);

                    if (spider.alive == true)
                    {
                        spider.Movement(map);
                        Spider.CheckForPlayer(player.x, spider.x, player.y, spider.y, player);
                    }
                }

                /*if (Spider.alive == false)
                {
                    //spider = new Spider(32, 15);
                    //Spider.alive = true;  //prototype spawning new spider
                }*/




            }
        }
    }
}
