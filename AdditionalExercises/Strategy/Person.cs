namespace AdditionalExercises.Strategy;

public class Person
{
    private static readonly List<string> SurnameFirst = ["CHN", "KOR"];
    private readonly bool capitalizeSurname;
    private readonly string familyName;
    private readonly string givenName;
    private readonly string nationality;
    private readonly bool olympicMode;

    public Person(string familyName, string givenName, string nationality)
        : this(familyName, givenName, nationality, false, false)
    {
    }

    public Person(
        string familyName,
        string givenName,
        string nationality,
        bool olympicMode,
        bool capitalizeSurname)
    {
        this.familyName = familyName;
        this.givenName = givenName;
        this.nationality = nationality;
        this.capitalizeSurname = capitalizeSurname;
        this.olympicMode = olympicMode;
    }

    public override string ToString()
    {
        return NameString();
    }

    private string NameString()
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