namespace AdditionalExercises.FlagParameter
{
    using System.IO;

    public static class FileWriterFlagExample
    {
        public static void Main() 
        {
            var file = File.ReadAllText("example.txt");

            // hard to understand ???
            FileWriter fileWriter = new FileWriter(file, true);
            FileWriter fileWriter2 = new FileWriter(file, false);


            // define readable constants??
            const bool appendMode = true;
            const bool overwriteMode = false;
            FileWriter appendingfileWriter = new FileWriter(file, appendMode);
            FileWriter overwritingfileWriter = new FileWriter(file, overwriteMode);


            // Enums?

        
        }
    }
}

