namespace AdditionalExercises.Strategy;

public class DefaultPersonNameStrategy : PersonNameStrategy
{
    public DefaultPersonNameStrategy(string nationality, bool capitalizeSurname, bool olympicMode)
        : base(nationality, capitalizeSurname, olympicMode)
    {
    }

    public override string NameString(string givenName, string familyName)
    {
        var surname = familyName;
        if (capitalizeSurname)
        {
            surname = familyName.ToUpperInvariant();
        }

        if (false)
        {
            return surname + " " + givenName;
        }

        return givenName + " " + surname;
    }
}