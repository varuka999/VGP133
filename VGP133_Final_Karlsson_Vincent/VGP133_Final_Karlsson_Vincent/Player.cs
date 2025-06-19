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

        public override bool OnDeath()
        {
            Console.WriteLine($"PLAYER ({Name}) DIED");
            return true;
        }
    }

}
