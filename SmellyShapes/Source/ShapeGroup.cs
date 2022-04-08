namespace SmellyShapes.Source;

public class ShapeGroup : AbstractShape
{
    private static readonly int InitialArraySize = 10;
    protected bool ReadOnly;
    public AbstractShape[] shapes = new AbstractShape[InitialArraySize];

    public int size;

    public ShapeGroup()
    {
    }

    public ShapeGroup(AbstractShape[] shapes, bool readOnly)
    {
        this.shapes = shapes;
        size = shapes.Length;
        ReadOnly = readOnly;
    }

    public void Add(AbstractShape shape)
    {
        if (ReadOnly || Contains(shape)) return;

        AddToShapes(shape);
    }

    private void AddToShapes(AbstractShape shape)
    {
        if (ShouldGrow()) GrowShapes();

        AddToShapesLocal();

        bool ShouldGrow()
        {
            return size + 1 > shapes.Length;
        }

        void GrowShapes()
        {
            var newShapes = new AbstractShape[shapes.Length + InitialArraySize];
            for (var i = 0; i < size; i++) newShapes[i] = shapes[i];
            shapes = newShapes;
        }

        void AddToShapesLocal()
        {
            shapes[size++] = shape;
        }
    }

    public bool Contains(AbstractShape shape)
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

    public void SetReadOnly(bool readOnly)
    {
        ReadOnly = readOnly;
    }
}