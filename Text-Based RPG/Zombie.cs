using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Zombie : Enemy
    {
        public Zombie(int x, int y)
        {
            this.Icon = "Z";
            this.x = x;
            this.y = y;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

    }
}
