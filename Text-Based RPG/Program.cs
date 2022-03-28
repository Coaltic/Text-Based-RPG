using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Program
    {
        
        static public bool moving = true;
        //static public double height = SystemParameters.PrimaryScreenHeight;
        //static public double width = SystemParameters.PrimaryScreenWidth;

        static void Main(string[] args)
        {

            GameManager gameManager = new GameManager();
            //Console.SetWindowSize((int)height - 1, (int)width - 1);
            gameManager.RunGame();


        }

        
    }
}
