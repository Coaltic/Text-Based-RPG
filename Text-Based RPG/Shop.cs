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
        public string Icon = "–";
        public bool shopping = false;
        public bool selling = false;
        public bool buying;
        //public int shopMin;
        //public int shopMax;

        public int buyPrice;
        public int sellPrice;
        public string itemName;

        public Item item1 = new Item();
        public Item item2 = new Item();
        public Item item3 = new Item();
        //GameState switchState;

        //public Item[] shopItems = new Item[shopMax];
        public string shopScreen = System.IO.File.ReadAllText("Shop.txt");
        public string buyScreen = System.IO.File.ReadAllText("Buy.txt");
        public string sellScreen = System.IO.File.ReadAllText("Sell.txt");
        //public string potionSprites= System.IO.File.ReadAllText("Potions.txt");
        //public string swordSprites = System.IO.File.ReadAllText("Swords.txt");
        public string shopSprites;

        public void SetShops(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Draw(Camera camera, Render render)
        {
            render.Draw(x, y, Icon, camera);
        }

        public void RenderInterior(Player player, String shopSprites, Inventory inventory)
        {
            shopping = true;
            Console.Clear();
            Console.Write(shopScreen);


            Console.SetCursorPosition(0, 0);
            Console.Write(shopSprites);
            Shopping(player, inventory);
            
        }

        public void Update(Player player, Shop shop, Inventory inventory)
        {
            if (player.x == shop.x && shop.y == player.y)
            {
                RenderInterior(player, shop.shopSprites, inventory);
                //SwitchState(GameState.InShop);
            }

            
        }

        public void Shopping(Player player, Inventory inventory)
        {
            while (shopping)
            {
                Console.SetCursorPosition(60, 2);
                Console.Write("Gold: " + player.gold + "     ");

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                ConsoleKeyInfo input;
                input = Console.ReadKey(true);

                if (input.KeyChar == 'a')
                {
                    Console.Write(buyScreen);

                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    input = Console.ReadKey(true);

                    if (input.KeyChar == 'a')
                    {
                        Purchase(player, item1, inventory);

                    }
                    else if (input.KeyChar == 'b')
                    {
                        Purchase(player, item2, inventory);
                    }
                    else if (input.KeyChar == 'c')
                    {
                        Purchase(player, item3, inventory);
                    }
                }
                else if (input.KeyChar == 'b')
                {
                    selling = true;
                    Sell(player, inventory);
                }
                else if (input.KeyChar == 'c')
                {
                    Console.Clear();
                    shopping = false;
                    selling = false;
                }
                else
                {
                    shopping = true;
                }
            }
        }

        public void Purchase(Player player, Item item, Inventory inventory)
        {
            

            if (player.gold >= item.buyPrice)
            {
                if (item.name == "Wallet")
                {
                    player.gold = player.gold - item.buyPrice;
                    player.WalletUpgrade();
                }

                if (item.name == "Health Pack" || item.name == "Key")
                {
                    player.gold = player.gold - item.buyPrice;
                    inventory.Update(item);
                }

                if (item.name == "Strength" || item.name == "Regen" || item.name == "Luck")
                {
                    player.gold = player.gold - item.buyPrice;
                    player.PotionEffect(player, item);
                }

                if (item.name == "Upgrade" || item.name == "Good Upgrade" || item.name == "Great Upgrade")
                {
                    player.gold = player.gold - item.buyPrice;
                    player.weaponAttack = player.weaponAttack + item.swordStrength;
                }

                

                RenderInterior(player, shopSprites, inventory);
            }

        }

        public void Sell(Player player, Inventory inventory)
        {
            while (selling)
            {
                Item item;
                int itemNumber;
                Console.SetCursorPosition(0, 0);
                Console.Write(sellScreen);
                inventory.Draw();
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                ConsoleKeyInfo input;
                input = Console.ReadKey(true);

                if (input.KeyChar == '1' || input.KeyChar == '2' || input.KeyChar == '3' || input.KeyChar == '4' || input.KeyChar == '5' || input.KeyChar == '6')
                {
                    itemNumber = int.Parse(input.KeyChar.ToString());
                    item = inventory.GetItemInfo(itemNumber);
                    inventory.Draw();

                    player.gold = player.gold + item.sellPrice;
                    Console.SetCursorPosition(60, 2);
                    Console.Write("Gold: " + player.gold + "     ");
                }
                if (input.KeyChar == 'c')
                {
                    selling = false;
                    RenderInterior(player, shopSprites, inventory);
                }
            }

            
        }
        
    }
}
