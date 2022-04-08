using NUnit.Framework;
using SmellyShapes.Source;

namespace SmellyShapes.Specifications;

[TestFixture]
public class ColorTest
{
    [Test]
    public void GetErrorMessage_InvalidColor()
    {
        var c = new Color("INVALIDColor_N4me");
        Assert.That(c.ErrorMessage, Is.EqualTo("Color not recognized"));
    }

    [Test]
    public void GetErrorMessage_Magenta()
    {
        var c = new Color("Magenta");
        Assert.That(c.ErrorMessage, Is.EqualTo("Color not recognized"));
    }

    [Test]
    public void GetErrorMessage_Cyan()
    {
        var c = new Color("Cyan");
        Assert.That(c.ErrorMessage, Is.EqualTo("Color not recognized"));
    }

    [Test]
    public void GetColorFormatted_Red()
    {
        var color = new Color("Red");
        var colorFormatted = false ? color.GetColorFormatted() : color.GetColorAsText();
        Assert.That(colorFormatted, Is.EqualTo("Red"));
    }

    [Test]
    public void GetColorFormatted_Green()
    {
        var color = new Color("Green");
        var colorFormatted = false ? color.GetColorFormatted() : color.GetColorAsText();
        Assert.That(colorFormatted, Is.EqualTo("Green"));
    }

    [Test]
    public void GetColorFormatted_Red_Incl()
    {
        var c = new Color("Red");
        var formattedColor = true ? c.GetColorFormatted() : c.GetColorAsText();
        Assert.That(formattedColor, Is.EqualTo("Red #FF0000 255:0:0"));
    }
}