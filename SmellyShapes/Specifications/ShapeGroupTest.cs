using NUnit.Framework;
using SmellyShapes.Source;

namespace SmellyShapes.Specifications;

[TestFixture]
public class ShapeGroupTest
{
    [Test]
    public void ToXml()
    {
        var shapeGroup = new ShapeGroup();
        shapeGroup.Add(new Rectangle(0, 0, 2, 1));

        var xml = shapeGroup.ToXml();

        Assert.That(
            xml,
            Is.EqualTo(
                "<shapegroup>\n<rectangle x=\"0\" y=\"0\" width=\"2\" height=\"1\" />\n</shapegroup>\n"));
    }

    [Test]
    public void Constructor_WithShapeArray()
    {
        Shape[] shapes = [new Circle(0, 0, 0)];
        var shapeGroup =
            true ? ShapeGroup.CreateReadOnlyShapeGroup(shapes) : ShapeGroup.CreateWritableShapeGroup(shapes);

        Assert.That(shapeGroup.Size, Is.EqualTo(1));
    }

    [Test]
    public void Add_WithReadOnly()
    {
        var shapeGroup = new ShapeGroup();
        shapeGroup.SetReadOnly(true);

        shapeGroup.Add(new Circle(0, 0, 0));

        Assert.That(shapeGroup.Size, Is.EqualTo(0));
    }

    [Test]
    public void Add_WithoutReadOnly()
    {
        var shapeGroup = new ShapeGroup();
        shapeGroup.SetReadOnly(false);

        shapeGroup.Add(new Circle(0, 0, 0));

        Assert.That(shapeGroup.Size, Is.EqualTo(1));
    }

    [Test]
    public void Add_SameElementTwice()
    {
        var shapeGroup = new ShapeGroup();
        shapeGroup.SetReadOnly(false);

        var circle = new Circle(0, 0, 0);
        shapeGroup.Add(circle);
        shapeGroup.Add(circle);

        Assert.That(shapeGroup.Size, Is.EqualTo(1));
    }

    [Test]
    public void Add_InternalArraySizeExceeded()
    {
        var shapeGroup = new ShapeGroup();
        shapeGroup.SetReadOnly(false);

        for (var i = 0; i < 11; i++)
        {
            shapeGroup.Add(new Circle(0, 0, 0));
        }

        Assert.That(shapeGroup.Size, Is.EqualTo(11));
    }

    [Test]
    public void Contains_PointNotInGroup()
    {
        var shapeGroup = new ShapeGroup();

        Assert.That(shapeGroup.Contains(0, 0), Is.False);
    }

    [Test]
    public void Contains_PointInGroup()
    {
        var shapeGroup = new ShapeGroup();
        shapeGroup.Add(new Circle(0, 0, 0));

        Assert.That(shapeGroup.Contains(0, 0), Is.True);
    }

    [Test]
    public void Contains_Null()
    {
        var shapeGroup = new ShapeGroup();

        Assert.That(shapeGroup.Contains(null), Is.False);
    }

    [Test]
    public void Contains_ShapeInGroup()
    {
        var shapeGroup = new ShapeGroup();
        var c = new Circle(0, 0, 0);
        shapeGroup.Add(c);

        Assert.That(shapeGroup.Contains(c), Is.True);
    }
}