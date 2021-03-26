using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player : Character
    {
        public int sword = 0;
        static public bool hasSword = false;
        static public bool hasKey = false;
        

        public Player(int x, int y)
        {
            this.Icon = "@";
            this.x = x;
            this.y = y;
            this.attack = 25;
            this.health = 100;
            this.alive = true;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);
        }

        

        public void Update(Map map, Player player, EnemyManager enemyManager, Item item)
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            if (input.KeyChar == 'w')
            {
                if (map.IsFloor(y - 1, x) == true)
                {
                    
                    if (item.IsItem(player.y - 1, player.x, item) == true)
                    {
                        if (item.name == "Sword") { hasSword = true; }
                        if (item.name == "Key") { hasKey = true; ; }

                        item.active = false;
                        Hud.ItemCollected(item);

                    }
                    if (enemyManager.IsEnemy(player.y - 1, player.x, player) == true)
                    {
                        
                        Console.Beep(800, 200);
                    } 
                    else if (enemyManager.IsEnemy(player.y - 1, player.x, player) == false)
                    {
                        //y = y - 1;
                        Console.SetCursorPosition(x, y);
                        Console.Write(map.map[x, y]);                            
                        y = y - 1;
                    }
                    
                                                        
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 'd')
            {
                if (map.IsFloor(y, x + 1) == true)
                {
                    if (item.IsItem(player.y, player.x + 1, item) == true)
                    {
                        if (item.name == "Sword") { hasSword = true; }
                        if (item.name == "Key") { hasKey = true; ; }

                        item.active = false;
                        Hud.ItemCollected(item);

                    }
                    if (enemyManager.IsEnemy(player.y, player.x + 1, player) == true)
                    {
                        
                        Console.Beep(800, 200);
                    }
                    else if (enemyManager.IsEnemy(player.y, player.x + 1, player) == false)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(map.map[x, y]);
                        x = x + 1;
                    }
                    
                                                        // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 's')
            {
                if (map.IsFloor(y + 1, x) == true)
                {
                    if (item.IsItem(player.y + 1, player.x, item) == true)
                    {
                        if (item.name == "Sword") { hasSword = true; }
                        if (item.name == "Key") { hasKey = true; ; }

                        item.active = false;
                        Hud.ItemCollected(item);

                    }
                    if (enemyManager.IsEnemy(player.y + 1, player.x, player) == true)
                    {
                       
                        Console.Beep(800, 200);
                    }
                    else if (enemyManager.IsEnemy(player.y + 1, player.x, player) == false)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(map.map[x, y]);                             // player moves left
                        y = y + 1;
                    }
                                                        // previous tile is replaced by map tile
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 'a')
            {
                if (map.IsFloor(y, x - 1) == true)
                {
                    if (item.IsItem(player.y, player.x - 1, item) == true)
                    {
                        if (item.name == "Sword") { hasSword = true; }
                        if (item.name == "Key") { hasKey = true; ; }

                        item.active = false;
                        Hud.ItemCollected(item);

                    }
                    if (enemyManager.IsEnemy(player.y, player.x - 1, player) == true)
                    {
                        Console.Beep(800, 200);

                    }
                    else if (enemyManager.IsEnemy(player.y, player.x - 1, player) == false)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(map.map[x, y]);                         // player moves down
                        x = x - 1;
                    }
                    
                                                        // previous tile is replaced by map tile
                }
                else { Collision(); }
            }

           


        }

        public bool IsPlayerNear(int x, int y, Player player)
        {
            if (player.x == x - 1 && player.y == y)
            {
                return true;
                
            }
            else if (player.x == x + 1 && player.y == y)
            {
                return true;
            }
            else if (player.x == x && player.y + 1 == y)
            {
                return true;
            }
            else if (player.x == x && player.y - 1 == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void TakeDamage(Player player, Enemy enemy)
        {
            player.health = player.health - enemy.attack;

            if (player.health <= 0)
            {
                player.health = 0;
                player.alive = false;
                
                //player = null;
            }

            //Hud.ShowPlayerStats(player, map);

        }


    }
}
