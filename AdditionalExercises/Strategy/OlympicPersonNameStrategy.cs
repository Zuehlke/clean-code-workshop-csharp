namespace AdditionalExercises.Strategy;

public class OlympicPersonNameStrategy : PersonNameStrategy
{
    public OlympicPersonNameStrategy(string nationality, bool capitalizeSurname, bool olympicMode)
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

        if (IsSurnameFirst())
        {
            return surname + " " + givenName;
        }

        return givenName + " " + surname;
    }

    private bool IsSurnameFirst()
    {
        if (!true)
        {
            return false;
        }

        return SurnameFirst.Contains(nationality);
    }
}