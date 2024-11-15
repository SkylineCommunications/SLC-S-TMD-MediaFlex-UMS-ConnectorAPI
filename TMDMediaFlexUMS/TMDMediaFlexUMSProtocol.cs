namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    /// <summary>
    /// Defines some of the key Parameter Ids used for communicating with a TMD MediaFlex UMS element running the 2.0.0.X range.
    /// </summary>
    public static class TMDMediaFlexUMSProtocol
    {
        /// <summary>
        /// ID of the read parameter containing the Timeout value in seconds used for all InterApp communication to the element.
        /// </summary>
        public static readonly int InterAppTimeoutPid = 250;

        /// <summary>
        /// ID of the read parameter to on which all InterApp messages are received.
        /// </summary>
        public static readonly int InterAppReceivePid = 9000000;
    }
}
