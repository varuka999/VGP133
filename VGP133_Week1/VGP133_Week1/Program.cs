// See https://aka.ms/new-console-template for more information
#region Strings
//string name1 = "Charles";
//string name2 = "Bobby";
//string name3 = "   Spaces   ";

//Console.WriteLine("Hello, World!");
//Console.Write("No new line. ");
//Console.WriteLine("Hello, World Again!");

//Console.WriteLine($"Hello {name1} and {name2}!");

//Console.WriteLine(@"C:\Documents ""files"".");

//Console.WriteLine($"Hello {name3}.");
//name3 = name3.Trim();
//Console.WriteLine($"Hello {name3}.");
//name3 = name3.Replace("Spaces", "Trimed");
//Console.WriteLine($"Hello {name3}.");
#endregion

#region Numbers and Math
//int a = 25;
//int b = 10;
//float c = 5.5f;
//int sum = a + b;
//int diff = a - b;
//int prod = a * b;
//float div = (float)a / (float)b;
//int mod = a % b;

//Console.WriteLine($"Math operations of {a} and {b}\n");
//Console.WriteLine($"Sum: {sum}");
//Console.WriteLine($"Difference: {diff}");
//Console.WriteLine($"Product: {prod}");
//Console.WriteLine($"Division: {div}");
//Console.WriteLine($"Modulus: {mod}");
#endregion

#region Exercise 1
//string food = "Borger";
//int ing1 = 2;
//float ing2 = 2.5f;
//decimal ing3 = 3.3m;

//Console.WriteLine($"Step by step guide on how to cook {food}\n");
//Console.WriteLine($"Step 1: Prepare {ing1} loafs of bread bun.");
//Console.WriteLine($"Step 2: Cook {ing2} pounds of pork and place it onto 1 bread bun.");
//Console.WriteLine($"Step 3: Add {ing3} kg of melted cheese.");
//Console.WriteLine($"Step 4: Add the second bread bun on top.");
//Console.WriteLine($"Step 5: Eat");
#endregion

#region Reading Console
//string nameInput;
//Console.WriteLine("Enter your name:");
//nameInput = Console.ReadLine();
//Console.WriteLine($"Hello {nameInput}!");

//int choiceInput = 1;
//Console.WriteLine("1 - Go Left\n2 - Go Right");
//choiceInput = Convert.ToInt32(Console.ReadLine()); // Will error if incorrect type input

//if (Int32.TryParse(Console.ReadLine(), out choiceInput) == false)
//{
//    Console.WriteLine("Incorrect input type!");
//}
//else
//{
//    if (choiceInput == 1)
//    {
//        Console.WriteLine($"You went Left!");
//    }
//    else if (choiceInput == 2)
//    {
//        Console.WriteLine($"You went Right!");
//    }
//}
#endregion

#region Conditionals
//int age1 = 18;
//int age2 = 22;

//CanDrink(age1);
//CanDrink(age2);

//void CanDrink(int num)
//{
//    bool canDrink = num >= 19 ? true : false;

//    if (canDrink)
//        Console.WriteLine("Can drink!");
//    else 
//        Console.WriteLine("Cannot drink!");
//}
#endregion

#region Arrays
//int[] arrVer1 = new int[3];
//int[] arrVer2 = new int[3] {1, 2, 3};
//string[] arrVer3 = {"Name1", "Name2", "Name3", "Name4", "Name5" };

//for (int i = 0; i < arrVer2.Length; i++)
//{
//    Console.WriteLine(arrVer2[i]);
//}

//foreach (string name in arrVer3)
//{
//    Console.WriteLine(name);
//}
#endregion

#region Exercise 2
//// 1
//int[] intArr1 = { 15, 25, 53, 44, 55 };
//foreach (int num in intArr1)
//{
//    if (num >= 50)
//    {
//        Console.WriteLine(num);
//    }
//}

//// 2
//int[] gradeArr = new int[4];
//for (int i = 0; i < gradeArr.Length; i++)
//{
//    Console.Write($"Enter Grade {i + 1}: ");
//    gradeArr[i] = Convert.ToInt32(Console.ReadLine());
//}

//int sum = 0;
//foreach (int num in gradeArr)
//{
//    sum += num;
//}

//if (sum / gradeArr.Length >= 60)
//{
//    Console.WriteLine("You passed!");
//}
//else
//{
//    Console.WriteLine("You failed!");
//}

//// 3
//int num1;
//int num2;
//char mathOp;

//Console.WriteLine("Enter number 1: ");
//num1 = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Enter number 2: ");
//num2 = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine("Enter math operator");
//mathOp = Convert.ToChar(Console.ReadLine());

