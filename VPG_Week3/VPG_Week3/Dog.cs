namespace VPG_Week3
{
    internal class Dog : Animal
    {
        public Dog(string name)
            : base(name)
        {

        }

        public override string MakeNoise()
        {
            return "Woof";
        }
    }
}
