namespace Text_Based_RPG
{
    class Item
    {

        public int x;
        public int y;

        public bool active;

        public string Icon;
        public string name;
        public int itemType;


        public void SetItem(int x, int y, int type)
        {
            itemType = type;
            this.active = true;
            this.x = x;
            this.y = y;

            if (type <= 1)
            {
                Icon = "+";
                name = "Healthpack";
            }
            else if (type == 2)
            {
                Icon = "ð";
                name = "Key";
            }
            else if (type == 3)
            {
                Icon = "┼";
                name = "Sword";
            }
        }

        public void Update(Player player, Item item, Hud hud)
        {
                if (item.itemType == 1)
                {
                    player.health = player.health + 25;
                    item.active = false;
                }
                else if (item.itemType == 2)
                {
                    player.hasKey = true;
                    item.active = false;
                }
                else if (item.itemType == 3)
                {
                    player.hasSword = true;
                    item.active = false;
                    player.attack = player.attack + 25;

                }

                hud.ItemCollected(item);
        }

        public void Draw(Camera camera, Render render)
        {
            render.Draw(x, y, Icon, camera);
        }
    }
}
