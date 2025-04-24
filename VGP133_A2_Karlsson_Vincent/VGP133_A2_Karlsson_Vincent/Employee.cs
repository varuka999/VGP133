namespace VGP133_A2_Karlsson_Vincent
{
    internal class Employee
    {
        private string _name = "";
        private int _age = 0;
        private string _email = "";

        public string Name { get { return _name; } set { _name = value; } }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = Math.Clamp(value, 18, 65);
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value.EndsWith("@lcv.com"))
                {
                    _email = value;
                }
                else
                {
                    _email = "guest@lcv.com";
                    Console.WriteLine("Email entered is invalid!\n");
                }
            }
        }

        public Employee(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Age: {_age}");
            CheckValidEmail();
        }

        public void CheckValidEmail()
        {
            if (_email == "guest@lcv.com")
            {
                Console.WriteLine("No valid email address\n");
            }
            else
            {
                Console.WriteLine($"Email: {_email}\n");
            }
        }

    }
}
