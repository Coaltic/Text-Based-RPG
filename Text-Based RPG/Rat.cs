﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Rat : Enemy
    {
        public Rat(int x, int y)
        {
            this.Icon = "R";
            this.x = x;
            this.y = y;
            this.health = 20;
            this.alive = true;
            this.speed = 1;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }
    }
}
