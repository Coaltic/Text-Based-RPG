using System;

namespace Text_Based_RPG
{

    class GameManager
    {

        public static bool scrollingCamera;

        public void RunGame()
        {
            Camera camera = new Camera();
            Render render = new Render();
            EnemyManager enemyManager = new EnemyManager();
            Map map = new Map(enemyManager);
            Hud hud = new Hud();
            
            hud.DisplayMenu();
            map.DisplayMap(camera, render, map); 

            Player player = new Player(22, 10);
            Inventory inventory = new Inventory();
            
            ItemManager itemManager = new ItemManager();

            itemManager.InitItems();
            enemyManager.InitEnemies();
            hud.initHud();

            hud.ShowPlayerStats(player);

            while (player.alive == true)
            {
                Console.CursorVisible = false;

                player.Update(map, player, enemyManager, camera, hud, inventory);
                enemyManager.Update(map, player, hud);
                itemManager.Update(player, hud, inventory);
                map.DisplayMap(camera, render, map);
                player.Draw(camera, render);
                enemyManager.Draw(camera, render);
                itemManager.Draw(camera, render, map);
                inventory.Draw();

                if (scrollingCamera)
                {
                    render.ScrollSetMap(player, camera, map);
                }
            }
        }
    }
}
