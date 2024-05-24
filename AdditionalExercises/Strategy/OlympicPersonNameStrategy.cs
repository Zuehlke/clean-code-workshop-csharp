namespace AdditionalExercises.Strategy;

public class OlympicPersonNameStrategy : PersonNameStrategy
{
    private static readonly List<string> SurnameFirst = ["CHN", "KOR"];
    protected readonly string nationality;

    public OlympicPersonNameStrategy(string nationality, bool capitalizeSurname)
        : base(nationality, capitalizeSurname)
    {
        this.nationality = nationality;
    }

    public override string NameString(string givenName, string familyName)
    {
        var surname = GetSurname(familyName);

        if (SurnameFirst.Contains(nationality))
        {
            return surname + " " + givenName;
        }

        return givenName + " " + surname;
    }
}