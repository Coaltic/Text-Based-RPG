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

        }
    }
}
