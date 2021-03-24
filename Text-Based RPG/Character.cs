﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Character
    {
        public int x;
        public int y;

        public int health;
        public int attack;

        public bool alive;

        public string Icon;



        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Icon);
        }

        public void Collision()
        {
            Console.Beep(100, 200);                                     // left as a method for future possible additions
        }

    }

    
}
