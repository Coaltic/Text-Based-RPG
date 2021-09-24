using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ShopManager : Shop
    {
        private const int shopsAmount = 3;
        public Shop[] shops = new Shop[shopsAmount];
        SwordShop swordShop = new SwordShop();
        PotionShop potionShop = new PotionShop();
        UtilityShop utilityShop = new UtilityShop();

        public void InitShops()
        {

            shops[0] = swordShop;
            shops[1] = potionShop;
            shops[2] = utilityShop;

            LoadShops();
        }

        

        public void LoadShops()
        {
            swordShop.SetShops(118, 3);
            utilityShop.SetShops(207, 12);
            potionShop.SetShops(62, 37);
        }

        public void Update(Player player, Inventory inventory)
        {
            swordShop.Update(player, swordShop, inventory);
            utilityShop.Update(player, utilityShop, inventory);
            potionShop.Update(player, potionShop, inventory);

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
