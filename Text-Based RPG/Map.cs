﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {

        //public int x = 0;
        //public int y = 0;

        public string[,] mapArray = new string[,]
                {
                {"╔","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","╗"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","░","░","░","░","░","░","░","░","░","░","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","░","░","░","░","░","░","░","░","░","░","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","░","░","░","░","░","░","░","░","░","░","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","~","~","~","~","~","~","~","~","~","~","~","~","~","~","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","░","░","░","░","░","░","`","`","`","`","~","~","~","~","~","~","~","~","~","~","~","~","~","~","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","░","░","░","░","░","░","`","`","`","`","~","~","~","~","~","~","~","~","~","~","~","~","~","~","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","░","░","░","░","░","░","`","`","`","`","~","~","~","~","~","~","~","~","~","~","~","~","~","~","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","░","░","░","░","░","░","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"║","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","`","║"},
                {"╚","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","╝"},
                };

        public Map()
        {
            //DisplayMap();
        }

        public void DisplayMap()
        {
            for (int x = 0; x <= 19; x++)
            {

                for (int y = 0; y <= 49; y++)
                {
                    Console.Write(mapArray[x, y]);          // displays every row and line of the map
                }

                Console.WriteLine("");
            }

        }

        public bool IsFloor(int x, int y)
        {
            if (mapArray[x, y] == "`")
            {
                return true;
            }
            else return false;

        }
    }
}
