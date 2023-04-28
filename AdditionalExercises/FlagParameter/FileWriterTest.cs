using NUnit.Framework;

namespace AdditionalExercises.FlagParameter;

[TestFixture]
public class FileWriterTest
{
    [Test]
    public void TestWriteContentInOverwriteMode()
    {
        var replacingFileWriter = new FileWriter("Initial Content", false);

        replacingFileWriter.Write("New Content", false);

        Assert.That(replacingFileWriter.GetContent(), Is.EqualTo("New Content"));
    }

    [Test]
    public void TestWriteContentInAppendMode()
    {
        var appendingFileWriter = new FileWriter("Initial Content", true);

        appendingFileWriter.Write("New Content", false);

        Assert.That(appendingFileWriter.GetContent(), Is.EqualTo("Initial Content" + "New Content"));
    }

    [Test]
    public void TestWriteWithoutFlush()
    {
        var appendingFileWriter = new FileWriter("Initial Content", true);

        appendingFileWriter.Write("New Content", false);

        Assert.That(appendingFileWriter.GetContent(), Is.EqualTo("Initial Content" + "New Content"));
        Assert.That(appendingFileWriter.IsContentFlushed(), Is.False);
    }

    [Test]
    public void TestWriteWithFlush()
    {
        var appendingFileWriter = new FileWriter("Initial Content", true);

        appendingFileWriter.Write("New Content", true);

        Assert.That(appendingFileWriter.GetContent(), Is.EqualTo("Initial Content" + "New Content"));
        Assert.That(appendingFileWriter.IsContentFlushed(), Is.True);
    }

    [Test]
    public void TestFlushContent()
    {
        var appendingFileWriter = new FileWriter("Initial Content", true);

        appendingFileWriter.FlushContent();

        Assert.That(appendingFileWriter.IsContentFlushed(), Is.True);
    }
}