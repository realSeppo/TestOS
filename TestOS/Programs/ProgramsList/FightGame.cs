using System;

namespace TestOS.Programs
{
    public class FightGame : Program
    {
        [Serializable]
        private class Enemy
        {
            public string name;
            public int hp;
            public int maxHP;
            public int damage;
            public int healAmount;
        }
        private Enemy[] enemies = new Enemy[3] { new Enemy() { name = "King", hp = 120, damage = 8, healAmount = 6, maxHP = 120 }, new Enemy() {name = "Pirate", hp = 80, damage = 6 , healAmount = 5, maxHP = 80 }, new Enemy() {name = "Bandit", hp = 50, damage = 4, healAmount = 5, maxHP = 60 } };
        private Enemy nowEnemy;

        private Random rnd = new Random();
        
        public override string ProgramName => "Fight Game";
        public override void Process()
        {
            nowEnemy = null;
            Console.WriteLine("Welcome to Test OS Fight Game!");

            selectEnemy:
            Console.WriteLine("To select an enemy, write his name." + Environment.NewLine + "Enemies:" + Environment.NewLine + "King: hp - 120; damage - 8; heal amount - 6" + Environment.NewLine + "Pirate: hp - 80; damage - 6, heal amount - 5" + Environment.NewLine + "Bandit: hp - 50; damage - 4; heal amount - 5");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(">> ");
            Console.ForegroundColor = Kernel.lettersColor;

            string input = Console.ReadLine();
            foreach (var enemy in enemies)
            {
                if (enemy.name == input)
                {
                    nowEnemy = enemy;
                }
            }
            if (input == "Exit")
            {
                Kernel.inProgram = false;
                return;
            }
            else if(nowEnemy.name == null)
            {
                Error();
                goto selectEnemy;
            }

            int playerHP = 100;
            int maxPlayerHP = 100;
            int playerAttack = 10;
            int playerHealAmount = 6;

            while(playerHP > 0 && nowEnemy.hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"------/Player Turn\------");
                Console.ForegroundColor = Kernel.lettersColor;
                Console.WriteLine("Enter a to attack or h to heal");
                choise:

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(">> ");
                Console.ForegroundColor = Kernel.lettersColor;

                string choice = Console.ReadLine();

                if(choice == "a")
                {
                    int damage = rnd.Next(playerAttack - 1, playerAttack + 1);
                    nowEnemy.hp -= damage;

                    Console.WriteLine("You attacked an enemy and dealt " + damage + " damage! Enemy health points: " + nowEnemy.hp + ".");
                }
                else if(choice == "h")
                {
                    int heal = rnd.Next(playerHealAmount - 1, playerHealAmount + 1);

                    if(playerHP + heal >= maxPlayerHP)
                    {
                        heal = 0;
                    }

                    playerHP += heal;

                    Console.WriteLine("You are healed and recovered " + heal + " health points! You health points: " + playerHP + ".");
                }
                else if(choice == "Exit")
                {
                    Kernel.inProgram = false;
                    return;
                }
                else
                {
                    Error();
                    goto choise;
                }

                if(nowEnemy.hp > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(@"------/Enemy Turn\------");
                    Console.ForegroundColor = Kernel.lettersColor;

                    int enemyChoice = rnd.Next(0,2);

                    if (enemyChoice == 0 || nowEnemy.hp == nowEnemy.maxHP)
                    {
                        int damage = rnd.Next(nowEnemy.damage - 1, nowEnemy.damage + 1);
                        playerHP -= damage;

                        Console.WriteLine("The enemy attacked and dealt " + damage + " damage to you! You health points: " + playerHP + ".");
                    }
                    else
                    {
                        int heal = rnd.Next(nowEnemy.healAmount - 1, nowEnemy.healAmount + 1);

                        if (nowEnemy.hp + heal >= nowEnemy.maxHP)
                        {
                            int damage = rnd.Next(nowEnemy.damage - 1, nowEnemy.damage + 1);
                            playerHP -= damage;

                            Console.WriteLine("The enemy attacked and dealt " + damage + " damage to you! You health points: " + playerHP + ".");
                        }
                        else
                        {
                            nowEnemy.hp += heal;
                        }

                        Console.WriteLine("The enemy healed and restored " + heal + " HP! Enemy health points: " + nowEnemy.hp + ".");
                    }

                    Console.WriteLine();
                }
            }
            if(playerHP <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("The enemy has won!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You won!");
            }
            Console.ForegroundColor = Kernel.lettersColor;
            Console.WriteLine("To exit, enter something.");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(">> ");
            Console.ForegroundColor = Kernel.lettersColor;

            string exitInput = Console.ReadLine();
            Kernel.inProgram = false;
            return;
        }
        private void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unknown command.");
            Console.ForegroundColor = Kernel.lettersColor;
        }
    }
}
