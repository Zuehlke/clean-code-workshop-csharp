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
        static int Square(int i)
        {
            return i * i;
        }

        var deltaX = x - X;

        var deltaY = y - Y;
        var result = Square(deltaX) + Square(deltaY) <= Square(Radius);

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
            static int Square(int i1)
            {
                return i1 * i1;
            }

            var deltaX = xCords[i] - X;

            var deltaY = yCords[i] - Y;
            var result = Square(deltaX) + Square(deltaY) <= Square(Radius);

            // Increase number of Points?
            if (result)
            {
                numberOfContainingPoints++;
            }

            var temp = result;
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