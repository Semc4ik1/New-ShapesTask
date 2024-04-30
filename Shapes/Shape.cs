namespace ShapesTask.Shapes
{
    public abstract class Shape
    {
        public abstract string Name { get; }
        public abstract double Area { get; }
        public abstract double Perimeter { get; }

        public override string ToString()
        {
            return $"Тип фигуры: {Name}" +
                $"\nПлощадь: {Area} кв. мм" +
                $"\nПериметр: {Perimeter} кв. мм";
        }
       
    }
}
