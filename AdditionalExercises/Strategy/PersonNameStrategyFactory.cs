namespace AdditionalExercises.Strategy;

public static class PersonNameStrategyFactory
{
    public static PersonNameStrategy Create(string nationality, bool capitalizeSurname, bool olympicMode)
    {
        return olympicMode
            ? new OlympicPersonNameStrategy(nationality, capitalizeSurname)
            : new DefaultPersonNameStrategy(capitalizeSurname);
    }
}