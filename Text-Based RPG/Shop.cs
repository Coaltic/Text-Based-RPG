using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Shop
    {
        public int shopType;
        public int x;
        public int y;
        //public int shopMin;
        //public int shopMax;

        //public Item[] shopItems = new Item[shopMax];
        public string shopScreen = System.IO.File.ReadAllText("Shop.txt");

        public void SetShops(int x, int y, int type)
        {
            this.shopType = type;
            this.x = x;
            this.y = y;
        }

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine(shopScreen);
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine(shopScreen);
            Console.WriteLine();
        }
    }
}
