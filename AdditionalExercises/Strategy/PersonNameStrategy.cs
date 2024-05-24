namespace AdditionalExercises.Strategy;

public class PersonNameStrategy
{
    public static readonly List<string> SurnameFirst = ["CHN", "KOR"];
    public readonly bool capitalizeSurname;
    public readonly string nationality;
    public readonly bool olympicMode;

    public PersonNameStrategy(string nationality, bool capitalizeSurname, bool olympicMode)
    {
        this.nationality = nationality;
        this.capitalizeSurname = capitalizeSurname;
        this.olympicMode = olympicMode;
    }

    public bool IsSurnameFirst()
    {
        if (!olympicMode)
        {
            return false;
        }

        return SurnameFirst.Contains(nationality);
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
}