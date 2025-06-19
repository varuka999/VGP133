namespace VGP133_Final_Karlsson_Vincent
{
    internal class RecklessOgre : Monster
    {
        public RecklessOgre(Player player, bool isBasic) : base(player, "Reckless Ogre", false, isBasic ? 55 : 90, isBasic ? 12 : 18, isBasic ? 0 : 0, isBasic ? 40 : 60)
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
