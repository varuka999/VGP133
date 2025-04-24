namespace VPG_Week3
{
    internal class Crow : IBird
    {
        public void MakeSound()
        {
            Console.WriteLine("CROW");
        }

        public void Threaten()
        {
            Console.WriteLine("Crow threatens!");
        }
    }
}
