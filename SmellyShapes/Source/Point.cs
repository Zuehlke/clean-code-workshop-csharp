namespace SmellyShapes.Source;

public class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }

    public int Y { get; }

    public string CenterString()
    {
        return X + "," + Y;
    }
}