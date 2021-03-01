using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Healthpack : Item
    {
        public Healthpack(int x, int y)
        {
            this.Icon = "H";
            this.name = "Healthpack";
            this.x = x;
            this.y = y;
            this.active = true;
        }

       

    }
}
