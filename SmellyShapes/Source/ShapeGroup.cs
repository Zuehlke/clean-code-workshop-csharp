using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmellyShapes.Source;

public class ShapeGroup : Shape
{
    private static readonly int InitialArraySize = 10;
    private readonly List<Shape> shapes2 = new();
    protected bool ReadOnly;

    public int size;

    public ShapeGroup()
    {
    }

    private ShapeGroup(Shape[] shapes, bool readOnly)
    {
        shapes2 = shapes.ToList();
        size = shapes.Length;
        ReadOnly = readOnly;
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
            return size + 1 > shapes2.Count;
        }

        void GrowShapes()
        {
            var newShapes = new Shape[shapes2.Count + InitialArraySize];
            for (var i = 0; i < size; i++) newShapes[i] = shapes2[i];
        }

        void AddToShapesLocal()
        {
            size++;
            shapes2.Add(shape);
        }
    }

    public bool Contains(Shape shape)
    {
        for (var i = 0; i < size; i++)
            if (shapes2[i].Equals(shape))
                return true;
        return false;
    }

    public override bool Contains(int x, int y)
    {
        foreach (var shape in shapes2)
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
            builder.Append(shapes2[i].ToXml());
        builder.Append("</shapegroup>\n");

        return builder.ToString();
    }
}