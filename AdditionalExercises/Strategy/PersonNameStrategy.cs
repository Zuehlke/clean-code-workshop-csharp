namespace AdditionalExercises.Strategy;

public abstract class PersonNameStrategy
{
    protected readonly bool capitalizeSurname;

    protected PersonNameStrategy(bool capitalizeSurname)
    {
        this.capitalizeSurname = capitalizeSurname;
    }

    public static PersonNameStrategy Create(string nationality, bool capitalizeSurname, bool olympicMode)
    {
        return olympicMode
            ? new OlympicPersonNameStrategy(nationality, capitalizeSurname)
            : new DefaultPersonNameStrategy(capitalizeSurname);
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