namespace VPG_Week3
{
    internal class Warrior(string characterName, string battleCry, int age, int power) : Character(characterName, battleCry, age)
    {
        private int _power = power;

        public override void Cry()
        {
            Console.Write($"{_characterName} yells ");
            base.Cry();
        }
    }
}
