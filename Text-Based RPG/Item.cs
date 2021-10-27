namespace Text_Based_RPG
{
    class Item
    {
        static public string[] data = System.IO.File.ReadAllLines("ItemData.txt");
        static public string[] gottenData;

        public int x;
        public int y;

        public bool active;

        public string Icon;
        public string name;
        public int itemType;
       // public int shopType;
        //public int swordType;

        public int buyPrice;
        public int sellPrice;
        public int swordStrength;
        public int potionType;


        public void SetItem(int x, int y, int type)
        {
            itemType = type;
            this.active = true;
            this.x = x;
            this.y = y;

            gottenData = data[type].Split(';');

            Icon = gottenData[1];
            name = gottenData[2];
            buyPrice = int.Parse(gottenData[3]);
            sellPrice = int.Parse(gottenData[4]);
        }

        public void Update(Player player, Item item, Hud hud)
        {
            if (item.itemType == 1)
            {
                player.health = player.health + 25;
                item.active = false;
                hud.ItemCollected(item);
            }
            else if (item.itemType == 2)
            {
                player.hasKey = true;
                item.active = false;
                hud.ItemCollected(item);
            }
            else if (item.itemType == 3)
            {
                player.gold++;
                item.active = false;
                hud.CoinCollected(item);
            }


            
            hud.ShowPlayerStats(player);
        }

        

        public void Draw(Camera camera, Render render)
        {
            render.Draw(x, y, Icon, camera);
        }
    }
}