//switch (mathOp)
//{
//    case '+': Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
//        break;
//    case '-': Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
//        break;
//    case '*': Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
//        break;
//    case '/': Console.WriteLine($"{num1} / {num2} = {((float)num1 / (float)num2)}");
//        break;
//    case '%': Console.WriteLine($"{num1} % {num2} = {num1 % num2}");
//        break;
//    default:
//        break;
//}

//// 4
//int gameInput;
//Random rand = new Random();
//while (true)
//{
//    Console.WriteLine("Adventure Game!\n");

//    Console.WriteLine("1 - Move Forward");
//    Console.WriteLine("2 - Move Left");
//    Console.WriteLine("3 - Move Right");

//    if (Int32.TryParse(Console.ReadLine(), out gameInput) == false)
//    {
//        //Console.WriteLine("Incorrect input type.. You died!");
//        Console.Clear();
//        continue;
//    }
//    else
//    {
//        if (gameInput == 1)
//        {
//            Console.WriteLine("You moved Forward!");
//        }
//        else if (gameInput == 2)
//        {
//            Console.WriteLine("You moved Left!");
//        }
//        else if (gameInput == 3)
//        {
//            Console.WriteLine("You moved Right!");
//        }

//        if (rand.Next(1, 10) < 4)
//        {
//            Console.WriteLine("You died! Your journey ends!");
//            break;
//        }
//        else
//        {
//            Console.WriteLine("\nYou avoided death, your journey continues..");
//            Console.ReadKey();
//            Console.Clear();
//            continue;
//        }
//    }
//}
#endregion

#region List
//List<int> intList = new List<int>() { 1, 2, 3, 4, 5 };
//List<float> floatList = new List<float>() { 1.1f, 2.2f, 3.3f };
//List<string> stringList = new List<string>() { "Name1", "Name2", "Name3" };

//intList.Add(6);
//intList.Add(7);

//intList = [.. intList, 8, 9];

//intList.Remove(5); // Removes 5
//intList.RemoveAt(5); // Removes Index 5
//intList.RemoveRange(2, 3); // Removes starting index 2, remove 4
//// Projection List: 1, 2, 8, 9

//foreach (int i in intList[1..intList.Count]) // Goes through list starting index 1 to end
//{
//    Console.WriteLine(i);
//}
#endregion

#region Exercise 3
//float ReturnAvgGrade(List<int> list)
//{
//    int sum = 0;

//    foreach (int grade in list)
//    {
//        sum += grade;
//    }

//    return (float)sum / (float)list.Count;
//}

//// 1
//List<int> grades = new List<int> { 60, 70, 50, 40, 100, 90 };

//Console.WriteLine(ReturnAvgGrade(grades));

//// 2
//grades = [.. grades, 95, 85, 75, 40];
//grades.RemoveAt(0);

//Console.WriteLine(ReturnAvgGrade(grades));

//// 3
//int lowestNum = grades[0];

//foreach (int grade in grades[1..grades.Count])
//{
//    if (grade < lowestNum)
//    {
//        lowestNum = grade;
//    }
//}

//grades.Remove(lowestNum);
////grades.RemoveAll(lowestNum);

//Console.WriteLine(ReturnAvgGrade(grades));

//// 4
//string stringInput = "";
//List<string> stringList = new List<string>();

//while (stringInput != "done")
//{
//    Console.Write("Input name: ");
//    stringInput = Console.ReadLine();

//    if (stringInput != "done")
//    {
//        stringList.Add(stringInput);
//    }
//}
#endregion

#region Functions
//int a = 10;
//int b = 20;
//List<int> c = new List<int>() { 1, 2, 3 };


//NotModified(a, b);
//Modified(ref a, ref b);
//NotModified(a, b);
//ModifyList(c);

//void NotModified(int num1, int num2)
//{
//    num1 += 30;
//    num2 -= 30;

//    Console.WriteLine(num1);
//    Console.WriteLine(num2);
//}

//void Modified(ref int num1, ref int num2)
//{
//    num1 += 30;
//    num2 -= 30;

//    Console.WriteLine(num1);
//    Console.WriteLine(num2);
//}

//void ModifyList(List<int> list)
//{
//    list[1] = 0;

//    foreach (int i in list)
//    {
//        Console.Write($"{i} ");
//    }
//}
#endregion

#region Exercise 4
//// 1
//List<int> toAdd = new List<int>() { 1, 2, 3, 4, 5 };

//Add100(toAdd);

//void Add100(List<int> list)
//{
//    for (int i = 0; i < list.Count; i++)
//    {
//        list[i] += 100;
//    }
//}
#endregion