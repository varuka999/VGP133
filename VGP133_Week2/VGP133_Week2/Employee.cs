namespace VGP133_Week2
{
    internal class Employee
    {
        private string _name;
        private int _employeeID;
        private float _salary;

        public Employee(string name, int employeeID, float salary)
        {
            _name = name;
            _employeeID = employeeID;
            _salary = salary;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public int EmployeeID { get { return _employeeID; } set { _employeeID = value; } }
        public float Salary
        {
            get { return _salary; }
            set
            {
                if (value > 0)
                {
                    _salary = value;
                }
                else
                {
                    Console.WriteLine("Cannot assign negative salary!\n");
                }
            }
        }

        public void GiveRaise(float amount)
        {
            if (amount > 0)
            {
                _salary += amount;
            }
            else
            {
                Console.WriteLine("Cannot give negative raise!\n");
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {_name}\nID: {_employeeID}\nSalary: {_salary}\n");
        }
    }
}
