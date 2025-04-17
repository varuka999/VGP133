namespace VGP133_A2_Karlsson_Vincent
{
    internal class Magician
    {
        private string _name = "";
        private string _gender = "";
        private int _intelligence;
        private List<Spell> _spellBook = new List<Spell>();

        public string Name { get { return _name; } set { _name = value; } }
        public string Gender { get { return _gender; } set { _gender = value; } }
        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (value <= 0)
                {
                    _intelligence = 0;
                }
                else
                {
                    _intelligence = value;
                }
            }
        }
        public List<Spell> SpellBook { get { return _spellBook; } set { _spellBook = value; } }

        public Magician(string name, string gender, int intelligence)
        {
            _name = name;
            _gender = gender;
            Intelligence = intelligence;
        }

        public void LearnSpell(Spell spell)
        {
            if (_spellBook.Contains(spell) == false)
            {
                Console.WriteLine($"{_name} learned {spell.SpellName}!");
                _spellBook.Add(spell);
            }
            else
            {
                Console.WriteLine($"{_name} already knows {spell.SpellName}!");
            }
        }

        public void UnlearnSpell(Spell spell)
        {
            if (_spellBook.Contains(spell))
            {
                Console.WriteLine($"{_name} unlearned {spell.SpellName}!");
                _spellBook.Remove(spell);
            }
            else
            {
                Console.WriteLine($"{_name} can't unlearn {spell.SpellName}!");
            }
        }

        public void ViewSpellBook()
        {
            if (_spellBook.Count == 0)
            {
                Console.WriteLine($"{_name} spellbook is empty!\n");
                return;
            }

            Console.WriteLine($"{_name}'s spellBook:");
            foreach (Spell spell in _spellBook)
            {
                Console.WriteLine(spell.SpellName);
            }
            Console.WriteLine();
        }

    }
}
