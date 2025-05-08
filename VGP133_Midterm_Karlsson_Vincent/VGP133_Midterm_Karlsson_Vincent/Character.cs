namespace VGP133_Midterm_Karlsson_Vincent
{
    public class Character
    {
        private string _class;
        private int _maxHP; // cannot be 0 or less
        private int _currentHP; // cannot be less than 0
        private int _attack; // can't be 0 or less, mininum 1
        private int _defense; // can be less than 0

        private Weapon _equippedWeapon = null;
        private Armor _equippedArmor = null;

        public Character (int hp, int att, int def, string characterClass)
        {
            MaxHP = hp;
            Attack = att;
            Defense = def;
            _class = characterClass;
        }

        public int MaxHP
        {
            get { return _maxHP; }
            private set // Private setter only available within class methods
            {
                _maxHP = value;
                if (_maxHP <= 0)
                {
                    _maxHP = 1;
                }

                _currentHP = _maxHP;
            }
        }

        public int CurrentHP
        {
            get { return _currentHP; }

            set
            {
                _currentHP = value;

                if (_currentHP < 0)
                {
                    _currentHP = 0;
                }
                else if (_currentHP > _maxHP)
                {
                    _currentHP = _maxHP;
                }
            }
        }

        public int Attack
        {
            get { return _attack; }
            set
            {
                _attack = value;

                if (_attack < 0)
                {
                    _attack = 1;
                }
            }
        }
        public int Defense { get { return _defense; } set { _defense = value; } }

        public void ResetHealth()
        {
            CurrentHP = MaxHP;
        }

        public Weapon EquipWeapon(Weapon weapon)
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

        public Armor EquipArmor(Armor armor)
        {
            if (armor != null)
            {
                if (_equippedArmor == null)
                {
                    EquipStatsUpdate(armor);
                    _equippedArmor = armor;
                    return null;
                }
                else
                {
                    UnequipStatsUpdate(_equippedArmor);
                    EquipStatsUpdate(armor);

                    Armor returnArmor = _equippedArmor;
                    _equippedArmor = armor;
                    return returnArmor;
                }
            }
            else
            {
                return null;
            }
        }

        private void EquipStatsUpdate(Equipment equippedEquipment)
        {
            MaxHP += equippedEquipment.HPBonus;
            Attack += equippedEquipment.AttBonus;
            Defense += equippedEquipment.DefBonus;
        }
        private void UnequipStatsUpdate(Equipment equippedEquipment)
        {
            MaxHP -= equippedEquipment.HPBonus;
            Attack -= equippedEquipment.AttBonus;
            Defense -= equippedEquipment.DefBonus;
        }

        public virtual int SkillAttack()
        {
            return Attack;
        }

        public void TakeDamage(int damage)
        {
            damage -= _defense;

            if (damage < 0)
            {
                damage = 1;
            }

            Console.WriteLine($"Defending player took {damage} damage ({_defense} blocked)!");
            CurrentHP -= damage;

            Console.WriteLine($"{CurrentHP} hp remaining!");
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Class: {_class}");
            Console.WriteLine($"MaxHP: {_maxHP}");
            Console.WriteLine($"CurrentHP: {_currentHP}");
            Console.WriteLine($"Attack: {_attack}");
            Console.WriteLine($"Defense: {_defense}\n");
        }

        public void DisplayCombatStats()
        {
            Console.Write($"HP: {_currentHP} ");
            Console.Write($"Att: {_attack} ");
            Console.Write($"Def: {_defense}\n");
        }
    }
}
