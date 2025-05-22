namespace VGP133_Midterm_Karlsson_Vincent
{
    public class Mage(int hp, int att, int def) : Character(hp, att, def, "Mage")
    {
        public override int SkillAttack()
        {
            Console.WriteLine("Used Mage Skill Attack!");
            int selfHeal = Attack / 2;
            Console.WriteLine($"Player healed {selfHeal}!");
            CurrentHP += selfHeal;

            return Attack;
        }
    }
}
