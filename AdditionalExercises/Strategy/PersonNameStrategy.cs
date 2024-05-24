namespace AdditionalExercises.Strategy;

public abstract class PersonNameStrategy
{
    private readonly bool capitalizeSurname;

    protected PersonNameStrategy(bool capitalizeSurname)
    {
        this.capitalizeSurname = capitalizeSurname;
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