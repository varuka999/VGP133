namespace VGP133_Final_Karlsson_Vincent
{
    internal class ShaleGolem : Monster
    {
        public ShaleGolem(Player player, string name, bool isBoss, int maxHP, int attack, int defense, int goldDropped) : base(player, name, isBoss, maxHP, attack, defense, goldDropped)
        {

        }

        protected override void UseSpecial(Unit target)
        {
            Random random = new Random();
            int defenseBonus = random.Next(2, 6);
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
