#region Q1
int num1;
int num2;
char mathOp;

Console.Write("Enter number 1: ");
num1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter number 2: ");
num2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter operator: ");
mathOp = Convert.ToChar(Console.ReadLine());

switch (mathOp)
{
    case '+':
        Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
        break;
    case '-':
        Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
        break;
    case '*':
        Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
        break;
    case '/':
        Console.WriteLine($"{num1} / {num2} = {((float)num1 / (float)num2)}");
        break;
    case '%':
        Console.WriteLine($"{num1} % {num2} = {((float)num1 % (float)num2)}");
        break;
    default:
        break;
}
#endregion

#region Q2
//List<int> grades = new List<int>();
//int gradeInput = 0;

//while (gradeInput >= 0)
//{
//    Console.Write("Enter Grade: ");
//    gradeInput = Convert.ToInt32(Console.ReadLine());

//    if (gradeInput >= 0)
//    {
//        grades.Add(gradeInput);
//    }
//}

//Console.WriteLine(CalculateFinalGrade(grades));

//float CalculateFinalGrade(List<int> grades) // Function avoids tampering with the list
//{
//    int lowestGrade = grades[0];
//    int lowestIt = 0; // Tracks how many duplicate lowest grades there are
//    int sum = 0;


//    foreach (int grade in grades)
//    {
//        if (grade < lowestGrade)
//        {
//            lowestGrade = grade;
//        }
//    }

//    foreach (int grade in grades)
//    {
//        if (grade != lowestGrade) // Duplicate lowest grades also avoided
//        {
//            sum += grade;
//        }
//        else
//        {
//            lowestIt++;
//        }
//    }

//    return (float)sum / ((float)grades.Count - lowestIt);
//}
#endregion

#region Q3
//string guestInput = "";
//List<string> guestList = new List<string>();

//while (guestInput != "done")
//{
//    Console.Write("Input Guest Name: ");
//    guestInput = Console.ReadLine();

//    if (guestInput != "done")
//    {
//        guestList.Add(guestInput);
//    }
//}

//Console.WriteLine("Guest List Before Removing: ");
//PrintGuestList(guestList);
//RemoveGuests(guestList);
//Console.WriteLine("Guest List After Removing: ");
//PrintGuestList(guestList);

//void PrintGuestList(List<string> guestList)
//{
//    foreach (string guest in guestList)
//    {
//        Console.WriteLine(guest);
//    }
//    Console.WriteLine();
//}

//void RemoveGuests(List<string> guestList)
//{
//    for (int i = 0; i < guestList.Count; i++)
//    {
//        if (guestList[i].Length > 10)
//        {
//            guestList.RemoveAt(i);
//            i--;
//        }
//    }
//}
#endregion

#region Q4
//string itemInput = "";
//List<string> itemList = new List<string>();
//int contrabandCounter = 0;

//while (itemInput != "done")
//{
//    Console.Write("Input Item: ");
//    itemInput = Console.ReadLine();

//    if (itemInput != "done")
//    {
//        itemList.Add(itemInput);
//    }
//}

//if (CheckContrabands(itemList, ref contrabandCounter) == true)
//{
//    Console.WriteLine($"Illegal items: {contrabandCounter}");
//}
//else
//{
//    Console.WriteLine("\nNo Contraband found!");
//}

//bool CheckContrabands(List<string> itemList, ref int contrabandCounter)
//{
//    List<string> contrabandList = new List<string>() { "Cigarette", "Drugs", "Gun", "Weed" };

//    Console.WriteLine("\nChecking Contraband...");
//    foreach (string item in itemList)
//    {
//        if (contrabandList.Contains(item))
//        {
//            Console.WriteLine($"Contraband found: {item}");
//            contrabandCounter++;
//        }
//    }

//    return contrabandCounter > 0 ? true : false;
//}
#endregion

#region Q5
//string ipInput = "";

//while (true)
//{
//    Console.Write("Enter IP Address: ");
//    ipInput = Console.ReadLine();

//    string[] ipSplit = ipInput.Split('.');


//    if (IsValidIPAddress(ipSplit) == false)
//    {
//        Console.WriteLine("Invalid IP Address! Please Try Again!");
//    }
//    else
//    {
//        Console.WriteLine("Valid IP Address!");
//        break;
//    }
//}

//bool IsValidIPAddress(string[] splitIP)
//{
//    if (splitIP.Length != 4)
//    {
//        return false;
//    }

//    foreach (string num in splitIP)
//    {
//        int convertedNum = 0;

//        if (Int32.TryParse(num, out convertedNum) == false)
//        {
//            return false;
//        }
//        else
//        {
//            convertedNum = Convert.ToInt32(num);

//            if (convertedNum < 0 || convertedNum > 255)
//            {
//                return false;
//            }
//        }
//    }

//    return true;
//}
#endregion
