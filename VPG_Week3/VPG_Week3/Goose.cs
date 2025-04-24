namespace VPG_Week3
{
    internal class Goose : IBird
    {
        public void MakeSound()
        {
            Console.WriteLine("GEESE");
        }

        public void Threaten()
        {
            Console.WriteLine("Goose threatens!");
        }
    }
}
