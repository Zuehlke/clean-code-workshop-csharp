namespace SmellyShapes.Source;

public abstract class Shape
{
    public abstract bool Contains(Point point);

    public virtual string ToXml()
    {
        return ShapeToXmlConverter.Convert(this);
    }

    public abstract T Accept<T>(IShapeVisitor<T> shapeVisitor);
}