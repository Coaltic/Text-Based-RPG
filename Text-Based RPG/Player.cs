using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player
    {
        public string playerIcon = "@";
        static public int x = 20;
        static public int y = 16;
        public bool moving = true;

        public Player()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(playerIcon);
        }

        public void Movement()
        {
            while (moving)
            {
                ConsoleKeyInfo input;
                input = Console.ReadKey(true);


                if (input.KeyChar == 'w')
                {
                    ; y = y - 1; Console.SetCursorPosition(x, y);
                    Console.WriteLine(playerIcon);
                }
                else if (input.KeyChar == 'd')
                {
                    x = x + 1; Console.SetCursorPosition(x, y);
                    Console.WriteLine(playerIcon);
                }
                else if (input.KeyChar == 's')
                {
                    y = y + 1; Console.SetCursorPosition(x, y);
                    Console.WriteLine(playerIcon);
                }
                else if (input.KeyChar == 'a')
                {
                    x = x - 1; Console.SetCursorPosition(x, y);
                    Console.WriteLine(playerIcon);
                }


            }

        }
    }
}
