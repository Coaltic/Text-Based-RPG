using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Key : Item
    {
        static public bool hasKey = false;

        public Key(int x, int y)
        {
            this.Icon = "K";
            this.x = x;
            this.y = y;
            this.active = true;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

        public void MakeLockedDoor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("┼");
        }

        public void Update(Player player, Key key)
        {
            if (player.x == key.x)
            {
                if (player.y == key.y)
                {

                    hasKey = true;
                    Hud.KeyCollected();

                }
            }
        }
    }
}
