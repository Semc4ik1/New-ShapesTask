namespace ShapesTask.Shapes
{
    public class Rectangle : Shape
    {
        public override string Name => "Прямоугольник";
        public override double Area => _length * _width;
        public override double Perimeter => 2 * (_length + _width);
        public double DiagonalLength => Math.Sqrt(_length * _length + _width * _width);

        private double _length;
        private double _width;

        public Rectangle(double length, double width)
        {
            try
            {
               
                if (length <= 0 || width <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(length), "Длина и ширина не могут быть равны нулю или меньше.");
                }
                _length = length;
                _width = width;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                
                Console.WriteLine(ex.Message);
                
                Console.WriteLine("Неверные размеры. Пожалуйста, проверьте введенные данные.");
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nДлина диагонали: {DiagonalLength} мм" +
                   $"\nДлина: {_length} мм" +
                   $"\nШирина: {_width} мм";
        }
    }
}