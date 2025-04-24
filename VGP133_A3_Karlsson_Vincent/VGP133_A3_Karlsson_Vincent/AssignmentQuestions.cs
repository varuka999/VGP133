namespace VGP133_A3_Karlsson_Vincent
{
    internal class AssignmentQuestions
    {
        // Testing Methods
        public void Question1()
        {
            List<Product> productsList = new List<Product>();
            Book book1 = new Book("MyBook", "Vincent", 2025, "MyBook", "Lorem Ipsum.", 10f, 5f);
            Electronics electronic1 = new Electronics("Gomi", "T-Series", 3, "Gomi Desktop", "Worst Desktop ever made.", 1999f, 75f);
            Electronics electronic2 = new Electronics("Gomi", "T-Series", 3, "Gomi Laptop", "Worst Laptop ever made.", 999f, 60f);
            Clothing clothing1 = new Clothing("M", "Red", "Silk", "Red Shirt", "It's a typical red shirt.", 35f, 20f);
            Clothing clothing2 = new Clothing("L", "Green", "Cotton", "Green Shirt", "It's a typical green shirt.", 40f, 22.5f);

            Console.WriteLine($"{book1.ProductName} price after tax 25%: {book1.CalculateTax(25)}");

            if (book1.IsModern() == true)
            {
                Console.WriteLine($"{book1.ProductName} is modern");
            }
            else
            {
                Console.WriteLine($"{book1.ProductName} is not modern");
            }

            if (electronic1.IsWarrantyValid(5) == true)
            {
                Console.WriteLine($"{electronic1.ProductName} warranty is valid");
            }
            else
            {
                Console.WriteLine($"{electronic2.ProductName} warranty is not valid");
            }

            if (electronic2.IsWarrantyValid(2) == true)
            {
                Console.WriteLine($"{electronic2.ProductName} warranty is valid");
            }
            else
            {
                Console.WriteLine($"{electronic2.ProductName} warranty is not valid");
            }

            if (clothing1.IsAvailableInColor("Red") == true)
            {
                Console.WriteLine($"{clothing1.ProductName} is available in that color");
            }
            else
            {
                Console.WriteLine($"{clothing1.ProductName} is not available in that color");
            }

            if (clothing2.IsAvailableInColor("Red") == true)
            {
                Console.WriteLine($"{clothing2.ProductName} is available in that color");
            }
            else
            {
                Console.WriteLine($"{clothing2.ProductName} is not available in that color");
            }
        }

        // Showcasing Polymorphism
        public void Question2()
        {
            List<Product> productsList = new List<Product>();
            Book book1 = new Book("MyBook", "Vincent", 2025, "MyBook", "Lorem Ipsum.", 10, 5);
            Electronics electronic1 = new Electronics("Gomi", "T-Series", 3, "Gomi Desktop", "Worst Desktop ever made.", 1999f, 75f);
            Electronics electronic2 = new Electronics("Gomi", "T-Series", 3, "Gomi Laptop", "Worst Laptop ever made.", 999f, 60f);
            Clothing clothing1 = new Clothing("M", "Red", "Silk", "Red Shirt", "It's a typical red shirt.", 35f, 20f);
            Clothing clothing2 = new Clothing("L", "Green", "Cotton", "Green Shirt", "It's a typical green shirt.", 40f, 22.5f);


            productsList.Add(book1);
            productsList.Add(electronic1);
            productsList.Add(electronic2);
            productsList.Add(clothing1);
            productsList.Add(clothing2);

            foreach (Product product in productsList)
            {
                product.DisplayInfo();
            }
        }
    }
}
