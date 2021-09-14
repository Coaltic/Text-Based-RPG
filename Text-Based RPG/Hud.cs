using System;

namespace Text_Based_RPG
{
    class Hud
    {
        public int currentHudLine = 25;
        public int currentHudText = 0;
        public int previousHudText = 1;

        private bool playerInput;

        public string titleScreen = System.IO.File.ReadAllText("titlescreen.txt");
        static public string gameoverScreen = System.IO.File.ReadAllText("gameoverscreen.txt");
        static public string youwinScreen = System.IO.File.ReadAllText("youwinscreen.txt");

        public string[] hudLine = new string[6];

        public void initHud()
        {
            hudLine[0] = "         ";
            hudLine[1] = "         ";
            hudLine[2] = "         ";
            hudLine[3] = "         ";
            hudLine[4] = "         ";
            hudLine[5] = "         ";
        }

        public void DisplayHud(String text)
        {
            currentHudLine = 25;
            previousHudText = currentHudText - 1;
            hudLine[currentHudText] = (text);

            Console.SetCursorPosition(5, currentHudLine);
            Console.Write(hudLine[currentHudText] + "                  ");

            for (int i = 0; i <= 4; i++)
            {
                if (previousHudText < 0)
                {
                    previousHudText = 5;
                }

                currentHudLine++;
                Console.SetCursorPosition(5, currentHudLine);
                Console.Write(hudLine[previousHudText] + "                ");
                previousHudText--;

            }

            currentHudText++;

            if (currentHudText > 5)
            {
                currentHudText = 0;
            }
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine(titleScreen);
            Console.WriteLine();

            playerInput = true;

            while (playerInput)
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                ConsoleKeyInfo input;
                input = Console.ReadKey(true);


                if (input.KeyChar == 'a')
                {
                    playerInput = false;
                    Console.Clear();
                    GameManager.scrollingCamera = true;
                }
                else if (input.KeyChar == 'b')
                {
                    playerInput = false;
                    Console.Clear();
                    GameManager.scrollingCamera = false;
                }
                else
                {
                    Console.Beep(100, 200);
                }
            }
        }

        static public void GameOver()
        {
            Console.Clear();
            Console.WriteLine(gameoverScreen);
            Console.ReadKey(true);
        }

        static public void YouWin()
        {
            Console.Clear();
            Console.WriteLine(youwinScreen);
            Console.ReadKey(true);
        }

        public void ShowPlayerStats(Player player)
        {
            DisplayHud("Player Health: " + player.health);
        }

        public void PlayerLevelUp(Player player)
        {
            DisplayHud("Player reached level " + player.level);
        }

        public void ShowEnemyStats(Enemy enemy)
        {
            DisplayHud("Enemy Health: " + enemy.health);
        }

        public void ItemCollected(Item item)
        {
            DisplayHud("You used the " + item.name);
        }
    }
}
