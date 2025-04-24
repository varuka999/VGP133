namespace VGP133_A2_Karlsson_Vincent
{
    internal class AssignmentQuestions
    {
        public void Question1()
        {
            Rectangle rectangle1 = new Rectangle(5, 5);
            Rectangle rectangle2 = new Rectangle(6, 12);
            Rectangle rectangle3 = new Rectangle(7, 2);

            Console.WriteLine($"Rect1 Perimiter: {rectangle1.GetPerimeter()}");
            Console.WriteLine($"Rect2 Perimiter: {rectangle2.GetPerimeter()}");
            Console.WriteLine($"Rect3 Perimiter: {rectangle3.GetPerimeter()}");

            Console.WriteLine($"Rect1 Area: {rectangle1.GetArea()}");
            Console.WriteLine($"Rect2 Area: {rectangle2.GetArea()}");
            Console.WriteLine($"Rect3 Area: {rectangle3.GetArea()}");

            Console.WriteLine("Rect1 Change Size");
            rectangle1.ChangeSize(4, 7);
            Console.WriteLine("Rect2 Change Size");
            rectangle2.ChangeSize(-1, 3);
            Console.WriteLine("Rect3 Change Size");
            rectangle3.ChangeSize(8, -5);
        }

        public void Question2()
        {
            Employee employee1 = new Employee("Bobby", 80, "lcvbobby@lcv.com");
            Employee employee2 = new Employee("Timmy", 15, "timmy@lcv.com");
            Employee employee3 = new Employee("Samantha", 40, "samantha@yahoo.com");

            employee1.DisplayInfo();
            employee2.DisplayInfo();
            employee3.DisplayInfo();
        }

        public void Question3()
        {
            Book book1 = new Book("Book1", "Title1", "Author1", 1234);
            Book book2 = new Book("Book2", "Title2", "Author2", 2345);
            Book book3 = new Book("Book3", "Title3", "Author3", 3456);

            book1.Return();
            book2.Return();
            book3.Return();
            book3.Return();

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();

            book1.Checkout();
            book2.Checkout();
            book3.Checkout();
            book3.Checkout();

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
        }

        public void Question4()
        {
            Motorway motorway1 = new Motorway("Collingwood", 'e', 2, false, "Redwood");
            Motorway motorway2 = new Motorway("Roller", 'n', 4, true, "The Circus");
            Motorway motorway3 = new Motorway("Diesel");

            Console.WriteLine($"Motorway 1: {motorway1.GetDirectionName()}");
            Console.WriteLine($"Motorway 2: {motorway2.GetDirectionName()}");
            Console.WriteLine($"Motorway 3: {motorway3.GetDirectionName()}");

            Console.WriteLine($"{motorway1.GetDirectionName()}: {motorway1.IsTollRoad()}");
            Console.WriteLine($"{motorway2.GetDirectionName()}: {motorway2.IsTollRoad()}");
            Console.WriteLine($"{motorway3.GetDirectionName()}: {motorway3.IsTollRoad()}");
        }

        public void Question5()
        {
            Magician magician1 = new Magician("Magician1", "Male", 5);
            Magician magician2 = new Magician("Magician2", "Female", 10);
            Magician magician3 = new Magician("Magician3", "Male", 15);

            Spell spell1 = new Spell("Spell1", "Fire", 5, 1);
            Spell spell2 = new Spell("Spell2", "Water", 10, 3);
            Spell spell3 = new Spell("Spell3", "Lightning", 2, -1);

            magician1.LearnSpell(spell1);
            magician1.LearnSpell(spell1);
            magician1.ViewSpellBook();

            magician1.UnlearnSpell(spell1);
            magician1.UnlearnSpell(spell2);
            magician1.ViewSpellBook();

            magician2.LearnSpell(spell1);
            magician2.LearnSpell(spell2);
            magician2.ViewSpellBook();

            magician2.UnlearnSpell(spell1);
            magician2.UnlearnSpell(spell3);
            magician2.ViewSpellBook();

            magician3.LearnSpell(spell2);
            magician3.LearnSpell(spell3);
            magician3.ViewSpellBook();

            magician3.UnlearnSpell(spell1);
            magician3.UnlearnSpell(spell2);
            magician3.UnlearnSpell(spell3);
            magician3.ViewSpellBook();
        }
    }
}
