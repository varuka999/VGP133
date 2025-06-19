namespace VGP133_Final_Karlsson_Vincent
{
    [Serializable]
    public class Player : Unit
    {
        protected string _hairColor;
        protected char _gender;
        protected int _age;
        protected int _gold = 0;

        public string HairColor { get => _hairColor; set => _hairColor = value; }
        public char Gender { get => _gender; set => _gender = value; }
        public int Age { get => _age;  set => _age = value >= 18 ? value : 18; } // Age can't be set less than 18
        public int Gold { get => _gold; set => _gold = value; }

        public Player()
            : base("", 0, 0, 0)
        {
            _hairColor = "";
            _gender = 'n';
            _age = 0;
            _gold = 0;
        }

        public Player(string name, string hairColor, char gender, int age, int maxHP, int attack, int defense, int gold) : base(name, maxHP, attack, defense)
        {
            _hairColor = hairColor;
            _unitType = UnitType.Player;
            _gender = gender;
            Age = age;
            AddGold(gold);
        }

        public void AddGold(int amount)
        {
            _gold = Math.Max(_gold + amount, 0);
        }

        public void AddListOfItems(List<Item> items)
        {
            foreach (Item item in items)
            {
                _inventory.Add(item);
            }
        }

        public bool UseItemCombatAction(Unit user)
        {
            while (true)
            {
                var filteredForConsumables = from item in _inventory
                                             where item is Consumable
                                             group item by item.Name into groupedItems
                                             orderby groupedItems.Key ascending
                                             select new { Name = groupedItems.Key, Count = groupedItems.Count() };

                if (filteredForConsumables.Count() == 0)
                {
                    return false;
                }

                int i = 0;
                int input = 0;
                Console.WriteLine("Inventory:");
                foreach (var itemGroup in filteredForConsumables)
                {
                    ++i;
                    Console.WriteLine($"{i}-{itemGroup.Name} x{itemGroup.Count}");
                }

                Console.WriteLine("\nItem to use (0 to cancel): ");
                while (input == 0)
                {
                    while (Int32.TryParse(Console.ReadLine(), out input) == false)
                    {
                        Globals.ClearConsoleLines(1);
                    }

                    if (Globals.ValidateIntInput(ref input, 0, filteredForConsumables.Count() + 1) == false)
                    {
                        Globals.ClearConsoleLines(1);
                        continue;
                    }

                    if (input == 0)
                    {
                        return false;
                    }
                }

                var groupedList = filteredForConsumables.ToList(); // Converts to ienumerable to list for indexing purposes

                return UseConsumable(groupedList[input - 1].Name);
            }
        }

        public bool UseConsumable(string name)
        {
            foreach (Item item in _inventory)
            {
                if (item.Name == name)
                {
                    item.Use(this);
                    _inventory.Remove(item); // Not safe, but should be ok as is, it exits the for loop immediately after altering the container
                    return true;
                }
            }

            return false;
        }

        public void ShowInventoryMenu()
        {
            UI.RenderMenuHeader("Inventory");

            if (_inventory.Count == 0)
            {
                Console.WriteLine("Inventory Empty!");
                Globals.Pause();
                return;
            }

            Console.WriteLine("Sort Options:");
            UI.PrintMenu<SortType>();
            int menuInput = Globals.GetMenuChoice<SortType>();

            SortType sortOption = (SortType)menuInput;
            DisplaySortedGroupedInventory(sortOption);
        }

        public void ShowEquipmentMenu()
        {
            UI.RenderMenuHeader("Equipments");

            var filteredForEquipment = (from item in _inventory
                                        where item is Equipment
                                        group item by item.Name into groupedItems
                                        orderby groupedItems.Key ascending
                                        select new { Name = groupedItems.Key, Count = groupedItems.Count(), Items = groupedItems.ToList() }).ToList(); // List, not ienumerable

            if (filteredForEquipment.Count() == 0)
            {
                Console.WriteLine("No Equipments!");
                Globals.Pause();
                return;
            }

            if (EquippedWeapon != null)
            {
                Console.WriteLine($"Current Weapon: {EquippedWeapon.Name} (HP:{EquippedWeapon.HPBonus} | ATT:{EquippedWeapon.AttBonus} | DEF:{EquippedWeapon.DefBonus})");
            }
            if (EquippedArmor != null)
            {
                Console.WriteLine($"Current Armor: {EquippedArmor.Name} (HP:{EquippedArmor.HPBonus} | ATT:{EquippedArmor.AttBonus} | DEF:{EquippedArmor.DefBonus})");
            }

            int i = 0;
            int input = 0;
            Console.WriteLine("\nInventory:");
            foreach (var itemGroup in filteredForEquipment)
            {
                ++i;
                Console.WriteLine($"{i} - {itemGroup.Name} x{itemGroup.Count}");
            }

            Console.WriteLine("\nChoose an item to equip (0 to cancel): ");
            while (input == 0)
            {
                while (int.TryParse(Console.ReadLine(), out input) == false)
                {
                    Globals.ClearConsoleLines(1);
                }

                if (Globals.ValidateIntInput(ref input, 0, filteredForEquipment.Count() + 1) == false)
                {
                    Globals.ClearConsoleLines(1);
                }

                if (input == 0)
                {
                    return;
                }
            }

            var equipmentSelected = filteredForEquipment[input - 1].Items[0]; // Picks the first matching equipment in its list (That share the same name)

            if (equipmentSelected is Weapon newWeapon)
            {
                Equipment? returnWeapon = EquipEquipment(newWeapon);

                if (returnWeapon != null)
                {
                    _inventory.Add(returnWeapon);
                }

            }
            else if (equipmentSelected is Armor newArmor)
            {
                Equipment? returnArmor = EquipEquipment(newArmor);

                if (returnArmor != null)
                {
                    _inventory.Add(returnArmor);
                }
            }

            _inventory.Remove(equipmentSelected);

            Console.WriteLine($"Equipped {equipmentSelected.Name}!");
        }

        private void DisplaySortedGroupedInventory(SortType sortOption)
        {
            UI.RenderMenuHeader($"Sorted by ({sortOption})");
            DisplayList(_inventory, sortOption);
        }

        public void DisplayList(List<Item> list, SortType sortType)
        {
            var grouped = from item in list
                          group item by item.Name into groupedItems
                          let itemType = groupedItems.First().GetType().BaseType?.Name ?? "Unknown" // It should never be unknown, but for safety
                          select new { Name = groupedItems.Key, Count = groupedItems.Count(), TypeName = itemType };

            switch (sortType)
            {
                case SortType.Name:
                    grouped = grouped.OrderBy(item => item.Name);
                    break;
                case SortType.TypeName:
                    grouped = grouped.OrderBy(item => item.TypeName).ThenBy(item => item.Name);
                    break;
                case SortType.Quantity:
                    grouped = grouped.OrderByDescending(item => item.Count);
                    break;
                default:
                    break;
            }

            Console.WriteLine("Inventory:");
            foreach (var itemGroup in grouped)
            {
                Console.WriteLine($"{itemGroup.Name} ({itemGroup.TypeName}) x{itemGroup.Count}");
            }
        }

        public PlayerAction PlayerCombatActions()
        {
            UI.PrintMenu<PlayerAction>();
            int playerAction = Globals.GetMenuChoice<PlayerAction>();

            return (PlayerAction)playerAction;
        }

        public void DisplayStats()
        {
            Console.Clear();
            Console.WriteLine("--| Character Info |--");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Hair Color: {HairColor}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Age: {Age}");

            Console.WriteLine("\n--| Stats |--");
            Console.WriteLine($"HP: {CurrentHP}/{MaxHP}");
            Console.WriteLine($"Attack: {Attack + (EquippedWeapon?.AttBonus ?? 0)}");
            Console.WriteLine($"Defense: {Defense + (EquippedArmor?.DefBonus ?? 0)}");
            Console.WriteLine($"Gold: {_gold}");

            Console.WriteLine("\n--| Equipped |--");
            Console.WriteLine($"Weapon: {(EquippedWeapon != null ? EquippedWeapon.Name : "None")}");
            Console.WriteLine($"Armor: {(EquippedArmor != null ? EquippedArmor.Name : "None")}");
        }

        public override CombatResult OnDeath()
        {
            _gold /= 2;

            return base.OnDeath();
        }
    }
}
