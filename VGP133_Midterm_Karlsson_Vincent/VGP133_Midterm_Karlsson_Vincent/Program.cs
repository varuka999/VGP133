using VGP133_Midterm_Karlsson_Vincent;

Character[] players = { new Character(0, 0, 0, ""), new Character(0, 0, 0, "") }; // Index 0 is player controlled in combat, 1 is AI controlled in combat

Random rand = new Random();

{
    for (int i = 0; i < players.Length; i++)
    {
        int randomizeCharacter = rand.Next(0, 3);
        if (randomizeCharacter == 0)
        {
            Warrior player = new Warrior(200, 20, 15);
            players[i] = player;
        }
        else if (randomizeCharacter == 1)
        {
            Mage player = new Mage(120, 35, 5);
            players[i] = player;
        }
        else if (randomizeCharacter == 2)
        {
            Archer player = new Archer(100, 40, 0);
            players[i] = player;
        }
        else
        {
            --i; // If rand somehow messes up and no valid character was made;
        }
    }
}

List<Weapon> weaponsList = new List<Weapon>();
List<Armor> armorList = new List<Armor>();

Weapon weapon1 = new Weapon(0, 5, 5);
Weapon weapon2 = new Weapon(0, 10, 0);
Weapon weapon3 = new Weapon(0, 15, -5);
weaponsList.Add(weapon1);
weaponsList.Add(weapon2);
weaponsList.Add(weapon3);

Armor armor1 = new Armor(5, 0, 5);
Armor armor2 = new Armor(10, 0, 0);
Armor armor3 = new Armor(5, -5, 10);
armorList.Add(armor1);
armorList.Add(armor2);
armorList.Add(armor3);

// Showcasing Weapon and Armor Equiping
EquipWeapon(0); // Equips first time
EquipWeapon(0); // Equips new weapon and puts previous one back into weapon list
EquipWeapon(1); // continued
EquipWeapon(1);
EquipArmor(0);
EquipArmor(0);
EquipArmor(1);
EquipArmor(1);

// Combat
while (true)
{
    int attackingIndex = rand.Next(0, 2); // Randomizes who goes first, but index 0 is always Player Controlled
    int defendingIndex = 1 - attackingIndex;
    int turnCounter = 1;
    Console.WriteLine("Player 1 Stats: ");
    players[0].DisplayStats();
    Console.WriteLine("Player 2 Stats: ");
    players[1].DisplayStats();
    Console.WriteLine($"Player {attackingIndex + 1} attacks first!");

    Console.WriteLine("Press Any Key to continue...");
    Console.ReadKey();
    Console.Clear();

    while (players[attackingIndex].CurrentHP > 0)
    {
        if (turnCounter != 1)
        {
            Console.WriteLine("Press Any Key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        Console.WriteLine($"<<< Turn {turnCounter} >>>");
        Console.WriteLine($"\nPlayer {attackingIndex + 1} is attacking");
        int attackingIntent = 0;

        if (attackingIndex == 0) // If it is the user controlled players turn
        {
            Console.WriteLine("\n1 to Attack, 2 to use Skill");

            while (attackingIntent != 1 && attackingIntent != 2) // Must press enter again in console if input is a number not 1 or 2
            {
                if (Int32.TryParse(Console.ReadLine(), out attackingIntent) == false || attackingIntent != 1 && attackingIntent != 2)
                {
                    Console.WriteLine("Invalid input!");
                    attackingIntent = 0;
                }
            }
        }
        else // AI controlled player
        {
            attackingIntent = rand.Next(0, 2);
        }

        if (attackingIntent == 1)
        {
            Console.WriteLine($"Player {attackingIndex + 1} uses their Attack!\n");
            players[defendingIndex].TakeDamage(players[attackingIndex].Attack);
        }
        else
        {
            Console.WriteLine($"Player {attackingIndex + 1} uses their Skill Attack!\n");
            players[defendingIndex].TakeDamage(players[attackingIndex].SkillAttack());
        }

        Console.Write("\nPlayer 1: ");
        players[0].DisplayCombatStats();
        Console.Write("Player 2: ");
        players[1].DisplayCombatStats();

        attackingIndex = 1 - attackingIndex; // Swap attackers/defenders
        defendingIndex = 1 - defendingIndex;
        ++turnCounter;
    }

    Console.WriteLine($"\n<< Player {defendingIndex + 1} won! >>\n");

    int continueInput = 0;
    Console.WriteLine("1 to Fight again, 2 to End");
    while (continueInput != 1 && continueInput != 2) // Must press enter again in console if input is a number not 1 or 2
    {
        if (Int32.TryParse(Console.ReadLine(), out continueInput) == false || continueInput != 1 && continueInput != 2)
        {
            Console.WriteLine("Invalid input!");
            continueInput = 0;
        }
    }
    if (continueInput == 1)
    {
        Console.Clear();
        players[0].ResetHealth();
        players[1].ResetHealth();
    }
    else
    {
        break;
    }
}

void EquipWeapon(int playerIndex) // Equips a random Weapon to the select player (index)
{
    int index = rand.Next(0, weaponsList.Count);
    Weapon returnWeapon = players[playerIndex].EquipWeapon(weaponsList[index]);
    weaponsList.RemoveAt(index);

    if (returnWeapon != null)
    {
        weaponsList.Add(returnWeapon);
    }
}
void EquipArmor(int playerIndex) // Equips a random Armor to the select player (index)
{
    int index = rand.Next(0, armorList.Count);
    Armor returnArmor = players[playerIndex].EquipArmor(armorList[index]);
    armorList.RemoveAt(index);

    if (returnArmor != null)
    {
        armorList.Add(returnArmor);
    }
}