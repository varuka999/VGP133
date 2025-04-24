namespace VPG_Week3
{
    internal class Character(string characterName, string battleCry, int age)
    {
        protected string _characterName = characterName;
        protected string _battleCry = battleCry;
        protected int _age = age;

        public string CharacterName { get { return _characterName; } }
        public string BattleCry { get { return _battleCry; } }
        public int Age { get { return _age; } }

        public virtual void Cry()
        {
            Console.WriteLine(_battleCry);
        }
    }
}
