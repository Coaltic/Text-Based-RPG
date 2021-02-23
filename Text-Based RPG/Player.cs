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
            this.x = x;
            this.y = y;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

        public void Movement(Map map)
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            if (input.KeyChar == 'w')
            {
                if (map.IsFloor(y - 1, x) == true)
                {

                    y = y - 1;
                    //Console.Clear();
                    //DisplayMap();
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(Icon);                            // player moves up
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write(map.mapArray[y + 1, x]);      // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 'd')
            {
                if (map.IsFloor(y, x + 1) == true)
                {
                    x = x + 1;
                    //Console.Clear();
                    //DisplayMap();
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(Icon);                            // player moves right
                    Console.SetCursorPosition(x - 1, y);
                    Console.Write(map.mapArray[y, x - 1]);      // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 's')
            {
                if (map.IsFloor(y + 1, x) == true)
                {
                    y = y + 1;
                    //Console.Clear();
                    //DisplayMap();
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(Icon);                            // player moves left
                    Console.SetCursorPosition(x, y - 1);
                    Console.Write(map.mapArray[y - 1, x]);      // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 'a')
            {
                if (map.IsFloor(y, x - 1) == true)
                {
                    x = x - 1;
                    //Console.Clear();
                    //DisplayMap();
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(Icon);                            // player moves down
                    Console.SetCursorPosition(x + 1, y);
                    Console.Write(map.mapArray[y, x + 1]);      // previous tile is replaced by map tile
                }
                else { Collision(); }
            }



        }

        public void Collision()
        {
            Console.Beep(100, 200);                                     // left as a method for future possible additions
        }
        

    }
}
