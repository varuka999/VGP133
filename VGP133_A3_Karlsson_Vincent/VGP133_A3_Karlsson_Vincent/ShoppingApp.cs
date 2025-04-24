namespace VGP133_A3_Karlsson_Vincent
{
    internal class ShoppingApp
    {
        private List<Product> _productsList = new List<Product>();

        public ShoppingApp()
        {
            Book book1 = new Book("MyBook", "Vincent", 2025, "MyBook", "Lorem Ipsum.", 10, 5);
            Electronics electronic1 = new Electronics("Gomi", "T-Series", 3, "Gomi Desktop", "Worst Desktop ever made.", 1999f, 55f);
            Electronics electronic2 = new Electronics("Gomi", "T-Series", 5, "Gomi Laptop", "Worst Laptop ever made.", 999f, 65f);
            Clothing clothing1 = new Clothing("M", "Red", "Silk", "Red Shirt", "It's a typical red shirt.", 35f, 20f);
            Clothing clothing2 = new Clothing("L", "Green", "Cotton", "Green Shirt", "It's a typical green shirt.", 40f, 22.5f);


            _productsList.Add(book1);
            _productsList.Add(electronic1);
            _productsList.Add(electronic2);
            _productsList.Add(clothing1);
            _productsList.Add(clothing2);
        }

        private void DisplayAllProducts()
        {
            Console.WriteLine("< Products >");
            foreach (Product product in _productsList)
            {
                Console.WriteLine($"{product.ProductName} ({product.GetPrice()})");
            }
            Console.WriteLine();
        }

        private Product ReturnProductIfValid(string productInput)
        {
            foreach (Product product in _productsList)
            {
                if (product.ProductName == productInput)
                {
                    return product;
                }
            }

            return null;
        }

        public void RunApp()
        {
            ShoppingCart cart = new ShoppingCart();
            string productInput;

            while (true)
            {
                Console.WriteLine("<< Super Market App >>\n");
                DisplayAllProducts();

                if (cart.Cart.Count > 0)
                {
                    cart.DisplayCart();
                }

                Console.WriteLine("(-1 to confirm checkout)");
                Console.Write("Product to add to cart: ");
                productInput = Console.ReadLine();

                Product productToAdd = ReturnProductIfValid(productInput);

                Console.Clear();

                if (productInput == "-1" && cart.Cart.Count > 0)
                {
                    string cardPaymentInput;

                    while (true)
                    {
                        Console.WriteLine($"Payment type (Credit, PayPal, Cash): ");
                        cardPaymentInput = Console.ReadLine();

                        Console.Clear();

                        switch (cardPaymentInput)
                        {
                            case "Credit":
                                CreditCard card = new CreditCard(0, cart.CalculatePrice());
                                cart.CheckOut(card);
                                break;
                            case "PayPal":
                                PayPal payPal = new PayPal(1, cart.CalculatePrice());
                                cart.CheckOut(payPal);
                                break;
                            case "Cash":
                                Cash cash = new Cash(2, cart.CalculatePrice());
                                cart.CheckOut(cash);
                                break;
                            default:
                                Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
                                continue;
                        }

                        break;
                    }

                    Console.WriteLine("Thank you for your purchase!");
                    break;
                }

                if (productToAdd != null)
                {
                    cart.AddToCart(productToAdd);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
