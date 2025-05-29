namespace VGP133_Week7
{
    internal class ClassWork
    {
        public void GenericTypes()
        {
            //GenericStack<GenericClass> genericStack = new GenericStack<GenericClass>();
            GenericStack<int, float> stack = new GenericStack<int, float>();

            stack.Add(1.5f);
            stack.Add(1);
            stack.Add(2);
            stack.Add(2.5f);

            stack.PrintT();
            stack.PrintT2();
            stack.PrintNumber(5);

            Box<int> box = new Box<int>();
            box.Value = 5;
            Console.WriteLine(box.Value);

            Pair<int> pair1 = new Pair<int>(1, 2);
            Console.WriteLine(pair1.Value1);
            Console.WriteLine(pair1.Value2);

            Pair<string> pair2 = new Pair<string>("String 1", "String 2");
            Console.WriteLine(pair2.Value1);
            Console.WriteLine(pair2.Value2);
        }
        public void LINQ()
        {
            int[] numbers = { 11, 22, 33, 44, 55, 66, 77, 88, 99 };

            var oddNumbers = from num in numbers
                             where num % 2 != 0
                             orderby num descending
                             select num;

            var numbersAbove50 = from num in numbers
                                 where num > 50
                                 select num;

            var sumOfNumbers = 0;
            foreach (var num in numbersAbove50)
            {
                sumOfNumbers += num;
            }
            Console.WriteLine(sumOfNumbers);

            foreach (var num in oddNumbers)
            {
                Console.WriteLine(num);
            }

            List<string> names = new List<string> { "Kelly", "sunshine", "Chloe", "Trinette", "shanon", "Gina", "Sabrina", "Sally", "Note", "Jenny" };
            var query = from name in names
                        where name.ToLower().StartsWith("s")
                        orderby name ascending
                        select name.ToUpper();

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }

            List<Person> persons = new List<Person>() { new Person("Sally Ng Sun Gin", 26, 'F'), new Person("Sunshine Sang", 17, 'F'), new Person("Markus Fong", 16, 'M'),
                                                        new Person("Note Sim", 30, 'F'), new Person("Billy Eimen", 14, 'M'), new Person("Silly Simens", 19, 'M')};
            var teens = from person in persons
                        where person.Age >= 13 && person.Age <= 17
                        orderby person.Name ascending
                        select person;

            var namesStartingS = from person in persons
                                 where person.Name.ToLower().StartsWith("s") && person.Age >= 19
                                 orderby person.Name ascending
                                 select person.Name.ToUpper();

            var names12Long = from person in persons
                              where person.Name.Length > 12
                              orderby person.Name ascending
                              select person;

            Console.WriteLine("\nAll Names:");
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Name} aged {person.Age}");
            }

            Console.WriteLine("\nTeens:");
            foreach (var person in teens)
            {
                Console.WriteLine(person.Name);
            }
            Console.WriteLine("\nNames starting S and older than 19:");
            foreach (var person in namesStartingS)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("\nName longer than 12 character:");
            foreach (var person in names12Long)
            {
                Console.WriteLine(person.Name);
            }
        }
        public void Lambdas()
        {
            var squared = (int num) => num * num;
            Console.WriteLine("Squared of 7: " + squared(7));

            var triangleArea = (float b, float h) => (b * h) / 2;
            Console.WriteLine("Triangle area of base of 5 height of 8: " + triangleArea(5, 8));

            var add = (int num, int num2) => num + num2;
            Console.WriteLine(add(1, 2));

            var div = (float num, float num2) => num / num2;
            Console.WriteLine(div(3, 2));

            int[] ints = { 1, 2, 3, 4, 5 };
            var evens = ints.Where(num => num % 2 == 0);
            var odds = ints.Where(num => num % 2 == 1);

            Console.WriteLine("\nAll Nums:");
            foreach (var num in ints)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nEvens:");
            foreach (var num in evens)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("\nOdds:");
            foreach (var num in odds)
            {
                Console.WriteLine(num);
            }


            List<Person> persons = new List<Person>() { new Person("Sally Ng Sun Gin", 26, 'F'), new Person("Sunshine Sang", 17, 'F'), new Person("Markus Fong", 16, 'M'),
                                                        new Person("Note Sim", 30, 'F'), new Person("Billy Eimen", 14, 'M'), new Person("sILlY sImEnS", 19, 'M')};

            Console.WriteLine("\nAll Persons");
            foreach (var person in persons)
            {
                Console.WriteLine(person.Name);
            }    

            var filteredPersons = persons.Where(p => p.Name.ToLower().StartsWith("s") && p.Age > 18).OrderBy(p => p.Age); // .Select also exists

            Console.WriteLine("\nPersons Starting with S and older than 18");
            foreach (var person in filteredPersons)
            {
                Console.WriteLine(person.Name.ToUpper() + " aged " + person.Age);
            }
        }
    }
}
