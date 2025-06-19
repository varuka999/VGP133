using System.Text.RegularExpressions;

namespace VGP133_Final_Karlsson_Vincent
{
    public class Player : Unit
    {
        protected string _hairColor = ""; // avoiding warning
        protected char _gender;
        protected int _age;
        protected int _gold = 0;

        public string HairColor { get => _hairColor; protected set => _hairColor = value; }
        public char Gender { get => _gender; protected set => _gender = value; }
        public int Age { get => _age; protected set => _age = value >= 18 ? value : 18; } // Age can't be set less than 18
        public int Gold { get => _gold; }

        public Player()
            : base("", 0, 0, 0)
        {
            _hairColor = "";
            _gender = 'n';
            _age = 0;
            _gold = 0;
        }

        public Player(string name, string hairColor, char gender, int age, int maxHP, int attack, int defense) : base(name, maxHP, attack, defense)
        {
            HairColor = hairColor;
            Type = UnitType.Player;
            Gender = gender;
            Age = age;
        }

        public void AddGold(int amount)
        {
            _gold = Math.Max(_gold + amount, 0);
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

                Console.WriteLine("Item to use (0 to cancel): ");
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

                var groupedList = filteredForConsumables.ToList(); // Converts to ienumerable to list so I can index easier

                return UseConsumable(groupedList[input - 1].Name);

                //i = 0;
                //foreach (var item in filteredForConsumables)
                //{
                //    ++i;
                //    if (i == input)
                //    {
                //        return UseConsumable(item.Name);
                //    }
                //}
            }
        }

        public bool UseConsumable(string name)
        {
            foreach (Item item in _inventory)
            {
                if (item.Name == name)
                {
                    item.Use(this);
                    _inventory.Remove(item); // Not safe, but should be ok as it exits the for loop immediately after
                    return true;
                }
            }

            return false;
        }

        public void ShowInventoryMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--| Inventory Menu |--");
                Console.WriteLine("Sort Options:");
                Globals.PrintMenu<SortType>();
                int menuInput = Globals.GetMenuChoice<SortType>();

                SortType sortOption = (SortType)menuInput;
                DisplaySortedGroupedInventory(sortOption);
                Globals.Pause();
            }
        }

        private void DisplaySortedGroupedInventory(SortType sortOption)
        {
            Console.Clear();
            Console.WriteLine($"--| Inventory ({sortOption}) |--\n");

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
            Globals.PrintMenu<PlayerAction>();
            int playerAction = Globals.GetMenuChoice<PlayerAction>();

            return (PlayerAction)playerAction;
        }

        //public override CombatResult OnDeath()
        //{
        //    //Console.WriteLine($"Player ({Name}) Died!");
        //    //return CombatResult.PlayerDefeat;
        //    return base.OnDeath();
        //}
    }

}
