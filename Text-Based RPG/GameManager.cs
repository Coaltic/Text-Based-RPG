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
            Camera camera = new Camera();

            hud.DisplayMenu();
            map.DisplayMap();
            //camera.DisplayCamera();

            
            Player player = new Player(22, 14);
            EnemyManager enemyManager = new EnemyManager();
            ItemManager itemManager = new ItemManager();
            


            enemyManager.InitEnemies();
            itemManager.InitItems();



            while (player.alive == true)
            {
                Console.CursorVisible = false;



                    
                player.Update(map, player, enemyManager, itemManager);
                enemyManager.Update(map, player);
                itemManager.Update(player);
                //camera.Update(map);
                player.Draw();
                enemyManager.Draw();
                itemManager.Draw();

                Hud.ShowPlayerStats(player, map);

            }
        }
    }
}
