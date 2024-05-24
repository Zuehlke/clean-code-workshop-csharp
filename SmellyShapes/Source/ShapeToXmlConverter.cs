using System.Text;

namespace SmellyShapes.Source;

public class ShapeToXmlConverter : IShapeVisitor<string>
{
    private ShapeToXmlConverter()
    {
    }

    public static string Convert(Shape shape)
    {
        var converter = new ShapeToXmlConverter();
        return shape.Accept(converter);
    }

    public string Visit(Circle circle)
    {
        var builder = new StringBuilder();

        builder.Append("<circle");
        builder.Append(" x=\"" + circle.Center.X + "\"");
        builder.Append(" y=\"" + circle.Center.Y + "\"");
        builder.Append(" radius=\"" + circle.Radius + "\"");
        builder.Append(" />\n");

        return builder.ToString();
    }

    public string Visit(Rectangle rectangle)
    {
        throw new NotImplementedException();
    }
}