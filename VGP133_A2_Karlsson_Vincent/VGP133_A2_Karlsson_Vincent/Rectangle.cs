using System.ComponentModel.DataAnnotations;

namespace VGP133_A2_Karlsson_Vincent
{
    internal class Rectangle
    {
        private float _length;
        private float _height;

        public float Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be 0 or negative!");
                }
                else
                {
                    _length = value;
                }
            }
        }
        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be 0 or negative!");
                }
                else
                {
                    _height = value;
                }
            }
        }

        public Rectangle(int length, int height)
        {
            Length = length;
            Height = height;
        }

        public float GetPerimeter()
        {
            return 2 * (_length + _height);
        }

        public float GetArea()
        {
            return (_height * _length);
        }

        public void ChangeSize(float length, float height)
        {
            Console.WriteLine($"Old Length: {Length}\nOld Height: {Height}");
            Length = length;
            Height = height;
            Console.WriteLine($"New Length: {Length}\nNew Height: {Height}\n");
        }
    }
}
