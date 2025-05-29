using System.Xml.Linq;

namespace VGP133_Week7
{
    public class GenericStack<T, T2>
    {
        public List<T> genericList = new List<T>();
        public List<T2> genericList2 = new List<T2>();

        public void Add(T item)
        {
            genericList.Add(item);
        }
        public void Add(T2 item)
        {
            genericList2.Add(item);
        }

        public List<T> GetList()
        {
            return genericList;
        }

        public void PrintT()
        {
            foreach (T element in genericList)
            {
                Console.WriteLine(element);
            }
        }
        public void PrintT2()
        {
            foreach (T2 element in genericList2)
            {
                Console.WriteLine(element);
            }
        }

        public void PrintNumber(T num)
        {
            if (num.GetType() == typeof(int) || num.GetType() == typeof(float))
            {
                Console.WriteLine(num);
            }
        }
    }
}
