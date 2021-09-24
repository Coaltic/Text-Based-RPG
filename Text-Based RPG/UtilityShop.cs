using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class UtilityShop : Shop
    {
        public string utilitiesSprites = System.IO.File.ReadAllText("Utilities.txt");

        public UtilityShop()
        {
            shopSprites = utilitiesSprites;
            item3.buyPrice = 20;
            item3.name = "Wallet";

            item2.buyPrice = 10;
            item2.name = "Key";
            item2.Icon = "d";

            item1.buyPrice = 10;
            item1.sellPrice = 5;
            item1.name = "Health Pack";
            item1.Icon = "+";

        }


    }
}
