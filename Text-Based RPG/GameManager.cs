using System;

namespace Text_Based_RPG
{

    public class GameManager
    {
        
        public static bool scrollingCamera;
        public enum GameState { InMenu, InGame, InResults, InShop };
        //public GameState gameState;

        Hud hud = new Hud();
        Camera camera = new Camera();
        Render render = new Render();
        EnemyManager enemyManager = new EnemyManager();
        Map map = new Map();

        Player player = new Player(22, 10);
        Inventory inventory = new Inventory();

        ItemManager itemManager = new ItemManager();

        public void RunGame()
        {
            OnStateChanged(GameState.InMenu);
            OnStateChanged(GameState.InGame);
            //map.DisplayMap(camera, render, map);
        }

        public void PlayGame()
        {
            

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
        
        public void OnStateChanged(GameState state)
        {

            switch (state)
            {
                case GameState.InMenu:
                    Console.Clear();
                    hud.DisplayMenu();
                    break;
                case GameState.InGame:
                    PlayGame();
                    break;
                case GameState.InShop:

                    break;
                case GameState.InResults:
                    break;
                default:
                    break;
            }
        }
    }
}
