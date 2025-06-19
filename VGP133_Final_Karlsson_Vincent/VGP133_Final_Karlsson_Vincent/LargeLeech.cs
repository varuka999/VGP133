namespace VGP133_Final_Karlsson_Vincent
{
    internal class LargeLeech : Monster
    {
        public LargeLeech(Player player, bool isBasic) : base(player, "Large Leech", false, isBasic ? 25 : 40, isBasic ? 3 : 6, isBasic ? 2 : 4, isBasic ? 10 : 20)
        {

        }

        protected override void UseSpecial(Unit target)
        {
            int damage = Attack + (EquippedWeapon?.AttBonus ?? 0);
            damage = Math.Max(damage, 1);
            target.TakeDamage(damage);

            Console.WriteLine($"{Name} uses Blood Drain!");
            Console.WriteLine($"{Name} drains {damage} HP from {target.Name}!");
            AdjustCurrentHP(damage);
        }
    }
}
