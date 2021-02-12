using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player : Character
    {
        //public string playerIcon = "@";
        //static public ConsoleKeyInfo input;
        //public bool moving = true;



        public Player(int x, int y)
        {
            this.Icon = "@";
            this.PlayerX = x;
            this.PlayerY = y;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

        public void Movement()
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            if (input.KeyChar == 'w')
            {
                if (mapArray[PlayerY - 1, PlayerX] == "`")
                {

                    PlayerY = PlayerY - 1;
                    //Console.Clear();
                    //DisplayMap();
                    Console.SetCursorPosition(PlayerX, PlayerY);
                    Console.WriteLine(Icon);                            // player moves up
                    Console.SetCursorPosition(PlayerX, PlayerY + 1);
                    Console.Write(mapArray[PlayerY + 1, PlayerX]);      // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 'd')
            {
                if (mapArray[PlayerY, PlayerX + 1] == "`")
                {
                    PlayerX = PlayerX + 1;
                    //Console.Clear();
                    //DisplayMap();
                    Console.SetCursorPosition(PlayerX, PlayerY);
                    Console.WriteLine(Icon);                            // player moves right
                    Console.SetCursorPosition(PlayerX - 1, PlayerY);
                    Console.Write(mapArray[PlayerY, PlayerX - 1]);      // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 's')
            {
                if (mapArray[PlayerY + 1, PlayerX] == "`")
                {
                    PlayerY = PlayerY + 1;
                    //Console.Clear();
                    //DisplayMap();
                    Console.SetCursorPosition(PlayerX, PlayerY);
                    Console.WriteLine(Icon);                            // player moves left
                    Console.SetCursorPosition(PlayerX, PlayerY - 1);
                    Console.Write(mapArray[PlayerY - 1, PlayerX]);      // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 'a')
            {
                if (mapArray[PlayerY, PlayerX - 1] == "`")
                {
                    PlayerX = PlayerX - 1;
                    //Console.Clear();
                    //DisplayMap();
                    Console.SetCursorPosition(PlayerX, PlayerY);
                    Console.WriteLine(Icon);                            // player moves down
                    Console.SetCursorPosition(PlayerX + 1, PlayerY);
                    Console.Write(mapArray[PlayerY, PlayerX + 1]);      // previous tile is replaced by map tile
                }
                else 
                { Collision(); }
            }



        }

        public void Collision()
        {
            Console.Beep(100, 200);                                     // left as a method for future possible additions
        }
        

    }
}
