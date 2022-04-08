using System.Text;

namespace SmellyShapes.Source;

public class ShapeGroup : Shape
{
    public Shape[] Shapes = new Shape[InitialArraySize];

    public int Size;

    private const int InitialArraySize = 10;

    private readonly List<Shape> shapes2 = [];

    public ShapeGroup()
    {
    }

    private ShapeGroup(Shape[] shapes, bool readOnly)
    {
        Shapes = shapes;
        shapes2 = [.. shapes];
        Size = shapes.Length;
        ReadOnly = readOnly;
    }

    protected bool ReadOnly { get; set; }

    public static ShapeGroup CreateReadOnlyShapeGroup(Shape[] shapes)
    {
        return new ShapeGroup(shapes, true);
    }

    public void Add(Shape shape)
    {
        if (ReadOnly || Contains(shape))
        {
            return;
        }

        AddToShapes(shape);
    }

    public bool Contains(Shape shape)
    {
        for (var i = 0; i < Size; i++)
        {
            if (shapes2[i].Equals(shape))
            {
                return true;
            }
        }

        return false;
    }

    public override bool Contains(int x, int y)
    {
        foreach (var shape in shapes2)
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

    public void SetReadOnly(bool readOnly)
    {
        ReadOnly = readOnly;
    }

    public override string ToXml()
    {
        var builder = new StringBuilder();

        builder.Append("<shapegroup>\n");
        for (var i = 0; i < Size; i++)
        {
            builder.Append(shapes2[i].ToXml());
        }

        builder.Append("</shapegroup>\n");

        return builder.ToString();
    }

    private void AddToShapes(Shape shape)
    {
        if (ShouldGrow())
        {
            GrowShapes();
        }

        AddToShapesLocal();

        bool ShouldGrow()
        {
            return Size + 1 > shapes2.Count;
        }

        void GrowShapes()
        {
            var newShapes = new Shape[shapes2.Count + InitialArraySize];
            for (var i = 0; i < Size; i++)
            {
                newShapes[i] = shapes2[i];
            }

            Shapes = newShapes;
        }

        void AddToShapesLocal()
        {
            Shapes[Size++] = shape;
            shapes2.Add(shape);
        }
    }
}