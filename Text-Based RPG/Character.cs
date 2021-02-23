using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Character
    {
        public int x;
        public int y;

        public static bool EnemyAlive = true;
        public static bool PlayerAlive = true;

        public string Icon;



        /*public static void CheckForEnemy(int PlayerX, int EnemyX, int PlayerY, int EnemyY)
        {
            if (EnemyX == Player.x)
            {
                if (EnemyY == PlayerY)
                {
                    Console.SetCursorPosition(51, 1);   // player checks if they have attacked the enemy
                    Console.WriteLine("Enemy hit");
                    EnemyAlive = false;                 // enemy = null; <---- save for future use
                }
            }
        }*/

        public static void CheckForPlayer(int PlayerX, int EnemyX, int PlayerY, int EnemyY)
        {
            if (EnemyX == PlayerX)
            {
                if (EnemyY == PlayerY)
                {
                    Console.SetCursorPosition(51, 1);
                    Console.WriteLine("Player hit");
                    Console.SetCursorPosition(51, 2);   // enemy checks if they have attacked the player
                    Console.WriteLine("GAME OVER");
                    Program.moving = false;
                    PlayerAlive = false;
                    Console.ReadKey(true);
                }
            }
        }


    }

    
}
