namespace VGP133_Week2
{
    internal class Car
    {
        private string _name;
        private int _topSpeed;
        private string _revSound;

        public Car()
        {
            _name = "DefaultName";
            _topSpeed = 10;
            _revSound = "DefaultSound";
        }

        public Car(string name, int topSpeed, string revSound)
        {
            _name = name;
            _topSpeed = topSpeed;
            _revSound = revSound;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Car Name: {_name}");
            Console.WriteLine($"Top Speed: {_topSpeed}");
            Console.WriteLine($"Rev Sound: {_revSound}\n");
        }

        public void RevEngine()
        {
            Console.WriteLine(_revSound);
        }
    }
}
