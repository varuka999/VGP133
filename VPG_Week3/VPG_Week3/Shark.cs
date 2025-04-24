namespace VPG_Week3
{
    public class Shark(string fishName) : Fish(fishName)
    {
        public override void Swim()
        {
            Console.WriteLine($"{_name} swims aggressively towards its prey!");
        }

        public override void Eat()
        {
            Console.WriteLine($"{_name} chomps");
        }

        public override void Reproduce()
        {
            Console.WriteLine($"{_name} reproduces with a mighty mate!");
        }

        public override void Die()
        {

            Console.WriteLine($"{_name} dies a mighty death!!");
        }
    }
}
