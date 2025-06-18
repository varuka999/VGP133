using System.Numerics;

namespace VGP133_Final_Karlsson_Vincent
{
    public class GameManager
    {
        private Player _player;

        public GameManager()
        {
            //_player = new Player("TestPlayer", "Brown", 'M', 20, 100, 100, 3); // Player made here
            _player = CreateCharacter();
            Test();
        }

        // Test
        public void Test()
        {
            //_player = new Player("TestPlayer", "Brown", 'M', 20, 100, 10, 3);

            Weapon weaponTest = new Weapon("WTest1", 0, 5, 0, 5);
            Armor armorTest = new Armor("ATest1", 5, 0, 5, 5);

            _player.EquipEquipment(weaponTest);
            _player.EquipEquipment(armorTest);
            //Monster enemy = new Monster(ref _player, "TestEnemy", false, 20, 5, 1, 5);

            //_player.TakeRefUnitDamage(ref enemy);
            //enemy.TakeRefUnitDamage(ref _player);

            //Consumable healthPotion1 = new HealthPotion(ref _player, "Basic Health Potion", "", 10, 5);
            //Consumable healthPotion2 = new HealthPotion(ref _player, "Advanced Health Potion", "", 25, 10);
            //Consumable healthPotion3 = new HealthPotion(ref _player, "Super Health Potion", "", 50, 20);
            //Consumable healthPotion4 = new HealthPotion(ref _player, "Basic Health Potion", "", 10, 5);

            //_player.AddConsumableToInventory(healthPotion1);
            //_player.AddConsumableToInventory(healthPotion2);
            //_player.AddConsumableToInventory(healthPotion3);
            //_player.AddConsumableToInventory(healthPotion4);

            ////_player.UseConsumable(healthPotion4);
            //if (_player.UseConsumable("Basic Health Potion"))
            //{
            //    Console.WriteLine("Item Use Success");
            //}

            //bool test = healthPotion1.Equals(healthPotion2);
        }

        public void Game()
        {
            bool gameRunning = true;

            while (gameRunning)
            {
                int menuInput = 0;

                Console.Clear();
                for (int i = 1; i < (int)MainMenu.Count; i++)
                {
                    Console.WriteLine($"{i} - {(MainMenu?)Enum.GetValues(typeof(MainMenu)).GetValue(i)}");
                }
                //Console.WriteLine("1 - Town\n2 - Forest\n3 - Mountains\n4 - Boss Castle\nGo To:");

                while (menuInput == 0)
                {
                    while (Int32.TryParse(Console.ReadLine(), out menuInput) == false)
                    {
                        Globals.ClearConsoleLines(1);
                    }

                    if (Globals.ValidateIntInput(ref menuInput, (int)MainMenu.Count) == false)
                    {
                        Globals.ClearConsoleLines(1);
                    }
                }

                switch (menuInput)
                {
                    case (int)MainMenu.Town:
                        Town town = new Town();
                        town.TownScene(_player);
                        break;
                    case (int)MainMenu.Forest:
                        Forest forest = new Forest(_player);
                        forest.RunForest(_player);
                        break;
                    case (int)MainMenu.Mountains:
                        break;
                    case (int)MainMenu.BossCastle:
                        break;
                    case (int)MainMenu.Inventory:
                        break;
                    case (int)MainMenu.Equipment:
                        break;
                    case (int)MainMenu.Save:
                        break;
                    case (int)MainMenu.Load:
                        break;
                    case (int)MainMenu.Exit: Console.WriteLine("\n---EXITING GAME---\n"); gameRunning = false;
                        break;
                    default:
                        break;
                }

            }


        }

        private Player CreateCharacter()
        {
            Console.WriteLine("---Character Creation---");

            Console.Write("Enter name: ");
            string name = Console.ReadLine()?.Trim() ?? "Unknown";

            Console.Write("Enter hair color: ");
            string hairColor = Console.ReadLine()?.Trim() ?? "Unknown";

            char gender;
            while (true)
            {
                Console.Write("Enter gender (M/F/O): ");
                string genderInput = Console.ReadLine()?.Trim().ToUpper() ?? "U";
                if ((genderInput[0] == 'M' || genderInput[0] == 'F' || genderInput[0] == 'O') || genderInput[0] == 'U')
                {
                    gender = genderInput[0];
                    break;
                }
                Globals.ClearConsoleLines(2);
                Console.WriteLine("Invalid Input! Please enter M, F, or O.\n");
            }

            int age;
            while (true)
            {
                Console.Write("Enter your age (must be 18+): ");
                string ageInput = Console.ReadLine()?.Trim() ?? "999";
                if (int.TryParse(ageInput, out age) && age >= 18)
                {
                    break;
                }
                Globals.ClearConsoleLines(2);
                Console.WriteLine("Invalid Input! Please enter an whole number 18 or higher.\n");
            }

            int baseHP = 100;
            int baseAtt = 10;
            int baseDef = 5;

            Console.WriteLine("\n-Character created!-\n");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Hair Color: {hairColor}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"HP: {baseHP}, ATK: {baseAtt}, DEF: {baseDef}");
            Console.WriteLine();

            return new Player(name, hairColor, gender, age, baseHP, baseAtt, baseDef);
        }
    }
}
