namespace VGP133_Final_Karlsson_Vincent
{
    internal class PebbleBeast : Monster
    {
        public PebbleBeast(Player player, bool isBasic) : base(player, "Pebble Beast", false, isBasic ? 30 : 50, isBasic ? 6 : 12, isBasic ? 7 : 15, isBasic ? 30 : 55)
        {

        }

        protected override void UseSpecial(Unit target)
        {
            Random random = new Random();
            float startingPoint = 1.0f;
            Console.WriteLine($"{Name} is using Relentless Pebbles!");
            while (random.NextDouble() <= startingPoint)
            {
                int damage = Attack / 2;
                damage = Math.Max(damage, 1);

                Console.WriteLine($"{Name} launches a pebble at {target.Name} for {damage}!");
                target.TakeDamage(damage);

                startingPoint *= 0.75f;
            }
            Console.WriteLine("The Relentless Pebbles came to an end!");
        }
    }
}
