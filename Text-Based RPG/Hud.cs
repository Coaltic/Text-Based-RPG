using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Hud : GameManager
    {
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Wellcome to the game");
            Console.WriteLine();
            Console.WriteLine("Press any key to play...");
            Console.ReadKey(true);
            Console.Clear();
            GameManager.gameplay = true;

        }
    }
}
