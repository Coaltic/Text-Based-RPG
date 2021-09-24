using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class PotionShop : Shop
    {
        
        //public int potionType;

        public string potionSprites = System.IO.File.ReadAllText("Potions.txt");

        public PotionShop()
        {
            shopSprites = potionSprites;
            item1.buyPrice = 25;
            item1.sellPrice = 13;
            item1.potionType = 1;
            item1.name = "Strength";


            item2.buyPrice = 25;
            item2.sellPrice = 13;
            item2.name = "Regen";

            item3.buyPrice = 25;
            item3.sellPrice = 13;
            item3.name = "Luck";

        }
       
    }
}
