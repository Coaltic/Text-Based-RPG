using System;

namespace Text_Based_RPG
{
    class Player : Character
    {
        public int level = 1;
        public int exp = 0;
        private int levelUpLimit = 30;

        public bool hasKey = false;
        

        Wallet wallet = new Wallet();
        

        public Player(int x, int y)
        {
            this.Icon = "@";
            this.x = x;
            this.y = y;
            this.attack = 25;
            this.health = 100;
            this.speed = 1;
            this.alive = true;
            this.gold = 0;
        }

        public void Update(Map map, Player player, EnemyManager enemyManager, Camera camera, Hud hud, Inventory inventory)
        {
            if (player.exp >= player.levelUpLimit)
            {
                player.exp = player.exp - player.levelUpLimit;
                player.level++;
                player.attack = (int)(player.attack * 1.5d);
                player.levelUpLimit = (int)(player.levelUpLimit * 1.5d);

                hud.PlayerLevelUp(player);
            }

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            if (input.KeyChar == 'w')
            {
                if (Movement(x, y - speed, map, player, enemyManager, hud) == true)
                {
                    if (GameManager.scrollingCamera == false)
                    {
                        camera.offsetY--;
                    }
                }
            }
            else if (input.KeyChar == 'd')
            {
                if (Movement(x + speed, y, map, player, enemyManager, hud) == true)
                {
                    if (GameManager.scrollingCamera == false)
                    {
                        camera.offsetX++;
                    }
                }
            }
            else if (input.KeyChar == 's')
            {
                if (Movement(x, y + speed, map, player, enemyManager, hud) == true)
                {
                    if (GameManager.scrollingCamera == false)
                    {
                        camera.offsetY++;
                    }
                }
            }
            else if (input.KeyChar == 'a')
            {
                if (Movement(x - speed, y, map, player, enemyManager, hud) == true)
                {
                    if (GameManager.scrollingCamera == false)
                    {
                        camera.offsetX--;
                    }
                }
            }
            else
            {
                inventory.UseInventory(player, input, hud);
            }

            wallet.Update(player);
        }

        public bool Movement(int x, int y, Map map, Player player, EnemyManager enemyManager, Hud hud)
        {
            

            if (map.IsFloor(y, x) == true)
            {
                if (enemyManager.IsEnemy(x, y, player, hud) == true)
                {
                    Console.Beep(800, 200);
                    return false;
                }
                else
                {
                    player.y = y;
                    player.x = x;
                    return true;
                }
            }
            else if (hasKey == true)
            {
                if (map.IsLockedDoor(y, x) == true)
                {
                    player.y = y;
                    player.x = x;
                    return true;
                }

                return false;
            }
            else { Collision(); return false; }
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

        public bool HasGold()
        {
            return true;
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

        public void WalletUpgrade()
        {
            wallet.UpdateMax();
        }

        public void PotionEffect(Player player, Item item)
        { 
            if (item.name == "Strength")
            {

                player.attack = player.attack + 10;
                
                //PotionEffectTimer();
            }
            if (item.name == "Regen")
            {
                player.health = player.health + 50;
                //hasRegenEffect = true;
            }
            if (item.name == "Luck")
            {
                player.gold = (int)(player.gold * 1.5d);

            }
        }





    }
}
