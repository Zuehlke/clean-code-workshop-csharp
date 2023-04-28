namespace AdditionalExercises.IntToEnum
{
    /// <summary>
    /// This class contains only an int as a symbolic system state.
    /// 
    /// Exercise: Refactor int to ENUM in small steps and with as many automated refactorings as possible, so that your tests are always green.
    /// </summary>
    public class SystemState
    {
        public static int ALL_SERVICES_OK = 0;
        public static int COMMUNICATION_OK = 1;
        public static int COMMUNICATION_DISTURBED = 2;
        public static int MAIl_SERVICE_FAILURE = 3;
        public static int REPORT_SERVICE_FAILURE = 4;
        public static int DATABASE_CONNECTION_FAILURE = 5;
        public static int INTERNAL_PROCESING_FAILURE = 6;

        private int state;

        public SystemState(int state)
        {
            this.state = state;
        }

        public int getState()
        {
            return state;
        }

        // Alternative Look-Up-Map
        // public static Map<Integer, String> errorCodeToDescriptionMap = new
        // HashMap<Integer, String>();
        // static {
        // errorCodeToDescriptionMap.put(ALL_SERVICES_OK, "All Services OK");
        // // ...
        // }

        public static string getDescriptionForState(int state)
        {
            if (state == ALL_SERVICES_OK)
                return "All Services OK";

            if (state == COMMUNICATION_OK)
                return "Communication OK";

            if (state == COMMUNICATION_DISTURBED)
                return "Communication Disturbed";

            if (state == MAIl_SERVICE_FAILURE)
                return "MailService Failure";

            if (state == REPORT_SERVICE_FAILURE)
                return "ReportService Failure";

            if (state == DATABASE_CONNECTION_FAILURE)
                return "Database Connection Failure";

            if (state == INTERNAL_PROCESING_FAILURE)
                return "Internal Processing Failure";

            return "Unknown state";
        }
    }
}
