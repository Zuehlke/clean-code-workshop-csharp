using NUnit.Framework;
using SmellyShapes.Source;

namespace SmellyShapes.Specifications;

[TestFixture]
public class ShapeToXmlConverterTest
{
    [Test]
    public void Convert_WithCircle()
    {
        var circle = new Circle(new Point(0, 0), 1)
        {
            Color = new Color("Red"),
        };

        var xml = ShapeToXmlConverter.Convert(circle);
        Assert.That(xml, Is.EqualTo("<circle x=\"0\" y=\"0\" radius=\"1\" />\n"));
    }

    [Test]
    public void Convert_WithRectangle()
    {
        var rectangle = new Rectangle(new Point(0, 0), 2, 1);

        var xml = ShapeToXmlConverter.Convert(rectangle);

        Assert.That(xml, Is.EqualTo("<rectangle x=\"0\" y=\"0\" width=\"2\" height=\"1\" />\n"));
    }

    [Test]
    public void Convert_WithShapeGroup()
    {
        var shapeGroup = new ShapeGroup();
        shapeGroup.Add(new Rectangle(new Point(0, 0), 2, 1));

        var xml = ShapeToXmlConverter.Convert(shapeGroup);

        Assert.That(
            xml,
            Is.EqualTo(
                "<shapegroup>\n<rectangle x=\"0\" y=\"0\" width=\"2\" height=\"1\" />\n</shapegroup>\n"));
    }

    [Test]
    public void Convert_WithSquare()
    {
        var square = new Square(new Point(0, 1), 2);
        var xml = ShapeToXmlConverter.Convert(square);
        Assert.That(xml, Is.EqualTo("<square x=\"0\" y=\"1\" edgeLength=\"2\" />\n"));
    }
}