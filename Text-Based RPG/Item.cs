using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Item
    {
        public int x;
        public int y;

        public bool active;

        public string Icon;


        public void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Icon);
        }
    }
}
