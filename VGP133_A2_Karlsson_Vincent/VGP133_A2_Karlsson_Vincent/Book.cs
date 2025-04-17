namespace VGP133_A2_Karlsson_Vincent
{
    internal class Book
    {
        private string _name = "";
        private string _title = "";
        private string _author = "";
        private int _isbn;
        private bool _isAvailable;

        public string Name { get { return _name; } set { _name = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Author { get { return _author; } set { _author = value; } }
        public int ISBN { get { return _isbn; } set { _isbn = value; } }
        public bool IsAvailable { get { return _isAvailable; } set { _isAvailable = value; } }

        public Book(string name, string title, string author, int isbn)
        {
            _name = name;
            _title = title;
            _author = author;
            _isbn = isbn;
            _isAvailable = false;
        }

        public void Checkout()
        {
            if (_isAvailable == true)
            {
                _isAvailable = false;
                Console.WriteLine($"{_name} has been successfully checked out!\n");
            }
            else
            {
                Console.WriteLine($"{_name} was recently checked out!\n");
            }
        }

        public void Return()
        {
            if (_isAvailable == false)
            {
                _isAvailable = true;
                Console.WriteLine($"{_name} has been successfully returned!\n");
            }
            else
            {
                Console.WriteLine($"{_name} is already available!\n");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"ISBN: {_isbn}");
            Console.WriteLine($"Availability: {_isAvailable}\n");
        }
    }
}
