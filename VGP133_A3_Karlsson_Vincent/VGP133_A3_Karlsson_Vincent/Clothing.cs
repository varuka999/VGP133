namespace VGP133_A3_Karlsson_Vincent
{
    internal class Clothing(string size, string color, string material, string productName, string description, float price, float discount) : Product(productName, description, price, discount)
    {
        private string _size = size;
        private string _color = color;
        private string _material = material;

        public override void DisplayInfo()
        {
            Console.WriteLine($"Size: {_size}");
            Console.WriteLine($"Color: {_color}");
            Console.WriteLine($"Material: {_material}\n");
        }

        public bool IsAvailableInColor(string color)
        {
            if ( color == _color )
            {
                return true;
            }

            return false;
        }
    }
}
