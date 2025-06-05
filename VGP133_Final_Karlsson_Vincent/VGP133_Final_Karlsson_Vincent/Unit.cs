using System.Xml.Linq;

namespace VGP133_Final_Karlsson_Vincent
{
    public class Unit
    {
        protected string _name = ""; // avoiding warning

        protected int _maxHP;
        protected int _currentHP;
        protected int _attack;
        protected int _defense;

        protected List<Item> _inventory = new List<Item>();

        // Add equipment for both enemies and players. both can wear, enemies have a chance to drop the equipment

        public string Name { get => _name; protected set => _name = value; }
        public int MaxHP { get => _maxHP; protected set => _maxHP = value > 0 ? value : 1; } // MaxHP can't be set to 0 or less
        public int CurrentHP { get => _currentHP; protected set => _currentHP = value <= MaxHP && value >= 0 ? value : 0; } // CurrentHP can't exceed maxHP or be less than 0
        public int Attack { get => _attack; protected set => _attack = value >= 0 ? value : 0; } // Attack can't be set less than 0
        public int Defense { get => _defense; protected set => _defense = value >= 0 ? value : 0; } // Attack can't be set less than 0

        public Unit(string name, int maxHP, int attack, int defense)
        {
            Name = name;
            MaxHP = maxHP;
            CurrentHP = MaxHP;
            Attack = attack;
            Defense = defense;
        }

        public void AddConsumableToInventory(Consumable item)
        {
            //if (_inventory.c
            //{

            //}

            _inventory.Add(item);
        }

        //public virtual void TakeDamage(ref Unit unit) //cannot pass ref player or ref enemy with this
        //{
        //    int damage = unit.Attack - Defense;
        //    damage = Math.Max(damage, 1); // Ensures damage is at least 1

        //    Console.WriteLine($"{unit.Name} is attacking {Name} for {damage} damage ({Defense} blocked)!");
        //    CurrentHP -= damage;
        //}
    }
}
