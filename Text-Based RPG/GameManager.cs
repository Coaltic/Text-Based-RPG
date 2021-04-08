﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    
    class GameManager
    {
        
        public static bool gameplay = false;


        public void RunGame()
        {
            Camera camera = new Camera();
            Render render = new Render();
            Map map = new Map(camera);
            Hud hud = new Hud();
            

            hud.DisplayMenu();
            map.DisplayMap(camera, render, map);

            
            Player player = new Player(22, 10);
            EnemyManager enemyManager = new EnemyManager();
            ItemManager itemManager = new ItemManager();


            //itemManager.InitItems();
            //enemyManager.InitEnemies();
            //itemManager.Draw();




            while (player.alive == true)
            {
                Console.CursorVisible = false;


                
                    
                player.Update(map, player, enemyManager, camera, render);
                //enemyManager.Update(map, player, camera, render);
                //itemManager.Update(player, camera, render);
                //map.Update(camera);
                map.DisplayMap(camera, render, map);
                //camera.Draw(player);
                player.Draw(camera, render, map);
                //enemyManager.Draw(camera);
                //itemManager.Draw();

                //Hud.ShowPlayerStats(player, map);

            }
        }
    }
}
