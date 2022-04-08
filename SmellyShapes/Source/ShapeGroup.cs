using System.Text;

namespace SmellyShapes.Source;

public class ShapeGroup : Shape
{
    private readonly List<Shape> shapes = [];

    public ShapeGroup()
    {
    }

    private ShapeGroup(Shape[] shapes, bool readOnly)
    {
        this.shapes = [.. shapes];
        ReadOnly = readOnly;
    }

    public int Size => shapes.Count;

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
            if (shapes[i].Equals(shape))
            {
                return true;
            }
        }

        return false;
    }

    public override bool Contains(Point point)
    {
        foreach (var shape in shapes)
        {
            if (shape != null)
            {
                if (shape.Contains(point))
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
            builder.Append(shapes[i].ToXml());
        }

        builder.Append("</shapegroup>\n");

        return builder.ToString();
    }

    private void AddToShapes(Shape shape)
    {
        shapes.Add(shape);
    }
}