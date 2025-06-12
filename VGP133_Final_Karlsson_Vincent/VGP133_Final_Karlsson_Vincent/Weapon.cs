namespace VGP133_Final_Karlsson_Vincent
{
    public class Weapon : Equipment
    {
        public Weapon(string name, int hpBonus, int attBonus, int defBonus) : base(name, hpBonus, attBonus, defBonus)
        {
            EquipmentType = EquipmentType.Weapon;
        }
    }
}
