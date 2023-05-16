namespace SmellyShapes.Source;

public class Rectangle : SimpleShape
{
    private readonly int height;

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

    protected Color C { get; set; } = new("Blue");

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
            $"Rectangle: ({X},{Y}) width={Width} height={height} color={C.ColorAsHex}";
    }
}