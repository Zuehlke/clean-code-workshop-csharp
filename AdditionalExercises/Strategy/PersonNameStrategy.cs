namespace AdditionalExercises.Strategy;

public abstract class PersonNameStrategy
{
    private static readonly List<string> SurnameFirst = ["CHN", "KOR"];
    private readonly bool capitalizeSurname;
    private readonly string nationality;
    private readonly bool olympicMode;

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

    public string NameString(string givenName, string familyName)
    {
        var surname = familyName;
        if (capitalizeSurname)
        {
            surname = familyName.ToUpperInvariant();
        }

        if (IsSurnameFirst())
        {
            return surname + " " + givenName;
        }

        return givenName + " " + surname;
    }

    private bool IsSurnameFirst()
    {
        if (!olympicMode)
        {
            return false;
        }

        return SurnameFirst.Contains(nationality);
    }
}