namespace VPG_Week3
{
    public class Salmon(string fishName) : Fish(fishName)
    {
        public override void Swim()
        {
            Console.WriteLine($"{_name} rapidly swims upstream!");
        }

        public override void Eat()
        {
            Console.WriteLine($"{_name} nibbles");
        }

        public override void Reproduce()
        {
            Console.WriteLine($"{_name} reproduces with a worthy mate!");
        }

        public override void Die()
        {

            Console.WriteLine($"{_name} dies an honorable death!!");
        }
    }
}
