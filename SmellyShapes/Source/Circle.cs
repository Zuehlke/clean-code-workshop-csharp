namespace SmellyShapes.Source;

public class Circle : SimpleShape
{
    private int numberOfContainingPoints;

    public Circle(int x, int y, int radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    public Color Color { get; set; } = new("Green");

    public int X { get; }

    public int Y { get; }

    public int Radius { get; }

    public override bool Contains(int x, int y)
    {
        var deltaX = x - X;
        var result = (deltaX * deltaX) + ((y - Y) * (y - Y)) <= Radius * Radius;

        // Increase number of Points?
        if (result)
        {
            numberOfContainingPoints++;
        }

        return result;
    }

    public int CountContainingPoints(int[] xCords, int[] yCords)
    {
        numberOfContainingPoints = 0;
        for (var i = 0; i < xCords.Length; ++i)
        {
            Contains(xCords[i], yCords[i]);
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
}