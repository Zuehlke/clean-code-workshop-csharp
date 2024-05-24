using System.Text;

namespace SmellyShapes.Source;

public class Rectangle : Shape
{
    private readonly int height;

    public Rectangle(Point point, int width, int height)
    {
        X = point.X;
        Y = point.Y;
        Width = width;
        this.height = height;
    }

    public int Width { get; }

    public virtual int Height => height;

    public int X { get; }

    public int Y { get; }

    protected Color C { get; set; } = new("Blue");

    public override bool Contains(Point point)
    {
        return X <= point.X && point.X <= X + Width && Y <= point.Y && point.Y <= Y + height;
    }

    public int Calculate()
    {
        return Width * height;
    }

    public override string ToString()
    {
        return
            $"Rectangle: ({X},{Y}) width={Width} height={height} color={C.ColorAsHex}";
    }

    public override string ToXml()
    {
        var builder = new StringBuilder();

        builder.Append("<rectangle");
        builder.Append(" x=\"" + X + "\"");
        builder.Append(" y=\"" + Y + "\"");
        builder.Append(" width=\"" + Width + "\"");
        builder.Append(" height=\"" + Height + "\"");
        builder.Append(" />\n");

        return builder.ToString();
    }

    public override T Accept<T>(IShapeVisitor<T> shapeVisitor)
    {
        throw new NotImplementedException();
    }
}