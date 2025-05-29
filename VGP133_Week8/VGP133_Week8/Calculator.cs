namespace VGP133_Week8
{
    internal class Calculator<T>
    {
        //public T Add(T a, T b)
        //{
        //    T c = a + b;
        //    return c; 
        //}

        delegate T Calculate(T a, T b);
    }
}
