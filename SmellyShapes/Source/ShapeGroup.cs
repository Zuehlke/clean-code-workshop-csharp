namespace SmellyShapes.Source;

public class ShapeGroup : ComplexShape
{
    private static readonly int InitialArraySize = 10;
    public IShape[] shapes = new IShape[InitialArraySize];

    public int size;

    public ShapeGroup()
    {
    }

    public ShapeGroup(IShape[] shapes, bool readOnly)
    {
        this.shapes = shapes;
        size = shapes.Length;
        ReadOnly = readOnly;
    }

    public void Add(IShape shape)
    {
        if (ReadOnly || Contains(shape)) return;

        AddToShapes(shape);
    }

    private void AddToShapes(IShape shape)
    {
        if (size + 1 > shapes.Length)
        {
            var newShapes = new IShape[shapes.Length + InitialArraySize];
            for (var i = 0; i < size; i++) newShapes[i] = shapes[i];
            shapes = newShapes;
        }

        shapes[size++] = shape;
    }

    public bool Contains(IShape shape)
    {
        for (var i = 0; i < size; i++)
            if (shapes[i].Equals(shape))
                return true;
        return false;
    }

    public override bool Contains(int x, int y)
    {
        foreach (var shape in shapes)
            if (shape != null)
                if (shape.Contains(x, y))
                    return true;
        return false;
    }
}