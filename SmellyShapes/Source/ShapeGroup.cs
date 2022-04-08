using System.Text;

namespace SmellyShapes.Source;

public class ShapeGroup : Shape
{
    private readonly List<Shape> shapes2 = [];

    public ShapeGroup()
    {
    }

    private ShapeGroup(Shape[] shapes, bool readOnly)
    {
        shapes2 = [.. shapes];
        ReadOnly = readOnly;
    }

    public int Size2 => shapes2.Count;

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
        for (var i = 0; i < Size2; i++)
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
        for (var i = 0; i < Size2; i++)
        {
            builder.Append(shapes2[i].ToXml());
        }

        builder.Append("</shapegroup>\n");

        return builder.ToString();
    }

    private void AddToShapes(Shape shape)
    {
        shapes2.Add(shape);
    }
}