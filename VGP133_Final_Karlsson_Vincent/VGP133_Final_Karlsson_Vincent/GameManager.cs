namespace VGP133_Final_Karlsson_Vincent
{
    public class GameManager
    {
        private Player? _player = null;

        public Player? Player { get => _player; }

        public GameManager()
        {

            //UI.RenderMenuHeader("Game Start");
            //Test();
        }

        public void Initialize(bool createCharacter)
        {
            if (createCharacter == true)
            {
                _player = CreateCharacter();
                _player.AddGold(10);
            }
            else
            {
                LoadSave();
            }
        }

        // Test
        public void Test()
        {
            //_player = new Player("TestPlayer", "Brown", 'M', 20, 100, 10, 3);

            //Weapon weaponTest = new Weapon("WTest1", 0, 5, 0, 10);
            //Armor armorTest = new Armor("ATest1", 5, 0, 5, 15);
            //HealthPotion potionTest = new HealthPotion("HPTest", 5, 5);
            //HealthPotion potionTest2 = new HealthPotion("HPTest", 5, 5);
            //HealthPotion potionTest3 = new HealthPotion("HPTest2", 10, 10);

            //_player.AddItemToInventory(weaponTest);
            //_player.AddItemToInventory(armorTest);
            //_player.AddItemToInventory(potionTest);
            //_player.AddItemToInventory(potionTest2);
            //_player.AddItemToInventory(potionTest3);
            //_player.EquipEquipment(weaponTest);
            //_player.EquipEquipment(armorTest);

            //_player.ShowInventoryMenu();
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
            if (_player == null) // If you somehow get into the game without the proper intialization
            {
                _player = CreateCharacter();
            }

            bool gameRunning = true;

            while (gameRunning)
            {
                UI.RenderMenuHeader("Overworld");
                UI.PlayerMenuBar(_player);
                UI.PrintMenu<MainMenu>();
                int menuInput = Globals.GetMenuChoice<MainMenu>();

                switch ((MainMenu)menuInput)
                {
                    case MainMenu.Town:
                        Town town = new Town();
                        town.TownScene(_player);
                        break;
                    case MainMenu.Forest:
                        Forest forest = new Forest();
                        forest.Run(_player);
                        break;
                    case MainMenu.Mountains:
                        Mountain mountain = new Mountain();
                        mountain.Run(_player);
                        break;
                    case MainMenu.BossCastle:
                        BossCastle bossCastle = new BossCastle();
                        if (bossCastle.Run(_player) == true)
                        {
                            Globals.Pause();
                            return; // Return to main menu
                        }    
                        break;
                    case MainMenu.Inventory:
                        _player.ShowInventoryMenu();
                        break;
                    case MainMenu.Equipment:
                        _player.ShowEquipmentMenu();
                        break;
                    case MainMenu.Save:
                        UI.RenderMenuHeader("Save Slots");
                        SaveManager.ShowSaveSlots();
                        int slotInput = 0;
                        Console.WriteLine("Select slot to save to (0 to cancel): ");
                        while (slotInput == 0)
                        {
                            while (Int32.TryParse(Console.ReadLine(), out slotInput) == false)
                            {
                                Globals.ClearConsoleLines(1);
                            }

                            if (Globals.ValidateIntInput(ref slotInput, 0, 3) == false)
                            {
                                Globals.ClearConsoleLines(1);
                                continue;
                            }

                            if (slotInput == 0)
                            {
                                break;
                            }
                        }
                        if (slotInput != 0)
                        {
                            SaveManager.Save(_player, slotInput);
                        }
                        break;
                    case MainMenu.Load:
                        LoadSave();
                        break;
                    case MainMenu.Exit:
                        Console.WriteLine("\n--| EXITING GAME |--");
                        gameRunning = false;
                        break;
                    default:
                        break;
                }

                Globals.Pause();
            }
        }

        private Player CreateCharacter()
        {
            string name;
            string hairColor;
            char gender;
            int age;
            int baseHP = 99999;
            int baseAtt = 50;
            int baseDef = 5;
            bool error = false;

            UI.RenderMenuHeader("Character Creation");

            Console.Write("Enter name: ");
            string input = Console.ReadLine()?.Trim() ?? ""; // Extremely rare to be null (eg, Ctrl + Z)
            name = string.IsNullOrWhiteSpace(input) ? "Unknown" : input; // Sets it to something other than "" if empty

            Globals.ClearConsoleLines(1);
            Console.WriteLine($"Name: {name}");

            Console.Write("Enter hair color: ");
            input = Console.ReadLine()?.Trim() ?? "";
            hairColor = string.IsNullOrWhiteSpace(input) ? "Unknown" : input;

            Globals.ClearConsoleLines(1);
            Console.WriteLine($"Hair Color: {hairColor}");

            while (true)
            {
                Console.Write("Enter gender (M/F/O): ");
                input = Console.ReadLine()?.Trim().ToUpper() ?? "";
                input = string.IsNullOrWhiteSpace(input) ? "U" : input;
                if ((input[0] == 'M' || input[0] == 'F' || input[0] == 'O') || input[0] == 'U')
                {
                    Globals.ClearConsoleLinesBasedOnError(ref error);

                    gender = input[0];
                    break;
                }

                Globals.ClearConsoleLinesBasedOnError(ref error);
                Console.WriteLine("Invalid Input! Please enter M, F, or O!");
            }

            Console.WriteLine($"Gender: {gender}");

            error = false;
            while (true)
            {
                Console.Write("Enter your age (must be 18+): ");
                input = Console.ReadLine()?.Trim() ?? "";
                input = string.IsNullOrWhiteSpace(input) ? "999" : input;
                if (Int32.TryParse(input, out age) && age >= 18)
                {
                    Globals.ClearConsoleLinesBasedOnError(ref error);

                    break;
                }

                Globals.ClearConsoleLinesBasedOnError(ref error);
                Console.WriteLine("Invalid Input! Please enter a whole number 18 or higher!");
            }

            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Base Stats: HP ({baseHP}), ATT ({baseAtt}), DEF ({baseDef})");
            Console.WriteLine("\n-Character created!-");

            return new Player(name, hairColor, gender, age, baseHP, baseAtt, baseDef);
        }

        private void LoadSave()
        {
            UI.RenderMenuHeader("Save Slots");
            SaveManager.ShowSaveSlots();
            int loadInput = 0;
            Console.WriteLine("Select slot to load from (0 to cancel): ");
            while (loadInput == 0)
            {
                while (Int32.TryParse(Console.ReadLine(), out loadInput) == false)
                {
                    Globals.ClearConsoleLines(1);
                }

                if (Globals.ValidateIntInput(ref loadInput, 0, 4) == false)
                {
                    Globals.ClearConsoleLines(1);
                    continue;
                }

                if (loadInput == 0)
                {
                    break;
                }
            }
            if (loadInput != 0)
            {
                Player? loaded = SaveManager.Load(loadInput);
                if (loaded != null)
                {
                    _player = loaded;
                }
            }
        }
    }
}
