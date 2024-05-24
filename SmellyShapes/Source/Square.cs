using System.Text;

namespace SmellyShapes.Source;

public class Square : Rectangle
{
    public Square(Point point, int edgeLength)
        : base(new Point(point.X, point.Y), edgeLength, edgeLength)
    {
    }

    public Square(Point point, int edgeLength, Color color)
        : base(new Point(point.X, point.Y), edgeLength, edgeLength)
    {
        C = color;
    }

    public override int Height =>
        throw new InvalidOperationException("Square does not have a height, only edgeLength");

    public bool ContainsPoint(Point point)
    {
        return X <= point.X && point.X <= X + Width && Y <= point.Y && point.Y <= Y + Width;
    }

    public override string ToString()
    {
        return $"Square: ({X}:{Y}) edgeLength={Width} color={C.ColorAsHex}";
    }

    public bool Contains(Point a, Point b)
    {
        return Contains(a) && Contains(b);
    }

    public override string ToXml()
    {
        return ToXmlStatic();
    }

    private string ToXmlStatic()
    {
        var builder = new StringBuilder();

        builder.Append("<square");
        builder.Append(" x=\"" + X + "\"");
        builder.Append(" y=\"" + Y + "\"");
        builder.Append(" edgeLength=\"" + Width + "\"");
        builder.Append(" />\n");

        return builder.ToString();
    }

    public override T Accept<T>(IShapeVisitor<T> shapeVisitor)
    {
        return shapeVisitor.Visit(this);
    }
}