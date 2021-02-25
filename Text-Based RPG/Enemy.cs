using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : Character
    {


        public bool checkpoint = false;
        public bool checkpoint2 = false;
        public int point1 = 35;
        public int point2 = 25;
        public int right = 0;
        public int left = 0;

        public Enemy()
        {
            
        }

        

        public static void CheckForPlayer(int PlayerX, int EnemyX, int PlayerY, int EnemyY, Player player)
        {
            if (EnemyX == PlayerX)
            {
                if (EnemyY == PlayerY)
                {
                    Console.SetCursorPosition(51, 1);
                    Console.WriteLine("Player hit");
                    Console.SetCursorPosition(51, 2);   // enemy checks if they have attacked the player
                    Console.WriteLine("GAME OVER");
                    GameManager.gameplay = false;
                    player.alive = false;
                    Console.ReadKey(true);
                }
            }
        }
    }
}
