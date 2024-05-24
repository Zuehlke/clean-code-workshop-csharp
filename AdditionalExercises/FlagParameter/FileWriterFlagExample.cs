namespace AdditionalExercises.FlagParameter;

public static class FileWriterFlagExample
{
    public static void Main()
    {
        var file = File.ReadAllText("example.txt");

        // hard to understand ???
        var fileWriter = new FileWriter(file, true);
        var fileWriter2 = new FileWriter(file, false);

        // define readable constants??
        const bool appendMode = true;
        const bool overwriteMode = false;
        var appendingfileWriter = new FileWriter(file, appendMode);
        var overwritingfileWriter = new FileWriter(file, overwriteMode);

        // Enums?
    }
}