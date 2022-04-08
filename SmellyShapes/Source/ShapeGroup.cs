using System.Text;

namespace SmellyShapes.Source;

public class ShapeGroup : Shape
{
    public int Size;

    private readonly List<Shape> shapes2 = [];

    public ShapeGroup()
    {
    }

    private ShapeGroup(Shape[] shapes, bool readOnly)
    {
        shapes2 = [.. shapes];
        SetSizeOld(shapes.Length);
        ReadOnly = readOnly;
    }

    public int Size2 => shapes2.Count;

    protected bool ReadOnly { get; set; }

    public static ShapeGroup CreateReadOnlyShapeGroup(Shape[] shapes)
    {
        return new ShapeGroup(shapes, true);
    }

    public void SetSizeOld(int value)
    {
        Size = value;
    }

    public int GetSizeOld()
    {
        return Size2;
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
        for (var i = 0; i < GetSizeOld(); i++)
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
        for (var i = 0; i < GetSizeOld(); i++)
        {
            builder.Append(shapes2[i].ToXml());
        }

        builder.Append("</shapegroup>\n");

        return builder.ToString();
    }

    private void AddToShapes(Shape shape)
    {
        SetSizeOld(GetSizeOld() + 1);
        shapes2.Add(shape);
    }
}