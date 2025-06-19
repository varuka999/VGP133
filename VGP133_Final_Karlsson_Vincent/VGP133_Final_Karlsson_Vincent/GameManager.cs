namespace VGP133_Final_Karlsson_Vincent
{
    public class GameManager
    {
        private Player? _player = null;

        public Player? Player { get => _player; }

        public void Initialize(bool createCharacter)
        {
            if (createCharacter == true)
            {
                _player = CreateCharacter(false);
            }
            else
            {
                LoadSave();
            }
        }

        public void Game()
        {
            if (_player == null) // If somehow accessed without the proper intialization
            {
                _player = CreateCharacter(false);
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
                        Save();
                        break;
                    case MainMenu.Delete:
                        DeleteSave();
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

        private Player CreateCharacter(bool cheatMode)
        {
            string name;
            string hairColor;
            char gender;
            int age;
            int baseHP = cheatMode ? 99999 : 100;
            int baseAtt = cheatMode ? 100 : 10;
            int baseDef = 5;
            int baseGold = cheatMode ? 10000 : 10;
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

            return new Player(name, hairColor, gender, age, baseHP, baseAtt, baseDef, baseGold);
        }

        private void Save()
        {
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
        }

        private void LoadSave()
        {
            UI.RenderMenuHeader("Load Save");
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

        private void DeleteSave()
        {
            UI.RenderMenuHeader("Delete Save");
            SaveManager.ShowSaveSlots();

            int deleteInput = 0;
            Console.WriteLine("Select slot to delete (0 to cancel): ");
            while (deleteInput == 0)
            {
                while (Int32.TryParse(Console.ReadLine(), out deleteInput) == false)
                {
                    Globals.ClearConsoleLines(1);
                }

                if (Globals.ValidateIntInput(ref deleteInput, 0, 4) == false)
                {
                    Globals.ClearConsoleLines(1);
                    continue;
                }

                if (deleteInput == 0)
                {
                    return;
                }
            }

            string filePath = SaveManager.GetSaveNameFormatPath(deleteInput);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine($"Save Slot {deleteInput} deleted!");
            }
            else
            {
                Console.WriteLine("Save file does not exist.");
            }
        }
    }
}
