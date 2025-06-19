namespace VGP133_Final_Karlsson_Vincent
{
    public class Equipment : Item
    {
        public EquipmentType EquipmentType { get; set; }
        public int HPBonus { get; set; }
        public int AttBonus { get; set; }
        public int DefBonus { get; set; }

        public Equipment() : base() { }

        public Equipment(string name, int hpBonus, int attBonus, int defBonus, int cost) : base(name, cost)
        {
            HPBonus = hpBonus;
            AttBonus = attBonus;
            DefBonus = defBonus;
        }
    }
}
