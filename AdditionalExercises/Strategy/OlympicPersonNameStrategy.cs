namespace AdditionalExercises.Strategy;

public class OlympicPersonNameStrategy : PersonNameStrategy
{
    private static readonly List<string> SurnameFirst = ["CHN", "KOR"];

    public OlympicPersonNameStrategy(string nationality, bool capitalizeSurname)
        : base(nationality, capitalizeSurname)
    {
    }

    public override string NameString(string givenName, string familyName)
    {
        var surname = familyName;
        if (capitalizeSurname)
        {
            surname = familyName.ToUpperInvariant();
        }

        if (SurnameFirst.Contains(nationality))
        {
            return surname + " " + givenName;
        }

        return givenName + " " + surname;
    }
}