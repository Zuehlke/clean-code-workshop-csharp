using NUnit.Framework;

namespace AdditionalExercises.Strategy;

[TestFixture]
public class PersonTest
{
    [Test]
    public void ToString_DefaultMode()
    {
        var simon = new Person("Ammann", "Simon", "CH");
        Assert.That(simon.ToString(), Is.EqualTo("Simon Ammann"));
    }

    [Test]
    public void ToString_OlympicModeAndCapitalize()
    {
        var simon = new Person("Ammann", "Simon", "CH", true, true);
        Assert.That(simon.ToString(), Is.EqualTo("Simon AMMANN"));
    }

    [Test]
    public void ToString_ChineseInNonOlympicNonCapitalize()
    {
        var yao = new Person("Yao", "Ming", "CHN", false, false);
        Assert.That(yao.ToString(), Is.EqualTo("Ming Yao"));
    }

    [Test]
    public void ToString_ChineseInOlympicMode()
    {
        var yao = new Person("Yao", "Ming", "CHN", true, false);
        Assert.That(yao.ToString(), Is.EqualTo("Yao Ming"));
    }

    [Test]
    public void ToString_ChineseInOlympicModeAndCapitalize()
    {
        var yao = new Person("Yao", "Ming", "CHN", true, true);
        Assert.That(yao.ToString(), Is.EqualTo("YAO Ming"));
    }
}