using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ShopManager : Shop
    {
        public string[] data = System.IO.File.ReadAllLines("ShopLocationData.txt");
        public string[] gottenData;

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
            gottenData = data[0].Split(';');
            swordShop.SetShops(int.Parse(gottenData[1]), int.Parse(gottenData[2]));
            gottenData = data[1].Split(';');
            utilityShop.SetShops(int.Parse(gottenData[1]), int.Parse(gottenData[2]));
            gottenData = data[2].Split(';');
            potionShop.SetShops(int.Parse(gottenData[1]), int.Parse(gottenData[2]));
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
