namespace VPG_Week3
{
    internal class Seagull : IBird
    {
        public void MakeSound()
        {
            Console.WriteLine("SEAGULL");
        }

        public void Threaten()
        {
            Console.WriteLine("Seagull threatens!");
        }
    }
}
