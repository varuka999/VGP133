namespace VGP133_Week8
{
    internal class ClassWork
    {
        public void Delegates()
        {
            //void BluntAttack()
            //{
            //    Console.WriteLine("Melee attack!");
            //}

            //void RangedAttack()
            //{
            //    Console.WriteLine("Ranged attack!");
            //}

            //int CritDamage(int damage)
            //{
            //    return damage * 3;
            //}
            //int ShowDamage(int dmg)
            //{
            //    return dmg - 5;
            //}

            //AttackDelegate attackAction;
            //DisplayDamage displayDamage;

            //attackAction = BluntAttack;
            //attackAction(); // Call delegate

            //attackAction = RangedAttack;
            //attackAction();

            //attackAction += BluntAttack; // Adds Melee function to delegate
            //attackAction(); // Both ranged and melee

            //displayDamage = CritDamage;
            //Console.WriteLine(displayDamage(100));

            //displayDamage += ShowDamage; // Will only return last
            //Console.WriteLine(displayDamage(200));

            void EnglishGreeeting(string name)
            {
                Console.WriteLine($"Hello {name}");
            }
            void ChineseGreeeting(string name)
            {
                Console.WriteLine($"Ni Hao {name}");
            }
            void SwedishGreeeting(string name)
            {
                Console.WriteLine($"Hej {name}");
            }

            GreetingDelegate greet;

            greet = EnglishGreeeting;
            greet += ChineseGreeeting;
            greet += SwedishGreeeting;

            greet("Bobby");

            void Add(int a, int b)
            {
                Console.WriteLine($"{a} + {b} = {a + b}");
            }
            void Sub(int a, int b)
            {
                Console.WriteLine($"{a} - {b} = {a - b}");
            }
            void Mult(int a, int b)
            {
                Console.WriteLine($"{a} * {b} = {a * b}");
            }
            void Div(int a, int b)
            {
                Console.WriteLine($"{a} / {b} = {a / b}");
            }

            int input1;
            int input2;
            string input3;
            CalculatorDelegate calculator = null;

            Console.Write("Number1: ");
            input1 = Int32.Parse(Console.ReadLine());
            Console.Write("Number2: ");
            input2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Add, Sub, Mult, Div?");
            input3 = Console.ReadLine();

            switch (input3)
            {
                case "Add":
                    calculator = Add;
                    break;
                case "Sub":
                    calculator = Sub;
                    break;
                case "Mult":
                    calculator = Mult;
                    break;
                case "Div":
                    calculator = Div;
                    break;
                default:
                    break;
            }

            if (calculator != null)
            {
                calculator(input1, input2);
            }
        }

        public void Actions()
        {
            void MeleeAttack()
            {
                Console.WriteLine("Melee Attack");
            }
            void RangedAttack()
            {
                Console.WriteLine("Ranged Attack");
            }
            void MeleeAttack2(int dmg)
            {
                Console.WriteLine("Melee Attack " + dmg);
            }
            void RangedAttack2(int dmg)
            {
                Console.WriteLine("Ranged Attack " + dmg / 2);
            }

            Action attackAction = null;
            Action<int> attackAction2 = null; //Up to 16 parameters

            attackAction += MeleeAttack;
            attackAction += RangedAttack;
            attackAction2 += MeleeAttack2;
            attackAction2 += RangedAttack2;

            if (attackAction != null)
            {
                attackAction();
            }
            if (attackAction2 != null)
            {
                attackAction2(50);
            }
        }

        public void Func()
        {
            float BluntAttack(int damage)
            {
                return damage / 2;
            }
            float PierceAttack(int damage)
            {
                return damage * 2;
            }

            Func<int, float> attackFunc = null; // in, out

            attackFunc = BluntAttack;
            Console.WriteLine("Blunt attack: " + attackFunc(50));
            attackFunc = PierceAttack;
            Console.WriteLine("Pierce attack: " + attackFunc(50));
        }

        public void Lambdas()
        {
            Action meleeAttack = () =>
            {
                Console.WriteLine("Melee Attack! ");
            };

            meleeAttack += () =>
            {
                Console.WriteLine("More Melee Attack!");
            };

            Action<int> meleePierceAttack = (int dmg) =>
            {
                Console.WriteLine($"Melee Pierce Attack {dmg * 2}");
            };

            Func<int, float> pierceFunc = (int dmg) =>
            {
                return dmg * 2;
            };

            AttackDelegate attackAoe = () =>
            {
                Console.WriteLine("Attack AOE!");
            };

            meleeAttack();
            meleePierceAttack(50);
            Console.WriteLine("Pierce damage: " + pierceFunc(75));
            attackAoe();
        }

        public void Practice2()
        {
            int Add(int a, int b, int c)
            {
                return a + b + c;
            }
            int Mult(int a, int b, int c)
            {
                return a * b * c;
            }
            void DisplayMessage(string message, int times)
            {
                for (int i = 0; i < times; i++)
                {
                    Console.WriteLine(message);
                }
            }

            Func<int, int, int, int> practiceFunc = null;

            practiceFunc = Add;
            Console.WriteLine("Adding: " + practiceFunc(3, 5, 10));
            practiceFunc = Mult;
            Console.WriteLine("Multiply: " + practiceFunc(3, 5, 10));

            practiceFunc = (int a, int b, int c) =>
            {
                return (a - b - c);
            };
            Console.WriteLine("Subract: " + practiceFunc(3, 5, 10));

            practiceFunc = (int a, int b, int c) =>
            {
                return (a / b / c);
            };
            Console.WriteLine("Divide: " + practiceFunc(100, 10, 2));

            Action<string, int> practiceAction = null;
            practiceAction += DisplayMessage;

            practiceAction += (string message, int times) =>
            {
                for (int i = 0; i < times; i++)
                    Console.WriteLine(message + " WOW");
            };

            practiceAction("Hello World", 3);
        }

        #region Delegates
        delegate void AttackDelegate();
        delegate int DisplayDamage(int damage);
        delegate void CalculatorDelegate(int a, int b);
        delegate void GreetingDelegate(string name);
        #endregion
    }
}
