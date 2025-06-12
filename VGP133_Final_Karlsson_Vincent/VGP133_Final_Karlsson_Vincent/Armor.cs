namespace VGP133_Final_Karlsson_Vincent
{
    public class Armor : Equipment
    {
        public Armor(string name, int hpBonus, int attBonus, int defBonus, int cost) : base(name, hpBonus, attBonus, defBonus, cost)
        {
            EquipmentType = EquipmentType.Armor;
        }
    }
}
