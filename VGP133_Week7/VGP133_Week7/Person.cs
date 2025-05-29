namespace VGP133_Week7
{
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public char Gender { get; private set; }

        public Person(string name, int age, char gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
    }
}
