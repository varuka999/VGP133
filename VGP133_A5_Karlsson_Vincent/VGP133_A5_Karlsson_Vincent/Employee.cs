namespace VGP133_A5_Karlsson_Vincent
{
    class Employee
    {
        private string _name;
        private int _age;
        private float _salary;
        private string _email;

        public string Name { get { return _name; } set { _name = value; } } 
        public int Age { get { return _age; } set { _age = value; } } 
        public float Salary { get { return _salary; } set { _salary= value; } } 
        public string Email { get { return _email; } set { _email = value; } } 

        public Employee(string name, int age, float salary, string email)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Email = email;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Employee Info:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Salary: {Salary:C}");
            Console.WriteLine($"Email: {Email}\n");
        }
    }
}
