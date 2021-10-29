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
        public string[] data = System.IO.File.ReadAllLines("PotionShopData.txt");
        public string[] gottenData;

        public string potionSprites = System.IO.File.ReadAllText("Potions.txt");

        public PotionShop()
        {
            shopSprites = potionSprites;

            gottenData = data[1].Split(';');
            
            item1.buyPrice = int.Parse(gottenData[0]);
            item1.sellPrice = int.Parse(gottenData[1]);
            item1.name = gottenData[2];

            gottenData = data[2].Split(';');

            item2.buyPrice = int.Parse(gottenData[0]);
            item2.sellPrice = int.Parse(gottenData[1]);
            item2.name = gottenData[2];

            gottenData = data[3].Split(';');

            item3.buyPrice = int.Parse(gottenData[0]);
            item3.sellPrice = int.Parse(gottenData[1]);
            item3.name = gottenData[2];

        }
       
    }
}
