namespace VGP133_Final_Karlsson_Vincent
{
    internal class ClumsyOgre : Monster
    {
        public ClumsyOgre(Player player, bool isBasic) : base(player, "Clumsy Ogre", false, isBasic ? 45 : 80, isBasic ? 10 : 15, isBasic ? 2 : 6, isBasic ? 35 : 55)
        {

        }

        protected override void UseSpecial(Unit target)
        {
            Random random = new Random();
            Console.WriteLine($"{Name} is using Dizzying Clobber!");
            if (random.NextDouble() <= 0.5)
            {
                int damage = (Attack + (EquippedWeapon?.AttBonus ?? 0)) * 2;
                damage = Math.Max(damage, 1);

                Console.WriteLine($"{Name} is attacking {target.Name} for {damage}!");
                target.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine($"{Name} missed it's attack!\n{Name}'s attack rose sharply!");
                Attack += 10;
            }
        }
    }
}
