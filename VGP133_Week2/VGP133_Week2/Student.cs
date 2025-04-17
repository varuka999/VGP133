namespace VGP133_Week2
{
    internal class Student
    {
        private string _name;
        private int _age;
        private int _grade;

        public Student()
        {
            _name = "Student";
            _age = 18;
            _grade = 100;
        }
        public Student(string name, int age, int grade)
        {
            _name = name;
            _age = age;
            _grade = grade;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 4 || value > 100)
                {
                    Console.WriteLine("Age input out of range!");
                }
                else
                {
                    _age = value;
                }
            }
        }
        public int Grade
        {
            get { return _grade; }
            set
            {
                _grade = Math.Clamp(value, 0, 100);
            }

            //set
            //{
            //    if (value >= 0 && value <= 100)
            //    {
            //        _grade = value;
            //    }
            //    else
            //    {
            //        if (value < 0)
            //        {
            //            _grade = 0;
            //        }
            //        else if (value > 100)
            //        {
            //            _grade = 100;
            //        }

            //        Console.WriteLine("Grade has been adjusted to nearest valid value\n");
            //    }
            //}
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Age: {_age}");
            Console.WriteLine($"Grade: {_grade}\n");
        }
    }
}
