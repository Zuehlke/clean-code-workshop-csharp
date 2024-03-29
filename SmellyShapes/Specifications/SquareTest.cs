using System;
using NUnit.Framework;
using SmellyShapes.Source;

namespace SmellyShapes.Specifications;

[TestFixture]
public class SquareTest
{
    [Test]
    public void CalculateArea()
    {
        var square = new Square(0, 0, 2);
        Assert.That(square.Calculate(), Is.EqualTo(4));
    }

    [Test]
    public void ToString_()
    {
        var square = new Square(0, 0, 1, new Color("Red"));
        Assert.That(square.ToString(), Is.EqualTo("Square: (0:0) edgeLength=1 color=#FF0000"));
    }

    [Test]
    public void ToXml()
    {
        var square = new Square(0, 1, 2);
        var xml = square.ToXml();
        Assert.That(xml, Is.EqualTo("<square x=\"0\" y=\"1\" edgeLength=\"2\" />\n"));
    }

    [Test]
    public void ContainsPoints()
    {
        var square = new Square(0, 0, 1);

        Assert.That(square.ContainsPoint(0, 0), Is.True);
        Assert.That(square.ContainsPoint(0, 1), Is.True);
        Assert.That(square.ContainsPoint(1, 1), Is.True);
        Assert.That(square.ContainsPoint(1, 0), Is.True);

        Assert.That(square.ContainsPoint(-1, -1), Is.False);
        Assert.That(square.ContainsPoint(-1, 0), Is.False);
        Assert.That(square.ContainsPoint(0, -1), Is.False);
        Assert.That(square.ContainsPoint(1, 2), Is.False);
        Assert.That(square.ContainsPoint(2, 1), Is.False);
    }

    [Test]
    public void GetHeight()
    {
        Assert.That(() => new Square(0, 0, 0).Height, Throws.Exception.TypeOf<InvalidOperationException>());
    }
}