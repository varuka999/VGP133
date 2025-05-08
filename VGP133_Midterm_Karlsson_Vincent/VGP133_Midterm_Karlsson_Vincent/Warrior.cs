namespace VGP133_Midterm_Karlsson_Vincent
{
    public class Warrior(int hp, int att, int def) : Character(hp, att, def, "Warrior")
    {
        public override int SkillAttack()
        {
            Console.WriteLine("Used Warrior Skill Attack!");
            int damage = Attack * 2;

            return damage;
        }
    }
}
