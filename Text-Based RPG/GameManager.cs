using System;
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

            Character[] gameCharacters = new Character[21];

            itemManager.InitItems();
            enemyManager.InitEnemies();
            hud.initHud();

            for (int i = 0; i < gameCharacters.Length - 1; i++)
            {
                gameCharacters[i] = enemyManager.enemies[i];
            }

            gameCharacters[20] = player;

            hud.ShowPlayerStats(player);

            while (player.alive == true)
            {
                Console.CursorVisible = false;

                player.Update(map, player, enemyManager, camera, hud);
                enemyManager.Update(map, player, hud);
                itemManager.Update(player, hud);
                map.DisplayMap(camera, render, map);

                for (int i = 0; i < gameCharacters.Length; i++)
                {
                    gameCharacters[i].Draw(camera, render);
                }

                //player.Draw(camera, render);
                //enemyManager.Draw(camera, render);
                itemManager.Draw(camera, render, map);
            }
        }
    }
}
