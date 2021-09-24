using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class SwordShop : Shop
    {
        
        //public int swordStrength;

        public string swordSprites = System.IO.File.ReadAllText("Swords.txt");

        public SwordShop()
        {
            shopSprites = swordSprites;
            item1.buyPrice = 40;
            item1.swordStrength = 25;
            item1.name = "Upgrade";

            item2.buyPrice = 60;
            item2.swordStrength = 50;
            item2.name = "Good Upgrade";

            item3.buyPrice = 100;
            item3.swordStrength = 100;
            item3.name = "Great Upgrade";
        }


    }
}
