using System.Xml.Serialization;

namespace VGP133_A5_Karlsson_Vincent
{
    internal class Questions
    {
        public void Question1()
        {
            string file = "Names.txt";
            List<string> fileNames = new List<string>();
            List<string> newNames = new List<string>();

            try
            {
                if (File.Exists(file))
                {
                    fileNames.AddRange(File.ReadAllLines(file));
                    Console.WriteLine("Names in File:");

                    foreach (string name in fileNames)
                    {
                        Console.WriteLine(name);
                    }

                    Console.WriteLine("Enter new names to replace:");
                    while (File.Exists(file))
                    {
                        string nameInput = string.Empty;

                        nameInput = Console.ReadLine();

                        if (nameInput != string.Empty && nameInput != null)
                        {
                            if (nameInput.ToLower() == "done")
                            {
                                File.WriteAllLines(file, newNames);
                                break;
                            }

                            newNames.Add(nameInput);
                        }
                    }
                }
                else
                {
                    File.OpenWrite(file);
                    throw new FileNotFoundException("No file, creating new one!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!");
            }
        }
        public void Question2()
        {
            string fileName = "Employees.txt";

            try
            {
                if (File.Exists(fileName))
                {
                    List<Employee> employees = new List<Employee>();

                    FileInfo file = new FileInfo(fileName);
                    file.IsReadOnly = true;

                    string[] fileInfo = File.ReadAllLines(fileName);

                    for (int i = 0; i < fileInfo.Length; i += 4)
                    {
                        string name = fileInfo[i];
                        int age = int.Parse(fileInfo[i + 1]);
                        float salary = float.Parse(fileInfo[i + 2]);
                        string email = fileInfo[i + 3];

                        Employee newEmployee = new Employee(name, age, salary, email);
                        employees.Add(newEmployee);
                    }

                    foreach (Employee employee in employees)
                    {
                        employee.PrintInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!");
            }
        }
        public void Question3()
        {
            List<Weapon> weapons = new List<Weapon>();
            string xmlFile = "Weapons.xml";
            int weaponCount = 0;
            int input = 2;

            Console.Write("How many weapons to create: ");
            while (!int.TryParse(Console.ReadLine(), out weaponCount) || weaponCount <= 0)
            {
                Console.Write("Invalid input!");
            }

            for (int i = 0; i < weaponCount; i++)
            {
                Console.Write("Weapon Name: ");
                string name = Console.ReadLine();

                Console.Write("Attack Power: ");
                int atk = 0;
                while (!int.TryParse(Console.ReadLine(), out atk))
                {
                    Console.Write("Invalid input!");
                }

                Console.Write("Strength Requirement: ");
                int strReq = 0;
                while (!int.TryParse(Console.ReadLine(), out strReq))
                {
                    Console.Write("Invalid input!");
                }

                Console.Write("Owner Name: ");
                string owner = Console.ReadLine();

                Weapon weapon = new Weapon(name, atk, strReq, owner);
                weapons.Add(weapon);
            }

            foreach (var weapon in weapons)
            {
                weapon.PrintInfo();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Weapon>));
                using (StreamWriter writer = new StreamWriter(xmlFile))
                {
                    serializer.Serialize(writer, weapons);
                }

                Console.WriteLine($"\nWeapons saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!");
            }
        }

        public void Question4()
        {
            List<Weapon> weapons = new List<Weapon>();
            string xmlFile = "Weapons.xml";

            if (File.Exists(xmlFile))
            {
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Weapon>));
                    using (StreamReader reader = new StreamReader(xmlFile))
                    {
                        weapons = (List<Weapon>)deserializer.Deserialize(reader);
                    }

                    Console.WriteLine("Weapons from xml:");
                    foreach (var weapon in weapons)
                    {
                        weapon.PrintInfo();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error!");
                }
            }

        }
    }
}

