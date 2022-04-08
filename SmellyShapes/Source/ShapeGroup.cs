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

    private ShapeGroup(Shape[] shapes, bool readOnly)
    {
        this.shapes = shapes;
        size = shapes.Length;
        ReadOnly = readOnly;
    }

    public static ShapeGroup CreateShapeGroup(Shape[] shapes, bool readOnly)
    {
        if (readOnly)
            return CreateReadOnlyShapeGroup(shapes);
        return CreateWritableShapeGroup(shapes);
    }

    public static ShapeGroup CreateWritableShapeGroup(Shape[] shapes)
    {
        return new ShapeGroup(shapes, false);
    }

    public static ShapeGroup CreateReadOnlyShapeGroup(Shape[] shapes)
    {
        return new ShapeGroup(shapes, true);
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

        builder.Append("<shapegroup>\n");
        for (var i = 0; i < size; i++)
            builder.Append(shapes[i].ToXml());
        builder.Append("</shapegroup>\n");

        return builder.ToString();
    }
}