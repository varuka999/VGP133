using System.Xml.Linq;

namespace VGP133_Final_Karlsson_Vincent
{
    public class Unit
    {
        protected string _name = ""; // avoiding warning
        protected UnitType _unitType;

        protected int _maxHP;
        protected int _currentHP;
        protected int _attack;
        protected int _defense;

        protected Equipment _equippedWeapon;
        protected Equipment _equippedArmor;

        protected List<Item> _inventory = new List<Item>();

        // Add equipment for both enemies and players. both can wear, enemies have a chance to drop the equipment

        public string Name { get => _name; protected set => _name = value; }
        public UnitType Type { get => _unitType; protected set => _unitType = value; }
        public int MaxHP { get => _maxHP; protected set => _maxHP = value > 0 ? value : 1; } // MaxHP can't be set to 0 or less
        public int CurrentHP { get => _currentHP; protected set => _currentHP = value > MaxHP ? MaxHP : value < 0 ? 0 : value; } // CurrentHP can't exceed maxHP or be less than 0
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

        public virtual void TakeRefUnitDamage<T>(ref T unit) where T : Unit // Generic typing allows ref to derived class when ref base class expected. Research further
        {
            int damage = unit.Attack - Defense;
            damage = Math.Max(damage, 1); // Ensures damage is at least 1

            Console.WriteLine($"{unit.Name} is attacking {Name} for {damage} damage ({Defense} blocked)!");
            CurrentHP -= damage;
        }

        public virtual void TakeUnitDamage(Unit unit) // Creates a copy of the attacking unit.
        {
            int damage = unit.Attack - Defense;
            damage = Math.Max(damage, 1); // Ensures damage is at least 1

            Console.WriteLine($"{unit.Name} is attacking {Name} for {damage} damage ({Defense} blocked)!");
            CurrentHP -= damage;

            Console.WriteLine($"{Name} health remaining: {CurrentHP}");

            //if (CurrentHP <= 0)
            //{
            //    // Unit based events
            //    return true;
            //}

            //return false;
        }

        public virtual void TakeDamage(int dmg)
        {
            int damage = dmg - Defense;
            damage = Math.Max(damage, 1); // Ensures damage is at least 1

            Console.WriteLine($"{Name} took {damage} damage ({Defense} blocked)!");
            CurrentHP -= damage;
        }

        public Equipment EquipWeapon(Weapon weapon)
        {
            if (weapon != null)
            {
                if (_equippedWeapon == null)
                {
                    EquipStatsUpdate(weapon);
                    _equippedWeapon = weapon;
                    return null;
                }
                else
                {
                    UnequipStatsUpdate(_equippedWeapon);
                    EquipStatsUpdate(weapon);

                    Weapon returnWeapon = _equippedWeapon;
                    _equippedWeapon = weapon;
                    return returnWeapon;
                }
            }
            else
            {
                return null;
            }
        }

        protected void EquipStatsUpdate(Equipment equippedEquipment)
        {
            MaxHP += equippedEquipment.HPBonus;
            Attack += equippedEquipment.AttBonus;
            Defense += equippedEquipment.DefBonus;
        }
        protected void UnequipStatsUpdate(Equipment equippedEquipment)
        {
            MaxHP -= equippedEquipment.HPBonus;
            Attack -= equippedEquipment.AttBonus;
            Defense -= equippedEquipment.DefBonus;
        }

        public virtual bool OnDeath()
        {
            Console.WriteLine("ON DEATH EVENT");
            return false;
        }

    }
}
