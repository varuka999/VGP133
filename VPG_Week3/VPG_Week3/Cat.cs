namespace VPG_Week3
{
    internal class Cat : Animal
    {
        public Cat(string name)
            : base(name) 
        {

        }

        public override string MakeNoise()
        {
            return "Meow";
        }
    }
}
