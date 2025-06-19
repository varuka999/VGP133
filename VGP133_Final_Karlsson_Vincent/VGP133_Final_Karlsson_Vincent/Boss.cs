using System.Security.Cryptography.X509Certificates;

namespace VGP133_Final_Karlsson_Vincent
{
    internal class Boss : Monster
    {
        public Boss(Player player) : base(player, "Progenitus, Monster Lord", true, 200, 15, 10, 1000)
        {
            
        }

        public override void AttackTarget(Unit target)
        {
            Random random = new Random();

            if (random.NextDouble() <= 0.6)
            {
                UseSpecial(target);
            }
            else
            {
                base.AttackTarget(target);
            }
        }

        protected override void UseSpecial(Unit target)
        {
            Random random = new Random();
            int rand = random.Next(0, 4);
            if (rand == 0)
            {
                Console.WriteLine($"{Name} buffed its attack and defense!");
                Buff(4);
            }
            else if (rand == 1)
            {
                Console.WriteLine($"{Name} is using Furious Clobber!");
                if (random.NextDouble() <= 0.5)
                {
                    int damage = Attack * 2;
                    damage = Math.Max(damage, 1);

                    Console.WriteLine($"{Name} is attacking {target.Name} for {damage}!");
                    target.TakeDamage(damage);
                }
                else
                {
                    Console.WriteLine($"{Name} missed it's attack!\n{Name}'s buffed itself in rage!");
                    Buff(2);
                }
            }
            else if (rand == 2)
            {
                float startingPoint = 1.0f;
                Console.WriteLine($"{Name} is using Relentless Assault!");
                while (random.NextDouble() <= startingPoint)
                {
                    int damage = Attack / 3;
                    damage = Math.Max(damage, 1);

                    Console.WriteLine($"{Name} swipes at {target.Name} for {damage}!");
                    target.TakeDamage(damage);

                    startingPoint *= 0.80f;
                }
                Console.WriteLine("Relentless Assault came to an end!");
            }
        }

        private void Buff(int amount)
        {
            Attack += amount;
            Defense += amount;
        }
    }
}
