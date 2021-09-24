using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Wallet
    {
        public int walletMax = 20;

        public void Update(Player player)
        {
            Console.SetCursorPosition(60, 2);
            Console.Write("Gold: " + player.gold + "     ");
            if (player.gold > walletMax)
            {
                player.gold = walletMax;
            }
        }

        public void UpdateMax()
        {
            walletMax = walletMax + 20;
        }
    }
}
