namespace SmellyShapes.Source;

public abstract class Shape
{
    public abstract bool Contains(int x, int y);

    public abstract string ToXml();
}