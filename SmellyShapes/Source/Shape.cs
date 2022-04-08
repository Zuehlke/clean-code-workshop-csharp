namespace SmellyShapes.Source;

public abstract class Shape
{
    public abstract bool Contains(Point point);

    public abstract string ToXml();
}