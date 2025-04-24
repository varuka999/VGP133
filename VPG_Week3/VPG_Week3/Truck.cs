using System.Xml.Linq;

namespace VPG_Week3
{
    internal class Truck(string name) : Vehicle
    {
        public string _truckName = name;

        public override void Drive()
        {
            Console.WriteLine("Truck go VROOOOM");
        }

        public void TruckHonk()
        {
            Console.WriteLine("Truck HONKS!!");
        }
    }
}
