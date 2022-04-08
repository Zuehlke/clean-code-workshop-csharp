using System.Text;

namespace SmellyShapes.Source;

public class Square : Rectangle
{
    public Square(Point point, int edgeLength)
        : base(point.X, point.Y, edgeLength, edgeLength)
    {
    }

    public Square(Point point, int edgeLength, Color color)
        : base(point.X, point.Y, edgeLength, edgeLength)
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
        return Contains(a.X, a.Y) && Contains(b.X, b.Y);
    }

    public override string ToXml()
    {
        var builder = new StringBuilder();

        builder.Append("<square");
        builder.Append(" x=\"" + X + "\"");
        builder.Append(" y=\"" + Y + "\"");
        builder.Append(" edgeLength=\"" + Width + "\"");
        builder.Append(" />\n");

        return builder.ToString();
    }
}