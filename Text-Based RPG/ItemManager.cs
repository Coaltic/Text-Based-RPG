using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ItemManager : Item
    {
        private static int ItemLimit = 20;
        public Item[] items = new Item[ItemLimit];

        public void InitItems()
        {
            for (int i = 0; i < ItemLimit; i++)
            {
                items[i] = new Item();
            }

            LoadItems();
        }

        public void LoadItems()
        {
            items[0].SetItem(3, 10, 1);
            items[1].SetItem(79, 2, 1);
            items[2].SetItem(103, 39, 1);
            items[3].SetItem(46, 25, 1);
            items[4].SetItem(160, 24, 1);
            items[5].SetItem(6, 28, 1);
            items[6].SetItem(117, 20, 1);
            items[7].SetItem(47, 15, 1);
            items[8].SetItem(135, 40, 2);
            items[9].SetItem(28, 48, 3);
            items[10].SetItem(92, 32, 1);
            items[11].SetItem(118, 29, 1);
            items[12].SetItem(183, 18, 1);
            items[13].SetItem(160, 24, 1);
            items[14].SetItem(117, 35, 1);
            items[15].SetItem(59, 39, 1);
            items[16].SetItem(27, 29, 1);
            items[17].SetItem(89, 21, 1);
            items[18].SetItem(129, 9, 1);
            items[19].SetItem(208, 2, 1);
        }

        public void Update(Player player, Hud hud)
        {
            for (int i = 0; i < ItemLimit; i++)
            {
                if (items[i].x == player.x && items[i].y == player.y)
                {
                    items[i].Update(player, items[i], hud);
                }
            }
        }

        public new void Draw(Camera camera, Render render, Map map)
        {
            for (int i = 0; i < ItemLimit; i++)
            {
                if (items[i].active == true)
                {
                    items[i].Draw(camera, render, map);
                }
            }
        }

        public bool IsItem(int y, int x, Player player)
        {
            for (int i = 0; i < ItemLimit; i++)
            {
                if (items[i].x == x && items[i].y == y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
