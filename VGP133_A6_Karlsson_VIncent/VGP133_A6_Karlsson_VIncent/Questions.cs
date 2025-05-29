using System.Collections.Generic;

namespace VGP133_A6_Karlsson_VIncent
{
    internal class Questions
    {
        public void Question1()
        {
            GenericSwapper<int> genericSwapper1 = new GenericSwapper<int>();
            GenericSwapper<string> genericSwapper2 = new GenericSwapper<string>();

            int a = 5;
            int b = 10;

            genericSwapper1.Swap(ref a, ref b);

            string c = "Hello";
            string d = "World";

            genericSwapper2.Swap(ref c, ref d);
        }

        public void Question2()
        {
            MyQueue<int> queue1 = new MyQueue<int>();
            MyQueue<string> queue2 = new MyQueue<string>();

            queue1.Enqueue(1);
            queue1.Enqueue(2);
            queue1.Enqueue(3);
            queue1.Enqueue(4);
            queue1.PrintList();

            queue1.Dequeue();
            queue1.Remove(3); // Showcasing both functions, example confused me on what functionality it wanted
            queue1.PrintList();


            queue2.Enqueue("John");
            queue2.Enqueue("Kim");
            queue2.Enqueue("Terry");
            queue2.Enqueue("Bobby");
            queue2.PrintList();

            queue2.Dequeue();
            queue2.Remove("Terry");
            queue2.PrintList();
        }

        public void Question3()
        {
            List<int> gradesList = new List<int> { 55, 67, 43, 88, 95, 120, 45, 78, 10, 100, 89 };

            Console.Write("All Grades: ");
            for (int i = 0; i < gradesList.Count; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }

                Console.Write(gradesList[i]);
            }
            Console.WriteLine("\n");

            var passingGrades = (from grades in gradesList
                                 where grades >= 55 && grades <= 100
                                 select grades).ToList(); // Tested converting the Ienumerator to a List so I could index (could manually index in a foreach but wanted to see if there was an alternative)

            Console.Write("Passing Grades: ");
            for (int i = 0; i < passingGrades.Count(); i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }

                Console.Write(passingGrades[i]);
            }
            Console.WriteLine("\n");

            int avgPassingGrade = 0;
            foreach (int grade in passingGrades)
            {
                avgPassingGrade += grade;
            }

            avgPassingGrade /= passingGrades.Count(); // Won't round because I'm using an int

            Console.WriteLine($"Average of passing grades: {avgPassingGrade}");
        }

        public void Question4()
        {
            string input;
            List<Item> inventory = new List<Item> {new Item("Sword", "Equipment", 2), new Item("Potion", "Consumable", 5), new Item("Axe", "Equipment", 1), new Item("Knife", "Equipment", 2),
            new Item("Javelin", "Equipment", 7), new Item("Wood", "Crafting", 6), new Item("Stone", "Crafting", 4), new Item("Bow", "Equipment", 1), new Item("Feather", "Crafting", 7),
            new Item("Arrow", "Equipment", 11), new Item("Burger", "Consumable", 2), new Item("Cloth", "Crafting", 2), new Item("Sandwich", "Consumable", 5), new Item("Steak", "Consumable", 1)};

            Console.WriteLine("Items in inventory:");
            foreach (Item item in inventory)
            {
                item.PrintDetails();
            }

            Console.Write("\nFilter by item type: ");
            input = Console.ReadLine();

            var filteredInventory = from item in inventory
                                    where item.ItemType == input
                                    select item;

            Console.WriteLine("\nFiltered Items in inventory:");
            foreach (Item item in filteredInventory)
            {
                item.PrintDetails();
            }
        }

        public void Question5()
        {
            List<Player> players = new List<Player> {new Player("Bob", 50),new Player("Gen", 41),new Player("Gina", 18),new Player("Tim", 24),new Player("Harry", 31),new Player("Grimace", 5),
                new Player("Harold", 89),new Player("Kim", 55),new Player("John", 26),new Player("Barbara", 63),};

            var ageGroupedPlayers = from player in players
                                    group player by new
                                    {
                                     Group = player.Age <= 24 ? "Zoomers" :
                                             player.Age <= 39 ? "Millennials" :
                                             player.Age <= 54 ? "Gen X's" :
                                             player.Age <= 74 ? "Boomers" : "Silent Generation", // Assign Group

                                     Order = player.Age <= 24 ? 1 :
                                             player.Age <= 39 ? 2 :
                                             player.Age <= 54 ? 3 :
                                             player.Age <= 74 ? 4 : 5 // Assign Order
                                    } into ageGroup
                                    orderby ageGroup.Key.Order ascending // Not necessary, but will remind me in the future that I can use 'descending' to reverse the key/order
                                    select new { AgeGroup = ageGroup.Key, Players = ageGroup.OrderBy(player => player.Age)};

            foreach (var group in ageGroupedPlayers)
            {
                Console.WriteLine($"{group.AgeGroup.Group}:");

                foreach (var player in group.Players)
                {
                    Console.WriteLine($" {player.Name} ({player.Age})");
                }
                Console.WriteLine("");
            }
        }
    }
}
