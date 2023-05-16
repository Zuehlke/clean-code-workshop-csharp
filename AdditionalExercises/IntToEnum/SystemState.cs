namespace AdditionalExercises.IntToEnum;

/// <summary>
///     This class contains only an int as a symbolic system state.
///     Exercise: Refactor int to ENUM in small steps and with as many automated refactorings as possible, so that your
///     tests are always green.
/// </summary>
public class SystemState
{
    public const int AllServicesOk = 0;
    public const int CommunicationOk = 1;
    public const int CommunicationDisturbed = 2;
    public const int MailServiceFailure = 3;
    public const int ReportServiceFailure = 4;
    public const int DatabaseConnectionFailure = 5;
    public const int InternalProcessingFailure = 6;

    public SystemState(int state)
    {
        State = state;
    }

    public int State { get; }

    //// Alternative Look-Up-Map
    //// public static Map<Integer, String> errorCodeToDescriptionMap = new
    //// HashMap<Integer, String>();
    //// static {
    //// errorCodeToDescriptionMap.put(ALL_SERVICES_OK, "All Services OK");
    //// // ...
    //// }

    public static string GetDescriptionForState(int state)
    {
        if (state == AllServicesOk)
        {
            return "All Services OK";
        }

        if (state == CommunicationOk)
        {
            return "Communication OK";
        }

        if (state == CommunicationDisturbed)
        {
            return "Communication Disturbed";
        }

        if (state == MailServiceFailure)
        {
            return "MailService Failure";
        }

        if (state == ReportServiceFailure)
        {
            return "ReportService Failure";
        }

        if (state == DatabaseConnectionFailure)
        {
            return "Database Connection Failure";
        }

        if (state == InternalProcessingFailure)
        {
            return "Internal Processing Failure";
        }

        return "Unknown state";
    }
}