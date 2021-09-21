using System;

namespace Text_Based_RPG
{
    enum GameState { InMenu, InGame, InResults, InShop };

    public class GameManager
    {
        
        public static bool scrollingCamera;
        
        //public GameState gameState;

        Hud hud = new Hud();
        Camera camera = new Camera();
        Render render = new Render();
        EnemyManager enemyManager = new EnemyManager();
        Map map = new Map();

        Player player = new Player(22, 10);
        Inventory inventory = new Inventory();

        ItemManager itemManager = new ItemManager();
        ShopManager shopManager = new ShopManager();

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
            shopManager.InitShops();
            hud.initHud();

            hud.ShowPlayerStats(player);

            while (player.alive == true)
            {
                Console.CursorVisible = false;

                player.Update(map, player, enemyManager, camera, hud, inventory);
                enemyManager.Update(map, player, hud);
                itemManager.Update(player, hud, inventory);
                
                //shopManager.SwitchState()
                map.DisplayMap(camera, render, map);
                player.Draw(camera, render);
                enemyManager.Draw(camera, render);
                itemManager.Draw(camera, render, map);
                shopManager.Draw(camera, render);
                inventory.Draw();
                shopManager.Update(player);


                if (scrollingCamera)
                {
                    render.ScrollSetMap(player, camera, map);
                }
            }
        }
        
        void OnStateChanged(GameState state)
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
