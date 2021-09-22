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
        public bool buying;
        //public int shopMin;
        //public int shopMax;

        GameState switchState;

        //public Item[] shopItems = new Item[shopMax];
        public string shopScreen = System.IO.File.ReadAllText("Shop.txt");
        public string potionSprites= System.IO.File.ReadAllText("Potions.txt");
        public string swordSprites = System.IO.File.ReadAllText("Swords.txt");

        public void SetShops(int x, int y, int type)
        {
            this.shopType = type;
            this.x = x;
            this.y = y;
        }

        public void Draw(Camera camera, Render render)
        {
            render.Draw(x, y, Icon, camera);
        }

        public void RenderInterior(int type)
        {
            shopping = true;
            Console.Clear();
            Console.Write(shopScreen);


            if (type == 1)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(potionSprites);
                Shopping();
            }
            else if (type == 2)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(swordSprites);
                Shopping();
            }
            else if (type == 3)
            {

            }
        }

        public void Update(Player player, Shop shop)
        {
            if (player.x == shop.x && shop.y == player.y)
            {
                RenderInterior(shop.shopType);
                //SwitchState(GameState.InShop);
            }

            
        }

        public void Shopping()
        {
            while (shopping)
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                ConsoleKeyInfo input;
                input = Console.ReadKey(true);

                if (input.KeyChar == 'a')
                {
                    if (input.KeyChar == 'a')
                    {
                        //Console.Write(which would you like to buy?);
                        //buying = true;

                    }
                    else if (input.KeyChar == 'b')
                    {
                        //Console.Write(which would you like to buy?);
                        //buying = false;
                    }
                    else if (input.KeyChar == 'c')
                    {
                        //Console.Write(which would you like to buy?);
                        //buying = false;
                    }
                }
                else if (input.KeyChar == 'b')
                {
                    //Console.Write(which would you like to buy?);
                    //buying = false;
                }
            }
        }

        /*public GameState SwitchState(GameState newState)
        {
            switchState = newState;
            return newState;
        }*/
    }
}
