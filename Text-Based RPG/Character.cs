using System;

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

        public virtual void Draw(Camera camera, Render render)
        {
            render.Draw(x, y, Icon, camera);
        }

        public void Collision()
        {
            Console.Beep(100, 200);
        }
    }
}
