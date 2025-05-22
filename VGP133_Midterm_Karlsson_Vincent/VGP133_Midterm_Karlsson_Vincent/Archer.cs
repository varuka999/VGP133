namespace VGP133_Midterm_Karlsson_Vincent
{
    public class Archer(int hp, int att, int def) : Character(hp, att, def, "Archer")
    {
        public override int SkillAttack()
        {
            Console.WriteLine("Used Archer Skill Attack!");
            Random rand = new Random();

            int damage = Attack;
            int damageStack = rand.Next(1, 4);

            for (int i = 0; i < damageStack; i++) // 50% chance to add additional 50% attack X times
            {
                int randomChance = rand.Next(0, 2);
                if (randomChance == 0)
                {
                    damage += (Attack / 2);
                }
            }

            return damage;
        }
    }
}
