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
        var builder = new StringBuilder();

        builder.Append("<rectangle");
        builder.Append(" x=\"" + rectangle.X + "\"");
        builder.Append(" y=\"" + rectangle.Y + "\"");
        builder.Append(" width=\"" + rectangle.Width + "\"");
        builder.Append(" height=\"" + rectangle.Height + "\"");
        builder.Append(" />\n");

        return builder.ToString();
    }

    public string Visit(ShapeGroup shapeGroup)
    {
        var builder = new StringBuilder();

        builder.Append("<shapegroup>\n");
        for (var i = 0; i < shapeGroup.Size; i++)
        {
            builder.Append(shapeGroup.Shapes[i].ToXml());
        }

        builder.Append("</shapegroup>\n");

        return builder.ToString();
    }

    public string Visit(Square square)
    {
        var builder = new StringBuilder();

        builder.Append("<square");
        builder.Append(" x=\"" + square.X + "\"");
        builder.Append(" y=\"" + square.Y + "\"");
        builder.Append(" edgeLength=\"" + square.Width + "\"");
        builder.Append(" />\n");

        return builder.ToString();
    }

    public static string ToXmlStatic(Square square)
    {
        return Convert(square);
    }
}