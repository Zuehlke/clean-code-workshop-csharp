using System.Text;

namespace SmellyShapes.Source;

public class Rectangle : Shape
{
    private readonly int height;
    protected Color c = new("Blue");

    public Rectangle(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        this.height = height;
    }

    public int Width { get; }

    public virtual int Height => height;

    public int X { get; }

    public int Y { get; }

    public override bool Contains(int x, int y)
    {
        return X <= x && x <= X + Width && Y <= y && y <= Y + height;
    }

    public int Calculate()
    {
        return Width * height;
    }

    public override string ToString()
    {
        return
            $"Rectangle: ({X},{Y}) width={Width} height={height} color={c.GetColorAsHex()}";
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
}