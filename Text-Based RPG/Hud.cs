using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Hud : GameManager
    {
        static public int hudLine = 1;
        public string titleScreen = System.IO.File.ReadAllText("titlescreen.txt");
        static public string gameoverScreen = System.IO.File.ReadAllText("gameoverscreen.txt");
        static public string youwinScreen = System.IO.File.ReadAllText("youwinscreen.txt");

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

        static public void ShowPlayerStats(Player player, Map map)
        {
            /*if (hudLine > 6)
            {
                Console.Clear();
                map.DisplayMap();
                hudLine = 1;
            }*/

            Console.SetCursorPosition(170, hudLine);
            Console.WriteLine("Player Health: " + player.health + "    ");
            
            
        }

        static public void ShowEnemyStats(Enemy enemy)
        {
            hudLine++;
            Console.SetCursorPosition(170, hudLine);
            Console.WriteLine("Enemy Health: " + enemy.health + "    ");
            hudLine++;
        }

        static public void ItemCollected(Item item)
        {
            hudLine++;
            Console.SetCursorPosition(170, hudLine);
            Console.WriteLine(item.name + " has been picked up");
            hudLine++;
        }

        
    }
}
