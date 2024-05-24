namespace AdditionalExercises.Strategy;

public class Person
{
    private readonly string familyName;
    private readonly string givenName;
    private readonly PersonNameStrategy personNameStrategy;

    public Person(string familyName, string givenName, string nationality)
        : this(familyName, givenName, nationality, false, false)
    {
        personNameStrategy = new PersonNameStrategy();
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
        return NameString();
    }

    private string NameString()
    {
        var surname = familyName;
        if (personNameStrategy.capitalizeSurname)
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
        if (!personNameStrategy.olympicMode)
        {
            return false;
        }

        return PersonNameStrategy.SurnameFirst.Contains(personNameStrategy.nationality);
    }
}