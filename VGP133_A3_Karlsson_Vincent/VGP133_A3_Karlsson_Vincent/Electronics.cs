namespace VGP133_A3_Karlsson_Vincent
{
    internal class Electronics(string brand, string model, int warrantyPeriod, string productName, string description, float price, float discount) : Product(productName, description, price, discount)
    {
        private string _brand = brand;
        private string _model = model;
        private int _warrantyPeriod = warrantyPeriod;

        public override void DisplayInfo()
        {
            Console.WriteLine($"Brand: {_brand}");
            Console.WriteLine($"Model: {_model}");
            Console.WriteLine($"Warranty: {_warrantyPeriod}\n");
        }

        public bool IsWarrantyValid(int age)
        {
            if (_warrantyPeriod - age > 0)
            {
                return true;
            }

            return false;
        }
    }
}
