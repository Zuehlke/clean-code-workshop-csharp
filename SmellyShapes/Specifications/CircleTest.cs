using NUnit.Framework;
using SmellyShapes.Source;

namespace SmellyShapes.Specifications;

[TestFixture]
public class CircleTest
{
    [SetUp]
    public void SetUp()
    {
        circle = new Circle(new Point(0, 0), 1)
        {
            Color = new Color("Red"),
        };
    }

    private Circle circle;

    [Test]
    public void Contains()
    {
        Assert.That(circle.Contains(new Point(0, 0)), Is.True);
        Assert.That(circle.Contains(new Point(0, 1)), Is.True);
        Assert.That(circle.Contains(new Point(1, 0)), Is.True);

        Assert.That(circle.Contains(new Point(1, 1)), Is.False);
        Assert.That(circle.Contains(new Point(-1, -1)), Is.False);
        Assert.That(circle.Contains(new Point(1, -1)), Is.False);
        Assert.That(circle.Contains(new Point(-1, 1)), Is.False);
    }

    [Test]
    public void CountContainingPoints()
    {
        var result = circle.CountContainingPoints([0, 10], [0, 10]);
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void ToString_()
    {
        Assert.That(circle.ToString(), Is.EqualTo("Circle: (0,0) radius= 1 RGB=255,0,0"));
    }
}