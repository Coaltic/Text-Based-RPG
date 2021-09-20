using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Shop
    {
        //public int shopMin;
        //public int shopMax;

        //public Item[] shopItems = new Item[shopMax];
        public string shopScreen = System.IO.File.ReadAllText("Shop.txt");

        public void SetShop(string type, int shopMin, int shopMax)
        {

        }

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine(shopScreen);
        }

        public void Update()
        {
            Console.Clear();
            //Console.WriteLine(titleScreen);
            Console.WriteLine();
        }
    }
}
