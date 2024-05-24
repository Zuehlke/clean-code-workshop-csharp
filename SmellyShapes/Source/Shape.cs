namespace SmellyShapes.Source;

public abstract class Shape
{
    public abstract bool Contains(Point point);

    public abstract T Accept<T>(IShapeVisitor<T> shapeVisitor);
}