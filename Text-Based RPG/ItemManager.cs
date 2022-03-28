using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ItemManager : Item
    {
        new public string[] data = System.IO.File.ReadAllLines("ItemLocationData.txt");
        new public string[] gottenData;

        private static int ItemLimit = 20;
        public Item[] items = new Item[ItemLimit];

        Random rnd = new Random();
        static public int CoinLimit = 100;

        public Item[] coins = new Item[CoinLimit];
        public int rndX;
        public int rndY;

        //Inventory inventory = new Inventory();

        public void InitItems()
        {
            for (int i = 0; i < ItemLimit; i++)
            {
                items[i] = new Item();
            }

            LoadItems();
        }

        public void InitCoins(Map map)
        {
            for (int i = 0; i < CoinLimit; i++)
            {
                coins[i] = new Item();
            }

            LoadCoins(map);
        }

        public void LoadCoins(Map map)
        {
            for (int i = 0; i < CoinLimit; i++)
            {
                rndX = rnd.Next(210);
                rndY = rnd.Next(40);
                if (map.IsFloor(rndY, rndX))
                {
                    coins[i].SetItem(rndX, rndY, 3);
                }
            }

        }

        public void LoadItems()
        {
            for (int i = 0; i < ItemLimit; i++)
            {
                gottenData = data[i].Split(';');
                int x = int.Parse(gottenData[0]);
                int y = int.Parse(gottenData[1]);
                int type = int.Parse(gottenData[2]);
                items[i].SetItem(x, y, type);
            }
        }

        public void Update(Player player, Hud hud, Inventory inventory)
        {
            for (int i = 0; i < ItemLimit; i++)
            {
                if (items[i].x == player.x && items[i].y == player.y && items[i].active == true)
                {
                    inventory.Update(items[i]);
                    hud.ItemCollected(items[i]);
                }
                
            }

            for (int i = 0; i < CoinLimit; i++)
            {
                if (coins[i].x == player.x && coins[i].y == player.y && coins[i].active == true)
                {
                    coins[i].Update(player, coins[i], hud);
                }

            }

        }

        public new void Draw(Camera camera, Render render, Map map)
        {
            for (int i = 0; i < ItemLimit; i++)
            {
                if (items[i].active == true)
                {
                    items[i].Draw(camera, render);
                }
            }

            for (int i = 0; i < CoinLimit; i++)
            {
                if (coins[i].active == true)
                {
                    coins[i].Draw(camera, render);
                }
            }
        }

        public bool IsItem(int y, int x, Player player)
        {
            for (int i = 0; i < ItemLimit; i++)
            {
                if (items[i].x == x && items[i].y == y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
