namespace VPG_Week3
{
    internal class Car(string name) : Vehicle
    {
        public string _carName = name;

        public override void Drive()
        {
            Console.WriteLine("Car go Vroom");
        }

        public void CarHonk()
        {
            Console.WriteLine("Car honks!");
        }
    }
}
