namespace VGP133_A3_Karlsson_Vincent
{
    internal class ShoppingCart : IShoppingCart
    {
        private List<Product> _cart = new List<Product>();

        public List<Product> Cart { get { return _cart; } }

        public void AddToCart(Product product)
        {
            _cart.Add(product);
        }

        public void RemoveFromCart(Product product)
        {
            _cart.Remove(product);
        }

        public float CalculatePrice()
        {
            float totalPrice = 0;

            foreach (Product product in _cart)
            {
                totalPrice += product.GetPrice();
            }

            return totalPrice;
        }

        public void CheckOut(PaymentMethod paymentMethod)
        {
            paymentMethod.ProcessPayment();

            Console.WriteLine("Purchase successful!");

            _cart.Clear();
        }

        public void DisplayCart()
        {
            Console.WriteLine("Cart: ");

            foreach (Product product in _cart)
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine($"Total Price: ${CalculatePrice()}\n");
        }
    }
}
