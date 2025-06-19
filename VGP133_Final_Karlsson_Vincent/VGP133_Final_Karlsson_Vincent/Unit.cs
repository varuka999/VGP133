using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace VGP133_Final_Karlsson_Vincent
{
    [Serializable] // Forced to give everything a public get/setter for the xml save to work smoothly. Alternative was creating a duplicate 'serializable' version of all the classes that needed to be save.. at least as far as I understand it.
    public class Unit
    {
        protected string _name;
        protected UnitType _unitType;

        protected int _maxHP;
        protected int _currentHP;
        protected int _attack;
        protected int _defense;

        protected Weapon? _equippedWeapon = null; // ? Indicates to compilier that it can be null
        protected Armor? _equippedArmor = null; // ? Indicates to compilier that it can be null

        protected List<Item> _inventory = new List<Item>();

        public string Name { get => _name; set => _name = value; }
        public UnitType Type { get => _unitType; set => _unitType = value; }
        public int MaxHP { get => _maxHP;  set => _maxHP = UpdateMaxHP(value); }
        public int CurrentHP { get => _currentHP; set => _currentHP = value; }
        public int Attack { get => _attack; set => _attack = value; }
        public int Defense { get => _defense; set => _defense = value; }
        public Weapon? EquippedWeapon { get => _equippedWeapon; set => _equippedWeapon = value; }
        public Armor? EquippedArmor { get => _equippedArmor; set => _equippedArmor = value; }
        public List<Item> Inventory { get => _inventory; set => _inventory = value; }

        public Unit(string name, int maxHP, int attack, int defense)
        {
            _name = name;
            _maxHP = Math.Max(maxHP, 1);
            _currentHP = MaxHP;
            _attack = attack;
            _defense = defense;
        }

        public void AddItemToInventory(Item item)
        {
            _inventory.Add(item);
        }

        private int UpdateMaxHP(int value) // Only called from within MaxHP setter
        {
            int newValue = Math.Max(value, 1); // MaxHP can't be set less than 1

            if (_currentHP > newValue)
            {
                _currentHP = newValue;
            }

            return newValue;
        }

        public void AdjustCurrentHP(int amount) // The only method to modify CurrentHP. Will subtract if given a negative number
        {
            _currentHP = Math.Clamp(_currentHP + amount, 0, MaxHP); // CurrentHP can't go below 0
        }

        public virtual void AttackTarget(Unit target)
        {
            int damage = Attack + (EquippedWeapon?.AttBonus ?? 0);
            damage = Math.Max(damage, 1); // Technically doing the same check later but it might look weird to be 'attacking for negative dmg'

            Console.WriteLine($"{Name} is attacking {target.Name} for {damage}!");
            target.TakeDamage(damage);
        }

        public virtual void TakeDamage(int dmg)
        {
            int defense = Defense + (EquippedArmor?.DefBonus ?? 0);
            int damage = Math.Max(dmg - defense, 1); // Ensures damage is at least 1

            Console.WriteLine($"{Name} took {damage} damage ({defense} blocked)!");
            AdjustCurrentHP(-damage);
        }

        public Equipment? EquipEquipment(Equipment equipment)
        {
            if (equipment == null)
            {
                return null;
            }

            if (equipment.EquipmentType == EquipmentType.Weapon)
            {
                return SwapEquipment(ref _equippedWeapon, (Weapon)equipment);
            }
            else if (equipment.EquipmentType == EquipmentType.Armor)
            {
                return SwapEquipment(ref _equippedArmor, (Armor)equipment);
            }
            else
            {
                return null;
            }
        }

        public Equipment? SwapEquipment<T>(ref T? currentEquipmentSlot, T newEquipment) where T : Equipment
        {
            if (currentEquipmentSlot != null)
            {
                UnequipStatsUpdate(currentEquipmentSlot);
            }

            EquipStatsUpdate(newEquipment);

            Equipment? returnEquipment = currentEquipmentSlot != null ? (Equipment)currentEquipmentSlot : null;

            currentEquipmentSlot = newEquipment;

            return returnEquipment;
        }

        protected void EquipStatsUpdate(Equipment equippedEquipment)
        {
            MaxHP += equippedEquipment.HPBonus;
            //Attack += equippedEquipment.AttBonus;
            //Defense += equippedEquipment.DefBonus;

            AdjustCurrentHP(equippedEquipment.HPBonus); // Updates current hp, equipping counts as 'free heal'
                                                        // (ex, MaxHP = 100, CurrentHP = 80 | new armor + 10hp | MaxHP = 110, CurrentHP = 90)
        }
        protected void UnequipStatsUpdate(Equipment equippedEquipment)
        {
            AdjustCurrentHP(-equippedEquipment.HPBonus); // Because equipping gave 'free health', unequiping reverts it
                                                         // (ex, MaxHP = 100, CurrentHP = 80 | remove armor that gave 10hp | MaxHP = 90, CurrentHP = 70)
            MaxHP -= equippedEquipment.HPBonus;
            //Attack -= equippedEquipment.AttBonus;
            //Defense -= equippedEquipment.DefBonus;
        }

        public void DropWeapon()
        {
            if (_equippedWeapon != null)
            {
                UnequipStatsUpdate(_equippedWeapon);
                _equippedWeapon = null;
            }
        }

        protected void UnequipAllEquipment()
        {
            if (_equippedWeapon != null)
            {
                _inventory.Add(_equippedWeapon);
                UnequipStatsUpdate(_equippedWeapon);
                _equippedWeapon = null;
            }
            if (_equippedArmor != null)
            {
                _inventory.Add(_equippedArmor);
                UnequipStatsUpdate(_equippedArmor);
                _equippedArmor = null;
            }
        }

        public virtual CombatResult OnDeath()
        {
            return Type == UnitType.Player ? CombatResult.PlayerDefeat : CombatResult.PlayerVictory;
        }

    }
}
