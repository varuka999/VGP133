namespace VGP133_A6_Karlsson_VIncent
{
    internal class Item(string name, string type, int quantity)
    {
        public string Name { get; set; } = name;
        public string ItemType { get; set; } = type;
        public int Quantity { get; set; } = quantity;

        public void PrintDetails()
        {
            Console.WriteLine($"{Name} ({ItemType}) x{Quantity}");
        }
    }
}
