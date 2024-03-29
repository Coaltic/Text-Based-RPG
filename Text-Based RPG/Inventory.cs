﻿using System;

namespace Text_Based_RPG
{
    class Inventory
    {
        static public string[] data = System.IO.File.ReadAllLines("InventoryData.txt");
        static public string[] gottenData = data[1].Split(';');

        static public int invLimit = int.Parse(gottenData[0]);
        public Item[] invItem = new Item[invLimit];
        private int startLine = int.Parse(gottenData[1]);

        public Inventory()
        {
            Draw();
        }

        public void Draw()
        {
            int invBorder = (invItem.Length * 2) - 1;

            Console.SetCursorPosition(35, startLine);
            Console.WriteLine("╔" + new string('═', invBorder) + "╗");
            Console.SetCursorPosition(35, startLine + 1);
            for (int x = 0; x < invItem.Length; x++)
            {
                Console.Write("║");

                if (invItem[x] == null)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(invItem[x].Icon);
                }
            }
            Console.Write("║");
            Console.SetCursorPosition(35, startLine + 2);
            Console.WriteLine("╚" + new string('═', invBorder) + "╝");


        }

        public void Update(Item item)
        {
            for (int i = 0; i < invItem.Length; i++)
            {
                if (invItem[i] == null)
                {
                    invItem[i] = item;
                    item.active = false;
                    break;
                }
            }
        }

        public Item GetItemInfo(int input)
        {
            if (invItem[input - 1] != null)
            {
                Item item = invItem[input - 1];
                invItem[input - 1].active = false;
                invItem[input - 1] = null;
                return item;
            }

            return null;
        }
        public void UseInventory(Player player, ConsoleKeyInfo playerInput, Hud hud)
        {

            if (playerInput.KeyChar == '1')
            {
                if (invItem[0] != null)
                {
                    invItem[0].Update(player, invItem[0], hud);
                    invItem[0] = null;
                }
            }
            else if (playerInput.KeyChar == '2')
            {
                if (invItem[1] != null)
                {
                    invItem[1].Update(player, invItem[1], hud);
                    invItem[1] = null;
                }
            }
            else if (playerInput.KeyChar == '3')
            {
                if (invItem[2] != null)
                {
                    invItem[2].Update(player, invItem[2], hud);
                    invItem[2] = null;
                }
            }
            else if (playerInput.KeyChar == '4')
            {
                if (invItem[3] != null)
                {
                    invItem[3].Update(player, invItem[3], hud);
                    invItem[3] = null;
                }
            }
            else if (playerInput.KeyChar == '5')
            {
                if (invItem[4] != null)
                {
                    invItem[4].Update(player, invItem[4], hud);
                    invItem[4] = null;
                }
            }
            else if (playerInput.KeyChar == '6')
            {
                if (invItem[5] != null)
                {
                    invItem[5].Update(player, invItem[5], hud);
                    invItem[5] = null;
                }
            }
        }
    }
}
