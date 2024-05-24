using NUnit.Framework;
using SmellyShapes.Source;

namespace SmellyShapes.Specifications;

[TestFixture]
public class RectangleTest
{
    [SetUp]
    public void SetUp()
    {
        rectangle = new Rectangle(new Point(0, 0), 2, 1);
    }

    private Rectangle rectangle;

    [Test]
    public void Contains()
    {
        Assert.That(rectangle.Contains(new Point(0, 0)), Is.True);
        Assert.That(rectangle.Contains(new Point(1, 0)), Is.True);
        Assert.That(rectangle.Contains(new Point(1, 1)), Is.True);
        Assert.That(rectangle.Contains(new Point(2, 1)), Is.True);

        Assert.That(rectangle.Contains(new Point(2, 2)), Is.False);
        Assert.That(rectangle.Contains(new Point(-1, 0)), Is.False);
        Assert.That(rectangle.Contains(new Point(0, -1)), Is.False);
    }

    [Test]
    public void CalculateArea()
    {
        Assert.That(rectangle.Calculate(), Is.EqualTo(2));
    }

    [Test]
    public void ToXml()
    {
        var xml = ShapeToXmlConverter.Convert(rectangle);

        Assert.That(xml, Is.EqualTo("<rectangle x=\"0\" y=\"0\" width=\"2\" height=\"1\" />\n"));
    }

    [Test]
    public void RectangleToString()
    {
        var xml = rectangle.ToString();
        Assert.That(xml, Is.EqualTo("Rectangle: (0,0) width=2 height=1 color=#00FF00"));
    }
}