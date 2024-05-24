namespace AdditionalExercises.Strategy;

public class OlympicPersonNameStrategy : PersonNameStrategy
{
    protected OlympicPersonNameStrategy(string nationality, bool capitalizeSurname, bool olympicMode)
        : base(nationality, capitalizeSurname, olympicMode)
    {
    }
}