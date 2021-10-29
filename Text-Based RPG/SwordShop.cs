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
        public string[] data = System.IO.File.ReadAllLines("SwordShopData.txt");
        public string[] gottenData;

        public string swordSprites = System.IO.File.ReadAllText("Swords.txt");

        public SwordShop()
        {
            shopSprites = swordSprites;

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
