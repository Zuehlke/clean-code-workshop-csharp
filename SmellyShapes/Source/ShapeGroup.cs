using System.Text;

namespace SmellyShapes.Source;

public class ShapeGroup : Shape
{
    public Shape[] Shapes = new Shape[InitialArraySize];

    public int Size;

    private const int InitialArraySize = 10;

    public ShapeGroup()
    {
    }

    public ShapeGroup(Shape[] shapes, bool readOnly)
    {
        Shapes = shapes;
        Size = shapes.Length;
        ReadOnly = readOnly;
    }

    protected bool ReadOnly { get; set; }

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

    public void SetReadOnly(bool readOnly)
    {
        ReadOnly = readOnly;
    }

    public override string ToXml()
    {
        var builder = new StringBuilder();

        if (this is ShapeGroup group)
        {
            builder.Append("<shapegroup>\n");
            for (var i = 0; i < group.Size; i++)
            {
                builder.Append(group.Shapes[i].ToXml());
            }

            builder.Append("</shapegroup>\n");
        }

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
            return Size + 1 > Shapes.Length;
        }

        void GrowShapes()
        {
            var newShapes = new Shape[Shapes.Length + InitialArraySize];
            for (var i = 0; i < Size; i++)
            {
                newShapes[i] = Shapes[i];
            }

            Shapes = newShapes;
        }

        void AddToShapesLocal()
        {
            Shapes[Size++] = shape;
        }
    }
}