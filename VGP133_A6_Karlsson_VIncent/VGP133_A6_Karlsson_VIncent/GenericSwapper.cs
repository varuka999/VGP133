namespace VGP133_A6_Karlsson_VIncent
{
    internal class GenericSwapper<T>
    {
        public void Swap(ref T ref1, ref T ref2)
        {
            Console.WriteLine($"Before Swapping:\nvar1 ({ref1})\nvar2 ({ref2})");
            
            Console.WriteLine("\nSwapping!\n");
            
            T temp = ref1;
            ref1 = ref2;
            ref2 = temp;
            
            Console.WriteLine($"After Swapping:\nvar1 ({ref1})\nvar2 ({ref2})\n");
        }
    }
}
