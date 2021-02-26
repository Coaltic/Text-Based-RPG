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
            this.x = x;
            this.y = y;
            this.active = true;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

        public void Update(Player player, Healthpack healthpack)
        {
            if (player.x == healthpack.x)
            {
                if (player.y == healthpack.y && player.x == healthpack.x)
                

                    player.health = player.health + 75;
                    Hud.HealthpackActive();

                
            }
        }

    }
}
