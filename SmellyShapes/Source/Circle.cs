using System.Text;

namespace SmellyShapes.Source;

public class Circle : Shape
{
    public Circle(Point point, int radius)
    {
        X = point.X;
        Y = point.Y;
        Radius = radius;
    }

    public Color Color { get; set; } = new("Green");

    public int X { get; }

    public int Y { get; }

    public int Radius { get; }

    public override bool Contains(Point point)
    {
        var deltaX = point.X - X;
        var deltaY = point.Y - Y;
        var result = Square(deltaX) + Square(deltaY) <= Square(Radius);

        return result;
    }

    public int CountContainingPoints(int[] xCords, int[] yCords)
    {
        var numberOfContainingPoints = 0;
        for (var i = 0; i < xCords.Length; ++i)
        {
            var deltaX = xCords[i] - X;

            var deltaY = yCords[i] - Y;
            var result = Square(deltaX) + Square(deltaY) <= Square(Radius);

            // Increase number of Points?
            if (result)
            {
                numberOfContainingPoints++;
            }
        }

        return numberOfContainingPoints;
    }

    public override string ToString()
    {
        return "Circle: (" + X + "," + Y + ") radius= " + Radius
               + " RGB=" + Color.ColorAsRgbRed + ","
               + Color.ColorAsRgbGreen + ","
               + Color.ColorAsRgbBlue;
    }

    public override string ToXml()
    {
        var builder = new StringBuilder();

        builder.Append("<circle");
        builder.Append(" x=\"" + X + "\"");
        builder.Append(" y=\"" + Y + "\"");
        builder.Append(" radius=\"" + Radius + "\"");
        builder.Append(" />\n");

        return builder.ToString();
    }

    private static int Square(int i)
    {
        return i * i;
    }
}