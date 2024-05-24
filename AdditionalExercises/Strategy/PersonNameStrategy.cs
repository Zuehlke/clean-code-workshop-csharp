namespace AdditionalExercises.Strategy;

public abstract class PersonNameStrategy
{
    protected readonly bool capitalizeSurname;
    protected readonly string nationality;

    protected PersonNameStrategy(string nationality, bool capitalizeSurname)
    {
        this.nationality = nationality;
        this.capitalizeSurname = capitalizeSurname;
    }

    public static PersonNameStrategy Create(string nationality, bool capitalizeSurname, bool olympicMode)
    {
        return olympicMode
            ? new OlympicPersonNameStrategy(nationality, capitalizeSurname)
            : new DefaultPersonNameStrategy(nationality, capitalizeSurname);
    }

    public abstract string NameString(string givenName, string familyName);

    protected string GetSurname(string familyName)
    {
        var surname = familyName;
        if (capitalizeSurname)
        {
            surname = familyName.ToUpperInvariant();
        }

        return surname;
    }
}