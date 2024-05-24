namespace AdditionalExercises.Strategy;

public class DefaultPersonNameStrategy : PersonNameStrategy
{
    public DefaultPersonNameStrategy(bool capitalizeSurname)
        : base(capitalizeSurname)
    {
    }

    public override string NameString(string givenName, string familyName)
    {
        return givenName + " " + GetSurname(familyName);
    }
}