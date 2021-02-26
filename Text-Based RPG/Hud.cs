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
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the game");
            Console.WriteLine();
            Console.WriteLine("MAXIMIZE BEFORE CONTINUING");
            Console.WriteLine();
            Console.WriteLine("Press any key to play...");
            Console.ReadKey(true);
            Console.Clear();
            GameManager.gameplay = true;

        }

        static public void ShowPlayerStats(Player player)
        {
            Console.SetCursorPosition(170, hudLine);
            Console.WriteLine("Player Health: " + player.health);
            
        }

        static public void ShowEnemyStats(Enemy enemy)
        {
            hudLine++;
            Console.SetCursorPosition(170, hudLine);
            Console.WriteLine("Enemy Health: " + enemy.health);
            hudLine++;
        }

        static public void SwordActive()
        {
            hudLine++;
            Console.SetCursorPosition(170, hudLine);
            Console.WriteLine("Sword has been picked up");
            hudLine++;

        }

        static public void KeyCollected()
        {
            hudLine++;
            Console.SetCursorPosition(170, hudLine);
            Console.WriteLine("Key has been picked up");
            hudLine++;
        }
    }
}
