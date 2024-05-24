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

    public IReadOnlyList<Shape> Shapes => shapes;

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
        return ToXmlStatic(this);
    }

    private static string ToXmlStatic(ShapeGroup shapeGroup)
    {
        var builder = new StringBuilder();

        builder.Append("<shapegroup>\n");
        for (var i = 0; i < shapeGroup.Size; i++)
        {
            builder.Append(shapeGroup.shapes[i].ToXml());
        }

        builder.Append("</shapegroup>\n");

        return builder.ToString();
    }

    public override T Accept<T>(IShapeVisitor<T> shapeVisitor)
    {
        return shapeVisitor.Visit(this);
    }

    private void AddToShapes(Shape shape)
    {
        shapes.Add(shape);
    }
}