using NLog;

namespace ShapesTask.Shapes
{
    class ShapeParser
    {
        public static Shape Parse(string filepath)
        {
            string[] lines = File.ReadAllLines(filepath);
            string shapeType = lines[0].Trim();
            string[] parameters = lines[1].Split();

            Shape shape;
            switch (shapeType)
            {
                case "CIRCLE":
                    shape = new Circle(double.Parse(parameters[0]));
                    break;
                case "RECTANGLE":
                    double width = double.Parse(parameters[0]);
                    double length = double.Parse(parameters[1]);
                    if (width > length)
                    {
                        shape = new Rectangle(width, length);
                    }
                    else
                    {
                        shape = new Rectangle(length, width);
                    }
                    break;
                case "TRIANGLE":
                    shape = new Triangle(
                        double.Parse(parameters[0]),
                        double.Parse(parameters[1]),
                        double.Parse(parameters[2])
                    );
                    break;
                default:
                    throw new ArgumentException($"Неподдерживаемый тип фигуры: {shapeType}");
            }

            return shape;
        }
    }
}
