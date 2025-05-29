namespace VGP133_A6_Karlsson_VIncent
{
    internal class MyQueue<T>
    {
        List<T> list = new List<T>();

        public void Enqueue(T item)
        {
            Console.WriteLine($"Adding Item To Queue ({item})");
            list.Add(item);
        }

        public void Dequeue()
        {
            if (list.Count > 0)
            {
                Console.WriteLine("Removing First Item From Queue");
                list.RemoveAt(0);
                // Question said to 'remove the item at the start of the list', but I was confused because the example shows effectively a .Remove, which doesnt remove the item at front.
                // I made a second function that does the .Remove, as I'm not sure which is correct.
            }
        }

        public void Remove(T item)
        {
            if (list.Count > 0)
            {
                Console.WriteLine($"Removing Item From Queue ({item})");
                list.Remove(item);
            }
        }

        public void PrintList()
        {
            Console.Write("In List: ");

            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }

                Console.Write(list[i]);
            }

            Console.WriteLine("\n");
        }
    }
}
