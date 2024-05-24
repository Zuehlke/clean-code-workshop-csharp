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
        personNameStrategy = PersonNameStrategyFactory.Create(nationality, capitalizeSurname, olympicMode);
    }

    public override string ToString()
    {
        return personNameStrategy.NameString(givenName, familyName);
    }
}