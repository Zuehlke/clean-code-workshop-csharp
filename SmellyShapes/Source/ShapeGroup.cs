using System.Text;

namespace SmellyShapes.Source;

public class ShapeGroup : Shape
{
    private static readonly int InitialArraySize = 10;
    protected bool ReadOnly;
    public Shape[] shapes = new Shape[InitialArraySize];

    public int size;

    public ShapeGroup()
    {
    }

    public ShapeGroup(Shape[] shapes, bool readOnly)
    {
        this.shapes = shapes;
        size = shapes.Length;
        ReadOnly = readOnly;
    }

    public void Add(Shape shape)
    {
        if (ReadOnly || Contains(shape)) return;

        AddToShapes(shape);
    }

    private void AddToShapes(Shape shape)
    {
        if (ShouldGrow()) GrowShapes();

        AddToShapesLocal();

        bool ShouldGrow()
        {
            return size + 1 > shapes.Length;
        }

        void GrowShapes()
        {
            var newShapes = new Shape[shapes.Length + InitialArraySize];
            for (var i = 0; i < size; i++) newShapes[i] = shapes[i];
            shapes = newShapes;
        }

        void AddToShapesLocal()
        {
            shapes[size++] = shape;
        }
    }

    public bool Contains(Shape shape)
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

    public override string ToXml()
    {
        var builder = new StringBuilder();

        var group = this;
        builder.Append("<shapegroup>\n");
        for (var i = 0; i < group.size; i++)
            builder.Append(group.shapes[i].ToXml());
        builder.Append("</shapegroup>\n");

        return builder.ToString();
    }
}