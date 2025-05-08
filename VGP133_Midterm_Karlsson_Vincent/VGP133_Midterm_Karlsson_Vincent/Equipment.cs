namespace VGP133_Midterm_Karlsson_Vincent
{
    public abstract class Equipment(int hpBonus, int attBonus, int defBonus)
    {
        private int _hpBonus = hpBonus;
        private int _attBonus = attBonus;
        private int _defBonus = defBonus;

        public int HPBonus { get { return _hpBonus; } }
        public int AttBonus { get { return _attBonus; } }
        public int DefBonus { get { return _defBonus; } }
    }
}
