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

        //public void UseConsumable(Consumable consumable)
        //{
        //    if (consumable != null) 
        //    {
        //        if (_inventory.Contains(consumable) == true)
        //        {
        //            consumable.Consume();
        //            _inventory.Remove(consumable);
        //        }
        //    }
        //}

        //public bool UseConsumable(string name)
        //{
        //    foreach (Consumable c in _inventory)
        //    {
        //        if (c.Name == name)
        //        {
        //            c.Consume();
        //            _inventory.Remove(c);
        //            return true;
        //        }
        //    }

        //    return false;
        //}

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
                DisplayGroupedInventory(sortOption);
                Globals.Pause();
            }
        }

        private void DisplayGroupedInventory(SortType sortOption)
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

        public override bool OnDeath()
        {
            Console.WriteLine($"PLAYER ({Name}) DIED");
            return true;
        }
    }

}
