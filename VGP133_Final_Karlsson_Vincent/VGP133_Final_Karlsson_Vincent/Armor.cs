namespace VGP133_Final_Karlsson_Vincent
{
    public class Armor : Equipment
    {
        public Armor(string name, int hpBonus, int attBonus, int defBonus) : base(name, hpBonus, attBonus, defBonus)
        {
            EquipmentType = EquipmentType.Armor;
        }
    }
}
