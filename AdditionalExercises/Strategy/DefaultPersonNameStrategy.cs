namespace AdditionalExercises.Strategy;

public class DefaultPersonNameStrategy : PersonNameStrategy
{
    protected DefaultPersonNameStrategy(string nationality, bool capitalizeSurname, bool olympicMode)
        : base(nationality, capitalizeSurname, olympicMode)
    {
    }
}