using System.Text;

namespace SmellyShapes.Source;

public class Circle : Shape
{
    private readonly Point center;

    public Circle(Point center, int radius)
    {
        this.center = center;
        Radius = radius;
    }

    public Color Color { get; set; } = new("Green");

    public int Radius { get; }

    public override bool Contains(Point point)
    {
        var deltaX = point.X - center.X;
        var deltaY = point.Y - center.Y;
        var result = Square(deltaX) + Square(deltaY) <= Square(Radius);

        return result;
    }

    public int CountContainingPoints(int[] xCords, int[] yCords)
    {
        var numberOfContainingPoints = 0;
        for (var i = 0; i < xCords.Length; ++i)
        {
            var deltaX = xCords[i] - center.X;

            var deltaY = yCords[i] - center.Y;
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
        var centerString = center.ToString();
        var colorString = Color.ToString();

        return "Circle: (" + centerString + ") radius= " + Radius
               + " " + colorString;
    }

    public override string ToXml()
    {
        var builder = new StringBuilder();

        builder.Append("<circle");
        builder.Append(" x=\"" + center.X + "\"");
        builder.Append(" y=\"" + center.Y + "\"");
        builder.Append(" radius=\"" + Radius + "\"");
        builder.Append(" />\n");

        return builder.ToString();
    }

    public override T Accept<T>(IShapeVisitor<T> shapeVisitor)
    {
        return shapeVisitor.Visit(this);
    }

    private static int Square(int i)
    {
        return i * i;
    }
}