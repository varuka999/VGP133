namespace VGP133_Final_Karlsson_Vincent
{
    internal class LargeLeech : Monster
    {
        public LargeLeech(Player player, bool isElite) : base(player, "Large Leech", false, isElite ? 25 : 40, isElite ? 5 : 8, isElite ? 2 : 4, isElite ? 10 : 20)
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
