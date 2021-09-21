using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ShopManager : Shop
    {
        private const int shopsAmount = 1;
        public Shop[] shops = new Shop[shopsAmount];
        

        public void InitShops()
        {
            for (int i = 0; i < shopsAmount; i++)
            {
                shops[i] = new Shop();
            }

            LoadShops();
        }

        public void LoadShops()
        {
            shops[0].SetShops(118, 3, 1);
        }

        public void Update(Player player)
        {
            for (int i = 0; i < shopsAmount; i++)
            {
                shops[i].Update(player, shops[i]);
            }
        }

        public void Draw(Camera camera, Render render)
        {
            for (int i = 0; i < shopsAmount; i++)
            {
                shops[i].Draw(camera, render);
            }
        }
    }
}
