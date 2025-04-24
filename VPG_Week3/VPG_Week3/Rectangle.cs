namespace VPG_Week3
{
    internal class Rectangle(int width, int height) : Shape
    {
        private string _shape = "Rectangle";
        private int _width = width;
        private int _height = height;

        public override void CalculateArea()
        {
            Console.WriteLine($"{_shape} Area: {_width * _height}");
        }
    }
}
