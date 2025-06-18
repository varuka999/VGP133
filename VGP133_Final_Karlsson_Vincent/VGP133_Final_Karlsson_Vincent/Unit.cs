using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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

        protected Weapon? _equippedWeapon = null;
        protected Armor? _equippedArmor = null;

        protected List<Item> _inventory = new List<Item>();

        // Add equipment for both enemies and players. both can wear, enemies have a chance to drop the equipment

        public string Name { get => _name; protected set => _name = value; }
        public UnitType Type { get => _unitType; protected set => _unitType = value; }
        public int MaxHP { get => _maxHP; protected set => _maxHP = Math.Max(value, 1); } // MaxHP can't be set less than 1
        public int CurrentHP { get => _currentHP; protected set => _currentHP = value > MaxHP ? MaxHP : value < 0 ? 0 : value; } // CurrentHP can't exceed maxHP or be less than 0 ------ VERIFY!!!!!!!!
        public int Attack { get => _attack; protected set => _attack = Math.Max(value, 1); } // Attack can't be set less than 1
        public int Defense { get => _defense; protected set => _defense = Math.Max(value, 1); } // Attack can't be set less than 1
        public Weapon? EquippedWeapon { get => _equippedWeapon; }
        public Armor? EquippedArmor { get => _equippedArmor; }

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
            _inventory.Add(item);
        }

        public virtual void AttackTarget(Unit target)
        {
            int damage = Attack + (EquippedWeapon?.AttBonus ?? 0);
            damage = Math.Max(damage, 1); // Technically doing the same check later but it might look weird to be 'attacking for negative dmg'.

            Console.WriteLine($"{Name} is attacking {target.Name} for {damage}!");
            target.TakeDamage(damage);
        }

        //public virtual void TakeRefUnitDamage<T>(ref T unit) where T : Unit // Generic typing allows ref to derived class when ref base class expected. Research further
        //{
        //    int damage = unit.Attack - Defense;
        //    damage = Math.Max(damage, 1); // Ensures damage is at least 1

        //    Console.WriteLine($"{unit.Name} is attacking {Name} for {damage} damage ({Defense} blocked)!");
        //    CurrentHP -= damage;
        //}

        public virtual void TakeUnitDamage(Unit unit) // Creates a copy of the attacking unit.
        {
            int attBonus = unit.EquippedWeapon != null ? unit.EquippedWeapon.AttBonus : 0;
            int defBonus = EquippedArmor != null ? EquippedArmor.DefBonus : 0;

            int damage = (unit.Attack + attBonus) - (Defense + defBonus);
            damage = Math.Max(damage, 1); // Ensures damage is at least 1

            CurrentHP -= damage;

            Console.WriteLine($"{Name} took {damage} damage ({Defense} blocked)!");
            Console.WriteLine($"{Name} health remaining: {CurrentHP}\n");
        }

        public virtual void TakeDamage(int dmg)
        {
            int defense = Defense + (EquippedArmor?.DefBonus ?? 0);

            int damage = dmg - defense;
            damage = Math.Max(damage, 1); // Ensures damage is at least 1

            Console.WriteLine($"{Name} took {damage} damage ({defense} blocked)!");
            CurrentHP -= damage;
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
            else // Somehow neither
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

        //public Equipment EquipEquipment(Equipment equipment)
        //{
        //    if (equipment != null)
        //    {
        //        if (equipment.EquipmentType == EquipmentType.Weapon)
        //        {
        //            if (_equippedWeapon == null)
        //            {
        //                EquipStatsUpdate(equipment);
        //                _equippedWeapon = (Weapon)equipment;

        //                return null;
        //            }
        //            else
        //            {
        //                UnequipStatsUpdate(_equippedWeapon);
        //                EquipStatsUpdate(equipment);
        //                Equipment returnEquipment = new Equipment(_equippedWeapon.Name, _equippedWeapon.HPBonus, _equippedWeapon.AttBonus, _equippedWeapon.DefBonus, _equippedWeapon.Cost);
        //                _equippedWeapon = (Weapon)equipment;

        //                return returnEquipment;
        //            }
        //        }
        //        else if (equipment.EquipmentType == EquipmentType.Armor)
        //        {
        //            if (_equippedArmor == null)
        //            {
        //                EquipStatsUpdate(equipment);
        //                _equippedArmor = (Armor)equipment;

        //                return null;
        //            }
        //            else
        //            {
        //                UnequipStatsUpdate(_equippedArmor);
        //                EquipStatsUpdate(equipment);
        //                Equipment returnEquipment = new Equipment(_equippedArmor.Name, _equippedArmor.HPBonus, _equippedArmor.AttBonus, _equippedArmor.DefBonus, _equippedArmor.Cost);
        //                _equippedArmor = (Armor)equipment;

        //                return returnEquipment;
        //            }
        //        }
        //        else // Something went wrong!
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        protected void EquipStatsUpdate(Equipment equippedEquipment)
        {
            MaxHP += equippedEquipment.HPBonus;
            //Attack += equippedEquipment.AttBonus;
            //Defense += equippedEquipment.DefBonus;
        }
        protected void UnequipStatsUpdate(Equipment equippedEquipment)
        {
            MaxHP -= equippedEquipment.HPBonus;
            //Attack -= equippedEquipment.AttBonus;
            //Defense -= equippedEquipment.DefBonus;
        }

        public virtual bool OnDeath()
        {
            Console.WriteLine("ON DEATH EVENT");
            return false;
        }

    }
}
