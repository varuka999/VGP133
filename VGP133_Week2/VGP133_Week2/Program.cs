using VGP133_Week2;

//BankAccount bankAccount1 = new BankAccount();
//BankAccount bankAccount2 = new BankAccount("Bobby", 100);

//bankAccount1.Deposit(500);
//bankAccount2.Withdraw(50);

//bankAccount1.PrintBalance();
//bankAccount2.PrintBalance();

Car car1 = new Car("Car1", 50, "Vram");
Car car2 = new Car("Car2", 75, "Vrim");
Car car3 = new Car("Car3", 65, "Vroom");

car1.DisplayDetails();
car2.DisplayDetails();
car3.DisplayDetails();

CreditCard card1 = new CreditCard("Card1", 5f);
CreditCard card2 = new CreditCard("Card2", 7.5f);
CreditCard card3 = new CreditCard("Card3", 11.5f);

card1.ComputeCashback(1000);
card2.ComputeCashback(1000);
card3.ComputeCashback(1000);

Employee employee1 = new Employee("Employee1", 1, 500);
Employee employee2 = new Employee("Employee2", 2, 700);
Employee employee3 = new Employee("Employee3", 3, 1000);

employee1.Salary = 1000;
employee2.Salary = -1000;

employee1.GiveRaise(50);
employee2.GiveRaise(100);
employee3.GiveRaise(-100);
employee2.Name = "Named Employee2";

employee1.DisplayDetails();
employee2.DisplayDetails();
employee3.DisplayDetails();

Student student1 = new Student("Student1", 20, 80);
Student student2 = new Student("Student2", 21, 80);
Student student3 = new Student("Student3", 22, 80);

student1.Grade = 50;
student2.Grade = 150;
student3.Grade = -50;

student1.DisplayDetails();
student2.DisplayDetails();
student3.DisplayDetails();

#region Class Work
//bankAccount.publicInt = 1;
//bankAccount.PrivateInt = 2;
//bankAccount.Increment();
//ChangeNumber(ref bankAccount.publicInt);
//Console.WriteLine(bankAccount.publicInt);
//Console.WriteLine(bankAccount.PrivateInt);

//void ChangeNumber(ref int number)
//{
//    number = 42;
//}
#endregion