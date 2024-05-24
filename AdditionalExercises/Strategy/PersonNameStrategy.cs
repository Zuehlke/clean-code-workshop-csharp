namespace AdditionalExercises.Strategy;

public class PersonNameStrategy
{
    public static readonly List<string> SurnameFirst = ["CHN", "KOR"];
    public readonly bool capitalizeSurname;
    public readonly string nationality;
    public readonly bool olympicMode;

    public PersonNameStrategy(string nationality, bool capitalizeSurname, bool olympicMode)
    {
        this.nationality = nationality;
        this.capitalizeSurname = capitalizeSurname;
        this.olympicMode = olympicMode;
    }
}