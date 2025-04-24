namespace VPG_Week3
{
    internal class Circle : Shape
    {
        private string _shape = "Circle";
        private float _radius;
        private float _diameter;

        public Circle(float diameter)
        {
            _diameter = diameter;
            _radius = diameter / 2;
        }

        public override void CalculateArea()
        {
            Console.WriteLine($"{_shape} Area: {Math.PI * _radius * _radius}");
        }
    }
}
