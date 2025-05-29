namespace VGP133_Week7
{
    public class Pair<T>
    {
        public T Value1 { get; private set; }
        public T Value2 { get; private set; }

        public Pair(T v1, T v2)
        {
            Value1 = v1;
            Value2 = v2;
        }

    }
}
