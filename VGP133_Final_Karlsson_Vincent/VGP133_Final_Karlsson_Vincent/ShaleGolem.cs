namespace VGP133_Final_Karlsson_Vincent
{
    internal class ShaleGolem : Monster
    {
        public ShaleGolem(Player player, bool isBasic) : base(player, "Shale Golem", false, isBasic ? 65 : 85, isBasic ? 5 : 10, isBasic ? 5 : 10, isBasic ? 15 : 35)
        {

        }

        protected override void UseSpecial(Unit target)
        {
            Random random = new Random();
            int defenseBonus = random.Next(1, 4);
            Defense += defenseBonus;
            int damage = Defense + (EquippedArmor?.DefBonus ?? 0);
            damage = Math.Max(damage, 1);

            Console.WriteLine($"{Name} uses Shale Skin!");
            Console.WriteLine($"{Name} increases armor by {defenseBonus}!");
            Console.WriteLine($"{Name} is using their armored skin to attack {target.Name} for {damage}!");
            target.TakeDamage(damage);
        }
    }
}
