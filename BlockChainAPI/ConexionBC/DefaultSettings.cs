namespace ConexionBC
{
    public class DefaultSettings
    {
        public static string QuorumIPAddress = "http://40.70.187.240";
        public static string QuorumPort = "30303";

        public static string GetDefaultUrl()
        {
            return QuorumIPAddress + ":" + QuorumPort;
        }
    }
}