namespace VGP133_Final_Karlsson_Vincent
{
    public class Equipment : Item
    {
        public EquipmentType EquipmentType { get; protected set; }
        public int HPBonus { get; private set; }
        public int AttBonus { get; private set; }
        public int DefBonus { get; private set; }

        public Equipment(string name, int hpBonus, int attBonus, int defBonus, int cost) : base(name, "", cost)
        {
            HPBonus = hpBonus;
            AttBonus = attBonus;
            DefBonus = defBonus;
        }
    }
}
