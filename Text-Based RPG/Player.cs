using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //File.

namespace Text_Based_RPG
{
    class Player : Character
    {

        public string[] data = System.IO.File.ReadAllLines("PlayerData.txt");
        public string[] gottenData;

        public int level;
        public int exp;
        private int levelUpLimit;


        //public int sword = 0;
        public bool hasKey = false;
        

        Wallet wallet = new Wallet();
        //GameManager gameManager;
        

        public Player(int x, int y)
        {
            GetDataFromText(1);
            Icon = gottenData[1];
            GetDataFromText(2);
            this.x = int.Parse(gottenData[1]);
            GetDataFromText(3);
            this.y = int.Parse(gottenData[1]);

            GetDataFromText(4);
            level = int.Parse(gottenData[1]);
            GetDataFromText(5);
            exp = int.Parse(gottenData[1]);
            GetDataFromText(6);
            levelUpLimit = int.Parse(gottenData[1]);
            GetDataFromText(7);
            attack = int.Parse(gottenData[1]);
            GetDataFromText(8);
            health = int.Parse(gottenData[1]);
            GetDataFromText(9);
            speed = int.Parse(gottenData[1]);
            GetDataFromText(10);
            gold = int.Parse(gottenData[1]);
            alive = true;
        }

        /*public void SetData(int variable, int dataRow)
        {
            GetDataFromText(data);
        }*/

        public void GetDataFromText(int row)
        {
            gottenData = data[row].Split(';');
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
