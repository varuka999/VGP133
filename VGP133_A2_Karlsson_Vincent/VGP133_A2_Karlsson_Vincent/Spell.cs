namespace VGP133_A2_Karlsson_Vincent
{
    internal class Spell
    {
        private string _spellName = "";
        private string _spellElement = "";
        private int _spellPower;
        private int _castTime;

        public string SpellName { get { return _spellName; } set { _spellName = value; } }
        public string SpellElement { get { return _spellElement; } set { _spellElement = value; } }
        public int SpellPower
        {
            get { return _spellPower; }
            set
            {
                if (value < 0)
                {
                    _spellPower = 0;
                }
                else
                {
                    _spellPower = value;
                }
            }
        }
        public int CastTime
        {
            get { return _castTime; }
            set
            {
                if (value < 0)
                {
                    _castTime = 0;
                }
                else
                {
                    _castTime = value;
                }
            }
        }

        public Spell(string spellName, string spellElement, int spellPower, int castTime)
        {
            _spellName = spellName;
            _spellElement = spellElement;
            SpellPower = spellPower;
            CastTime = castTime;
        }
    }
}
