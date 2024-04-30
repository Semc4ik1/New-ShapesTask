namespace ShapesTask.Shapes
{
    public class Circle : Shape
    {
        public override string Name => "Круг";
        public override double Area => Math.PI * _radius * _radius;
        public override double Perimeter => 2 * Math.PI * _radius;

        private double _radius;

        public Circle(double radius)
        {
            try
            {
               
                if (radius < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(radius), "Радиус не может быть отрицательным.");
                }
                _radius = radius;
            }
            catch (ArgumentOutOfRangeException ex)
            {              
                Console.WriteLine(ex.Message);
                Console.WriteLine("Неверный радиус. Пожалуйста, проверьте введенные данные.");
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nРадиус: {_radius} мм" +
                   $"\nДиаметр: {2 * _radius} мм";
        }
    }
}
