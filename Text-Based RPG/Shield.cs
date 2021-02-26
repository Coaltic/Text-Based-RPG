using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Shield : Item
    {
        public Shield(int x, int y)
        {
            this.Icon = "U";
            this.x = x;
            this.y = y;
            this.active = true;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }
    }
}
