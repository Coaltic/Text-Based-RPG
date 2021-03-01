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
        public string name;


        public void Draw()
        {
            if (active == true)
            {
                
                Console.SetCursorPosition(x, y);
                Console.Write(Icon);
            }
        }

        public static void Update(Player player, Item item)
        {
            if (player.x == item.x)
            {
                if (player.y == item.y)
                {
                    if (item.name == "Sword") { Player.hasSword = true; }
                    if (item.name == "Key") { Player.hasKey = true; ; }

                    if (item.active)
                    {
                        item.active = false;
                        Hud.ItemCollected(item);
                    }

                }
            }
        }

    }
}
