namespace VGP133_A3_Karlsson_Vincent
{
    internal class Product(string productName, string description, float price, float discount)
    {
        protected string _productName = productName;
        protected string _description = description;
        protected float _price = price;
        protected float _discount = (100 - discount) / 100;

        public string ProductName { get { return _productName; } }
        public string Description { get { return _description;} }
        
        public float CalculateTax(float taxRate)
        {
            taxRate = 1 + taxRate / 100;
            return GetPrice() * taxRate;
        }

        public float GetPrice()
        {
            return _price *_discount;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Product Name: {_productName}");
            Console.WriteLine($"Description Name: {_description}");
            Console.WriteLine($"Price Name: {_price}");
            Console.WriteLine($"Discount Name: {_discount}\n");
        }
    }
}
