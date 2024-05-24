using System.Text;

namespace SmellyShapes.Source;

public class Circle : Shape
{
    public Circle(Point center, int radius)
    {
        Center = center;
        Radius = radius;
    }

    public Point Center { get; }

    public Color Color { get; set; } = new("Green");

    public int Radius { get; }

    public override bool Contains(Point point)
    {
        var deltaX = point.X - Center.X;
        var deltaY = point.Y - Center.Y;
        var result = Square(deltaX) + Square(deltaY) <= Square(Radius);

        return result;
    }

    public int CountContainingPoints(int[] xCords, int[] yCords)
    {
        var numberOfContainingPoints = 0;
        for (var i = 0; i < xCords.Length; ++i)
        {
            var deltaX = xCords[i] - Center.X;

            var deltaY = yCords[i] - Center.Y;
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
        var centerString = Center.ToString();
        var colorString = Color.ToString();

        return "Circle: (" + centerString + ") radius= " + Radius
               + " " + colorString;
    }

    public override string ToXml()
    {
        return ToXmlStatic(this);
    }

    private static string ToXmlStatic(Circle circle)
    {
        var builder = new StringBuilder();

        builder.Append("<circle");
        builder.Append(" x=\"" + circle.Center.X + "\"");
        builder.Append(" y=\"" + circle.Center.Y + "\"");
        builder.Append(" radius=\"" + circle.Radius + "\"");
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