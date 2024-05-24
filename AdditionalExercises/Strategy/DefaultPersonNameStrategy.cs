namespace AdditionalExercises.Strategy;

internal sealed class DefaultPersonNameStrategy : PersonNameStrategy
{
    internal DefaultPersonNameStrategy(bool capitalizeSurname)
        : base(capitalizeSurname)
    {
    }

    public override string NameString(string givenName, string familyName)
    {
        return givenName + " " + GetSurname(familyName);
    }
}