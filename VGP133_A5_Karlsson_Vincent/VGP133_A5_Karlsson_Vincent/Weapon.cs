namespace VGP133_A5_Karlsson_Vincent
{
    public class Weapon
    {
        private string _weaponName;
        private int _atkPower;
        private int _strRequirement;
        private string _ownerName;

        public string WeaponName { get { return _weaponName; } set { _weaponName = value; } }
        public int ATKPower { get { return _atkPower; } set { _atkPower = value; } }
        public int StrengthRequirement { get { return _strRequirement; } set { _strRequirement = value; } }
        public string OwnerName { get { return _ownerName; } set { _ownerName = value; } }

        public Weapon() { }

        public Weapon(string weaponName, int atkPower, int strengthReq, string ownerName)
        {
            WeaponName = weaponName;
            ATKPower = atkPower;
            StrengthRequirement = strengthReq;
            OwnerName = ownerName;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Weapon Stats:");
            Console.WriteLine($"Name: {WeaponName}");
            Console.WriteLine($"Attack Power: {ATKPower}");
            Console.WriteLine($"Strength Requirement: {StrengthRequirement}");
            Console.WriteLine($"Owner: {OwnerName}");
        }
    }
}
