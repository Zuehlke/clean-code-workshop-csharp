namespace AdditionalExercises.Strategy;

internal sealed class OlympicPersonNameStrategy : PersonNameStrategy
{
    private static readonly List<string> SurnameFirst = ["CHN", "KOR"];
    private readonly string nationality;

    internal OlympicPersonNameStrategy(string nationality, bool capitalizeSurname)
        : base(capitalizeSurname)
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