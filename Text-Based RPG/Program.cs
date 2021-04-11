using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Program
    {

        static public bool moving = true;

        static void Main(string[] args)
        {

            GameManager gameManager = new GameManager();

            gameManager.RunGame();


        }

        
    }
}
