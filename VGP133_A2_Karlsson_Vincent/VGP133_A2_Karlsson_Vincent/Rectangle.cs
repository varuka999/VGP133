using System.ComponentModel.DataAnnotations;

namespace VGP133_A2_Karlsson_Vincent
{
    internal class Rectangle
    {
        private float _length;
        private float _width;

        public float Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Length cannot be negative!");
                }
                else
                {
                    _length = value;
                }
            }
        }
        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Width cannot be negative!");
                }
                else
                {
                    _width = value;
                }
            }
        }

        public Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }

        public float GetPerimeter()
        {
            return 2 * (_length + _width);
        }

        public float GetArea()
        {
            return (_width * _length);
        }

        public void ChangeSize(float length, float width)
        {
            Console.WriteLine($"Old Length: {Length}\nOld Width: {Width}");
            Length = length;
            Width = width;
            Console.WriteLine($"New Length: {Length}\nNew Width: {Width}\n");
        }
    }
}
