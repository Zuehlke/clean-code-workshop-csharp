namespace AdditionalExercises.Strategy;

public class Person
{
    private readonly string familyName;
    private readonly string givenName;
    private readonly PersonNameStrategy personNameStrategy;

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
        personNameStrategy = new PersonNameStrategy(nationality, capitalizeSurname, olympicMode);
    }

    public override string ToString()
    {
        return NameString(givenName);
    }

    private string NameString(string givenName)
    {
        var surname = familyName;
        if (personNameStrategy.capitalizeSurname)
        {
            surname = familyName.ToUpperInvariant();
        }

        if (personNameStrategy.IsSurnameFirst())
        {
            return surname + " " + givenName;
        }

        return givenName + " " + surname;
    }
}