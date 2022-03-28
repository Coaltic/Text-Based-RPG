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
        //CoinGeneration coinGeneration = new CoinGeneration();

        ItemManager itemManager = new ItemManager();
        ShopManager shopManager = new ShopManager();

        public void RunGame()
        {
            SetScreen();

            OnStateChanged(GameState.InMenu);
            OnStateChanged(GameState.InGame);
            //map.DisplayMap(camera, render, map);
        }

        public void PlayGame()
        {

            itemManager.InitItems();
            itemManager.InitCoins(map);
            enemyManager.InitEnemies();
            shopManager.InitShops();
            hud.initHud();
            

            hud.ShowPlayerStats(player);
            SetUp();
            while (player.alive == true)
            {
                SetScreen();

                player.Update(map, player, enemyManager, camera, hud, inventory);
                enemyManager.Update(map, player, hud);
                itemManager.Update(player, hud, inventory);
                shopManager.Update(player, inventory);

                SetScreen();

                map.DisplayMap(camera, render, map);
                player.Draw(camera, render);
                enemyManager.Draw(camera, render);
                itemManager.Draw(camera, render, map);
                shopManager.Draw(camera, render);
                inventory.Draw();
                


                if (scrollingCamera)
                {
                    render.ScrollSetMap(player, camera, map);
                }
            }
        }

        public void SetUp()
        {
            enemyManager.Update(map, player, hud);
            itemManager.Update(player, hud, inventory);
            shopManager.Update(player, inventory);

            //shopManager.SwitchState()
            map.DisplayMap(camera, render, map);
            player.Draw(camera, render);
            enemyManager.Draw(camera, render);
            itemManager.Draw(camera, render, map);
            shopManager.Draw(camera, render);
            inventory.Draw();
        }

        public void SetScreen()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(camera.Xend + 20, hud.currentHudLine + 2);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowPosition(0, 0);
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
