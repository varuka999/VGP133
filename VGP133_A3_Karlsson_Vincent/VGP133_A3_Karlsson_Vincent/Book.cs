namespace VGP133_A3_Karlsson_Vincent
{
    internal class Book(string author, string genre, int publicationYear, string productName, string description, float price, float discount) : Product(productName, description, price, discount)
    {
        private string _author = author;
        private string _genre = genre;
        private int _publicationYear = publicationYear;

        public override void DisplayInfo()
        {
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Genre: {_genre}");
            Console.WriteLine($"Publication Year: {_publicationYear}\n");
        }

        public bool IsModern()
        {
            if (_publicationYear >= 2015)
            {
                return true;
            }

            return false;
        }
    }
}
