namespace VGP133_Final_Karlsson_Vincent
{
    internal class LargeLeech : Monster
    {
        public LargeLeech(Player player, string name, bool isBoss, int maxHP, int attack, int defense, int goldDropped) : base(player, name, isBoss, maxHP, attack, defense, goldDropped)
        {

        }

        protected override void UseSpecial(Unit target)
        {
            int damage = Attack + (EquippedWeapon?.AttBonus ?? 0);
            damage = Math.Max(damage, 1);
            target.TakeDamage(damage);

            Console.WriteLine($"{Name} uses Blood Drain!");
            Console.WriteLine($"{Name} is attacking {target.Name} for {damage}!");
            int healAmount = (int)(damage * 0.5);

            AdjustCurrentHP(healAmount);
            Console.WriteLine($"{Name} drains {healAmount} HP from {target.Name}!");
        }
    }
}
