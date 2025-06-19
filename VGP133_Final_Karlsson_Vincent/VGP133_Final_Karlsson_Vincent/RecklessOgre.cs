namespace VGP133_Final_Karlsson_Vincent
{
    internal class RecklessOgre : Monster
    {
        public RecklessOgre(Player player, bool isElite) : base(player, "Reckless Ogre", false, isElite ? 55 : 90, isElite ? 12 : 18, isElite ? 0 : 0, isElite ? 40 : 60)
        {

        }

        protected override void UseSpecial(Unit target)
        {
            Random random = new Random();
            Console.WriteLine($"{Name} is using Reckless Clobber!");
            if (random.NextDouble() <= 0.5)
            {
                int damage = (Attack + (EquippedWeapon?.AttBonus ?? 0)) * 2;
                damage = Math.Max(damage, 1);

                Console.WriteLine($"{Name} is attacking {target.Name} for {damage}!");
                target.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine($"{Name} missed it's attack!");
            }
        }
    }
}
