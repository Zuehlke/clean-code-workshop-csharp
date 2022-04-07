namespace SmellyShapes.Source;

public class ShapeGroup : ComplexShape
{
    public IShape[] Shapes = new IShape[InitialArraySize];

    public int Size;

    private const int InitialArraySize = 10;

    public ShapeGroup()
    {
    }

    public ShapeGroup(IShape[] shapes, bool readOnly)
    {
        Shapes = shapes;
        Size = shapes.Length;
        ReadOnly = readOnly;
    }

    public void Add(IShape shape)
    {
        if (ReadOnly || Contains(shape))
        {
            return;
        }

        var newSize = Size + 1;
        if (newSize > Shapes.Length)
        {
            var newShapes = new IShape[Shapes.Length + InitialArraySize];
            for (var i = 0; i < Size; i++)
            {
                newShapes[i] = Shapes[i];
            }

            Shapes = newShapes;
        }

        Shapes[Size++] = shape;
    }

    public bool Contains(IShape shape)
    {
        for (var i = 0; i < Size; i++)
        {
            if (Shapes[i].Equals(shape))
            {
                return true;
            }
        }

        return false;
    }

    public override bool Contains(int x, int y)
    {
        foreach (var shape in Shapes)
        {
            if (shape != null)
            {
                if (shape.Contains(x, y))
                {
                    return true;
                }
            }
        }

        return false;
    }
}