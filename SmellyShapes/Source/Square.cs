using System.Text;

namespace SmellyShapes.Source;

public class Square : Rectangle
{
    public Square(Point point, int edgeLength)
        : base(point.X, point.Y, edgeLength, edgeLength)
    {
    }

    public Square(int x, int y, int edgeLength, Color color)
        : base(x, y, edgeLength, edgeLength)
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

    public bool Contains(int x1, int y1, int x2, int y2)
    {
        return Contains(x1, y1) && Contains(x2, y2);
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