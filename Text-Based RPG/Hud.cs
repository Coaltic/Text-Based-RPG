using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Hud
    {
        public int currentHudLine = 25;
        public int currentHudText = 0;
        public int previousHudText = 1;

        public string titleScreen = System.IO.File.ReadAllText("titlescreen.txt");
        static public string gameoverScreen = System.IO.File.ReadAllText("gameoverscreen.txt");
        static public string youwinScreen = System.IO.File.ReadAllText("youwinscreen.txt");

        public string[] hudLine = new string[6];

        

        public void initHud()
        {
            hudLine[0] = "0        ";
            hudLine[1] = "1        ";
            hudLine[2] = "2        ";
            hudLine[3] = "3        ";
            hudLine[4] = "4        ";
            hudLine[5] = "5        ";

            
        }

        public void DisplayHud(String text)
        {
            currentHudLine = 25;
            previousHudText = currentHudText - 1;
            hudLine[currentHudText] = (text);

            Console.SetCursorPosition(5, currentHudLine);
            Console.Write(hudLine[currentHudText] + "                                         ");

            for (int i = 0; i <= 4; i++)
            {
                if (previousHudText < 0)
                {
                    previousHudText = 5;
                }

                currentHudLine++;
                Console.SetCursorPosition(5, currentHudLine);
                Console.Write(hudLine[previousHudText] + "                                           ");
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
            Console.WriteLine("MAXIMIZE BEFORE CONTINUING");
            Console.WriteLine();
            Console.WriteLine("Press any key to play...");
            Console.ReadKey(true);
            Console.Clear();
            //GameManager.gameplay = true;

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

        public void ShowEnemyStats(Enemy enemy)
        {
            DisplayHud("Enemy Health: " + enemy.health);
        }

        public void ItemCollected(Item item)
        {
            DisplayHud(item.name + " has been picked up");
        }

        
    }
}
