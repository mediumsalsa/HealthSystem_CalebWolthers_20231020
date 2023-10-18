using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HealthSystem_CalebWolthers_20231020
{
    internal class Program
    {

        //Player Variables
        static int maxHealth = 100;
        static int health = maxHealth;
        static string healthStatus;

        static int maxShield = 100;
        static int shield = maxShield;

        static int lives = 10;

        static int xp = 0;
        static int level = 1;
        //static int xpToLevelUp = 100;

        //Game Variables
        static string gamerTag;

        static string breaker = ("<==========================================>");
        

        static void Main(string[] args)
        {

            UnitTestHealthSystem();
            UnitTestXPSystem();

            lives = 3;
            xp = 0;
            level = 1;

            ShowHUD();

            TakeDamage(140);

            ShowHUD();

            IncreaseXP(173);

            ShowHUD();

            TakeDamage(140);

            ShowHUD();

            Revive();

            ShowHUD();

            TakeDamage(120);

            ShowHUD();

            IncreaseXP(234);

            ShowHUD();

            TakeDamage(79);

            ShowHUD();

            Heal(30);

            RegenerateShield(30);

            ShowHUD();

            Heal(300);

            RegenerateShield(300);

            ShowHUD();

            TakeDamage(300);

            ShowHUD();

            Revive();

            ShowHUD();

            TakeDamage(-432);

            Heal(-300);

            RegenerateShield(-300);

            IncreaseXP(-432);

            ShowHUD();

            TakeDamage(300);

            Revive();

            







            Console.ReadKey();
        }


        static void ShowHUD()
        {
            if (health == 100)
            { healthStatus = "Perfect Health"; }
            
            else if (health < 99 && health >= 90)
            { healthStatus = "Healthy"; }

            else if (health < 89 && health >= 75)
            { healthStatus = "Hurt"; }

            else if (health < 74 && health >= 50)
            { healthStatus = "Badly Hurt"; }

            else if (health < 49 && health >= 20)
            { healthStatus = "Danger"; }

            else if (health < 19 && health > 0)
            { healthStatus = "ALMOST DEAD"; }

            else { healthStatus = "Dead"; }


            Console.WriteLine("");
            Console.WriteLine(breaker);
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Health Status: " + healthStatus);
            Console.WriteLine("Lives: " + lives);
            Console.WriteLine("XP: " + xp);
            Console.WriteLine("Level: " + level);
            Console.WriteLine(breaker);
            Console.WriteLine("");
        }

        static void TakeDamage(int damage)
        {
            if (damage >= 0)
            {


                Console.WriteLine("Incoming damage: " + damage);
                Console.WriteLine("");

                if (shield > 0)
                {
                    int currentShield = shield;
                    shield -= damage;

                    if (damage <= shield)
                    {
                        Console.WriteLine("Player has taken " + damage + " damage to their shield!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Player has taken " + currentShield + " damage to their shield!");
                    }


                    int remainingDamage = damage -= currentShield;

                    if (remainingDamage >= 0)
                    {
                        Console.WriteLine("Shield has been destroyed!");
                        Console.WriteLine("");
                        health -= remainingDamage;

                        if (health <= 0)
                        {
                            Console.WriteLine("Player Has Died");
                        }
                        else
                        {
                            Console.WriteLine("Player has taken an additional " + remainingDamage + " damage to their health");
                            Console.WriteLine("");
                        }
                    }
                }
                else if (health > 0)
                {
                    health -= damage;

                    if (health <= 0)
                    {
                        Console.WriteLine("Player Has Died");
                    }
                    else
                    {
                        Console.WriteLine("Player has taken " + damage + " damage to their health!");
                        Console.WriteLine("");
                    }
                }

                if (shield <= 0)
                {
                    shield = 0;
                }
                if (health <= 0)
                {
                    health = 0;
                }

            }

            else
            { 
                Console.WriteLine("Error. Damage cannot be a negative number.");
                Console.WriteLine("Enemy is not trying to heal you.");
                Console.WriteLine("");
            }

        }


        static void Heal(int hp)
        {

            if (hp >= 0)
            {

                health += hp;

                if (health > maxHealth)
                {
                    health = maxHealth;
                    Console.WriteLine("Health has been increased to max! (" + health + ")");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Health has been increased by " + hp + "!");
                    Console.WriteLine("");
                }

            }
            else
            {
                Console.WriteLine("Error. Hp cannot be a negative number.");
                Console.WriteLine("");
            }

        }

        static void RegenerateShield(int hp)
        {

            if (hp >= 0)
            {

                shield += hp;

                if (shield > maxShield)
                {
                    shield = maxShield;
                    Console.WriteLine("Shield has been increased to max! (" + shield + ")");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Shield has been increased by " + hp + "!");
                    Console.WriteLine("");
                }

            }
            else
            {
                Console.WriteLine("Error. Shield Hp cannot be a negative number.");
                Console.WriteLine("");
            }

        }

        static void Revive()
        {
            Console.WriteLine("");

            lives -= 1;

            if (lives > 0)
            {

                health = maxHealth;
                shield = maxShield;

                Console.WriteLine("Player Revived to full!");
            }

            else
            { 
                Console.WriteLine("All lives lost. Game over :(");
                Console.ReadKey();
                
            }

        }

        static void IncreaseXP(int exp)
        {
            if (exp >= 0)
            {

                Console.WriteLine("");

                xp += exp;
                Console.WriteLine("XP has been increased by " + exp + "!");
                Console.WriteLine("");

                int xpToLevelUp = level * 100;

                if (xp >= xpToLevelUp)
                {

                    xp -= xpToLevelUp;

                    level += 1;

                    xpToLevelUp = level * 100;

                    Console.WriteLine("Player Has leveled up to level " + level + "!");

                    int xpNeededLvlUp = xpToLevelUp - xp;

                    Console.WriteLine("");
                    Console.WriteLine(xpNeededLvlUp + " xp needed for next level up");
                }

                else
                {
                    int xpNeeded = xpToLevelUp - xp;

                    Console.WriteLine(xpNeeded + " xp needed for next level up");
                }

            }
            else
            {
                Console.WriteLine("Error. Exp cannot be a negative number.");
                Console.WriteLine("");
            }

        }



        static void UnitTestHealthSystem()
        {
            Debug.WriteLine("Unit testing Health System started...");

            // TakeDamage()

            // TakeDamage() - only shield
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield and health
            shield = 10;
            health = 100;
            lives = 3;
            TakeDamage(50);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 60);
            Debug.Assert(lives == 3);

            // TakeDamage() - only health
            shield = 0;
            health = 50;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 40);
            Debug.Assert(lives == 3);

            // TakeDamage() - health and lives
            shield = 0;
            health = 10;
            lives = 3;
            TakeDamage(25);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield, health, and lives
            shield = 5;
            health = 100;
            lives = 3;
            TakeDamage(110);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            TakeDamage(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Heal()

            // Heal() - normal
            shield = 0;
            health = 90;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 95);
            Debug.Assert(lives == 3);

            // Heal() - already max health
            shield = 90;
            health = 100;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // Heal() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            Heal(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // RegenerateShield()

            // RegenerateShield() - normal
            shield = 50;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 60);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - already max shield
            shield = 100;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            RegenerateShield(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Revive()

            // Revive()
            shield = 0;
            health = 0;
            lives = 2;
            Revive();
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 1);

            Debug.WriteLine("Unit testing Health System completed.");
            Console.Clear();
        }

        static void UnitTestXPSystem()
        {
            Debug.WriteLine("Unit testing XP / Level Up System started...");

            // IncreaseXP()

            // IncreaseXP() - no level up; remain at level 1
            xp = 0;
            level = 1;
            IncreaseXP(10);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 1);

            // IncreaseXP() - level up to level 2 (costs 100 xp)
            xp = 0;
            level = 1;
            IncreaseXP(105);
            Debug.Assert(xp == 5);
            Debug.Assert(level == 2);

            // IncreaseXP() - level up to level 3 (costs 200 xp)
            xp = 0;
            level = 2;
            IncreaseXP(210);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 3);

            // IncreaseXP() - level up to level 4 (costs 300 xp)
            xp = 0;
            level = 3;
            IncreaseXP(315);
            Debug.Assert(xp == 15);
            Debug.Assert(level == 4);

            // IncreaseXP() - level up to level 5 (costs 400 xp)
            xp = 0;
            level = 4;
            IncreaseXP(499);
            Debug.Assert(xp == 99);
            Debug.Assert(level == 5);

            Debug.WriteLine("Unit testing XP / Level Up System completed.");
            Console.Clear();
        }


    }
}
