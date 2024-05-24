namespace AdditionalExercises.Strategy;

public class DefaultPersonNameStrategy : PersonNameStrategy
{
    public DefaultPersonNameStrategy(string nationality, bool capitalizeSurname)
        : base(nationality, capitalizeSurname)
    {
    }

    public override string NameString(string givenName, string familyName)
    {
        var surname = GetSurname(familyName);

        return givenName + " " + surname;
    }
}