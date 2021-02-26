using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Sword : Item
    {
        static public bool hasSword = false;

        public Sword(int x, int y)
        {
            this.Icon = "┼";
            this.x = x;
            this.y = y;
            this.active = true;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

        public void Update(Player player, Sword sword)
        {
            if (player.x == sword.x)
            {
                if (player.y == sword.y)
                {                    
                    
                    hasSword = true;
                    Hud.SwordActive();
                    
                }
            }
        }
    }
}
