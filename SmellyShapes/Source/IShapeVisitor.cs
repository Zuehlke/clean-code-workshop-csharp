namespace SmellyShapes.Source;

public interface IShapeVisitor<out T>
{
    T Visit(Circle circle);

    T Visit(Rectangle rectangle);
}