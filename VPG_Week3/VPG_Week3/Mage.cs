namespace VPG_Week3
{
    internal class Mage(string characterName, string battyCry, int age) : Character(characterName, battyCry, age)
    {
        public override void Cry()
        {
            Console.Write($"{_characterName} chants ");
            base.Cry();
        }
    }
}
