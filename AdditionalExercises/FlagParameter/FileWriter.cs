namespace AdditionalExercises.FlagParameter;

/// <summary>
///     Demonstration of Flag Parameters.
/// </summary>
public class FileWriter
{
    private readonly bool isInAppendMode;
    private bool isContentFlushed;

    public FileWriter(string newContent, bool useAppendMode)
    {
        Content = newContent;
        isInAppendMode = useAppendMode;
        isContentFlushed = false;
    }

    public string Content { get; private set; }

    public void Write(string contentToWrite, bool doFlushContent)
    {
        isContentFlushed = false;

        if (isInAppendMode)
        {
            Content += contentToWrite;
        }
        else
        {
            Content = contentToWrite;
        }

        if (doFlushContent)
        {
            FlushContent();
        }
    }

    public void FlushContent()
    {
        isContentFlushed = true;
    }

    public bool IsInAppendMode()
    {
        return isInAppendMode;
    }

    public bool IsContentFlushed()
    {
        return isContentFlushed;
    }
}