namespace AdditionalExercises.Strategy;

public abstract class PersonNameStrategy
{
    protected static readonly List<string> SurnameFirst = ["CHN", "KOR"];
    protected readonly bool capitalizeSurname;
    protected readonly string nationality;
    protected readonly bool olympicMode;

    protected PersonNameStrategy(string nationality, bool capitalizeSurname, bool olympicMode)
    {
        this.nationality = nationality;
        this.capitalizeSurname = capitalizeSurname;
        this.olympicMode = olympicMode;
    }

    public static PersonNameStrategy Create(string nationality, bool capitalizeSurname, bool olympicMode)
    {
        return olympicMode
            ? new OlympicPersonNameStrategy(nationality, capitalizeSurname, true)
            : new DefaultPersonNameStrategy(nationality, capitalizeSurname, false);
    }

    public abstract string NameString(string givenName, string familyName);
}