namespace ShapesTask.Shapes
{
    public class Triangle : Shape
    {
        public override string Name => "Треугольник";
        public override double Area
        {
            get
            {
                double p = Perimeter / 2;
                return Math.Sqrt(p * (p - _side1) * (p - _side2) * (p - _side3));
            }
        }

        public override double Perimeter => _side1 + _side2 + _side3;

        private double _side1;
        private double _side2;
        private double _side3;
        private double _angle1;
        private double _angle2;
        private double _angle3;

        public Triangle(double side1, double side2, double side3)
        {
            try
            {
                
                if (_side1 <= 0 || _side2 <= 0 || _side3 <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(side1), "Все стороны треугольника должны быть больше нуля.");
                }
                
                if ((_side1 + _side2 <= _side3) || (_side1 + _side3 <= _side2) || (_side2 + _side3 <= _side1))
                {
                    throw new ArgumentOutOfRangeException(nameof(side1), "Длины сторон не могут образовать треугольник.");
                }
                _side1 = side1;
                _side2 = side2;
                _side3 = side3;
                CalculateAngles();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                
                Console.WriteLine(ex.Message);
                
                Console.WriteLine("Неверные значения сторон. Пожалуйста, проверьте введенные данные.");
            }
        }

        private void CalculateAngles()
        {
            _angle1 = Math.Acos((_side2 * _side2 + _side3 * _side3 - _side1 * _side1) / (2 * _side2 * _side3)) * (180 / Math.PI);
            _angle2 = Math.Acos((_side1 * _side1 + _side3 * _side3 - _side2 * _side2) / (2 * _side1 * _side3)) * (180 / Math.PI);
            _angle3 = 180 - _angle1 - _angle2;
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\nДлина стороны 1: {_side1} мм, Противолежащий угол: {_angle1}°" +
                $"\nДлина стороны 2: {_side2} мм, Противолежащий угол: {_angle2}°" +
                $"\nДлина стороны 3: {_side3} мм, Противолежащий угол: {_angle3}°";
        }
    }
}