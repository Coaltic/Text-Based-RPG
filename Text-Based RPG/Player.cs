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
        public bool hasSword = false;
        public bool hasKey = false;
        

        public Player(int x, int y)
        {
            this.Icon = "@";
            this.x = x;
            this.y = y;
            this.attack = 25;
            this.health = 100;
            this.alive = true;
            /*Console.SetCursorPosition(x, y);
            Console.WriteLine(Icon);*/
        }

        

        public void Update(Map map, Player player, EnemyManager enemyManager, Camera camera, Hud hud)
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

                   
                    if (enemyManager.IsEnemy(player.y - 1, player.x, player, hud) == true)
                    {
                        Console.Beep(800, 200);
                    }
                    else if (enemyManager.IsEnemy(player.y - 1, player.x, player, hud) == false)
                    { 
                        y = y - 1;
                        camera.offsetY--; ;

                    }
                    
                                                        
                }
                else if (map.IsDoor(player.y - 1, player.x, player) == true)
                {
                    if (hasKey == true)
                    {
                        Console.SetCursorPosition(x + camera.offsetX, y + camera.offsetY);
                        Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);
                        y = y - 1;
                        camera.offsetY--;

                    }
                    
                }
                else { Collision(); }
            }
            else if (input.KeyChar == 'd')
            {
                if (map.IsFloor(y, x + 1) == true)
                {

                    if (enemyManager.IsEnemy(player.y, player.x + 1, player, hud) == true)
                    {
                        Console.Beep(800, 200);
                    }
                    else //(enemyManager.IsEnemy(player.y, player.x + 1, player) == false)
                    {
                        //Console.SetCursorPosition(x + camera.offsetX, y + camera.offsetY);
                        //Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);
                        x = x + 1;
                        camera.offsetX++;
                        //render.Draw(x, y, Icon, camera, map);
                        //camera.offsetX--;
                    }
                    
                                                        // previous tile is replaced by map tile
                }
                else if (map.IsDoor(player.y, player.x + 1, player) == true)
                {
                    if (hasKey == true)
                    {
                        //Console.SetCursorPosition(x + camera.offsetX, y + camera.offsetY);
                        //Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);
                        x = x + 1;
                        camera.offsetX++;
                        //render.Draw(x, y, Icon, camera, map);
                        //camera.offsetX--;
                    }

                }
                else { Collision(); }
            }
            else if (input.KeyChar == 's')
            {
                if (map.IsFloor(y + 1, x) == true)
                {
                    /*if (itemManager.IsItem(player.y + 1, player.x, player) == true)
                    {
                     

                    }*/
                    if (enemyManager.IsEnemy(player.y + 1, player.x, player, hud) == true)
                    {
                       
                        Console.Beep(800, 200);
                    }
                    else //(enemyManager.IsEnemy(player.y + 1, player.x, player) == false)
                    {
                        //Console.SetCursorPosition(x + camera.offsetX, y + camera.offsetY);
                        //Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);                             // player moves left
                        y = y + 1;
                        camera.offsetY++;
                        //render.Draw(x, y, Icon, camera, map);
                        //camera.offsetY--;
                    }
                                                        // previous tile is replaced by map tile
                }
                else if (map.IsDoor(player.y + 1, player.x, player) == true)
                {
                    if (hasKey == true)
                    {
                        //Console.SetCursorPosition(x + camera.offsetX, y + camera.offsetY);
                        //Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);
                        y = y +  1;
                        camera.offsetY++;
                        //render.Draw(x, y, Icon, camera, map);

                    }
                    else { Collision(); }

                }
                else { Collision(); }
            }
            else if (input.KeyChar == 'a')
            {
                if (map.IsFloor(y, x - 1) == true)
                {
                    /*if (itemManager.IsItem(player.y, player.x - 1, player) == true)
                    {

                    }*/
                    if (enemyManager.IsEnemy(player.y, player.x - 1, player, hud) == true)
                    {
                        Console.Beep(800, 200);

                    }
                    else //(enemyManager.IsEnemy(player.y, player.x - 1, player) == false)
                    {
                        //Console.SetCursorPosition(x + camera.offsetX, y + camera.offsetY);
                        //Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);                       // player moves down
                        x = x - 1;
                        camera.offsetX--;
                        //render.Draw(x, y, Icon, camera, map);
                        //camera.offsetX++;
                    }
                    
                                                        // previous tile is replaced by map tile
                }
                else if (map.IsDoor(player.y, player.x - 1, player) == true)
                {
                    if (hasKey == true)
                    {
                        //Console.SetCursorPosition(x + camera.offsetX, y + camera.offsetY);
                        //Console.Write(map.map[x + camera.offsetX, y + camera.offsetY]);
                        y = y - 1;
                        //render.Draw(x, y, Icon, camera, map);
                        //camera.offsetX++;
                    }

                }
                else { Collision(); }
            }

           


        }

        public void Movement(x, y)
        {

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
            else if (player.x == x && player.y == y + 1)
            {
                return true;
            }
            else if (player.x == x && player.y == y - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPlayerFar(int x, int y, Player player)
        {
            if (player.x >= (x - 8) && player.x <= (x + 8) && player.y <= y + 4 && player.y >= y - 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void TakeDamage(Player player, Enemy enemy, Hud hud)
        {
            player.health = player.health - enemy.attack;

            if (player.health <= 0)
            {
                player.health = 0;
                player.alive = false;

                Hud.GameOver();
            }

            hud.ShowPlayerStats(player);

        }

        


    }
}
