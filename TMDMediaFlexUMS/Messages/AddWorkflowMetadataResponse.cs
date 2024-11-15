namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Messages
{
    using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;

    /// <summary>
    /// TMD MediaFlex UMS InterApp response message indicating whether pushing meta data to MediaFlex succeeded or not.
    /// </summary>
    public class AddWorkflowMetadataResponse : Message
    {
        /// <summary>
        /// Gets or sets the status indicating whether the meta data could be delivered to MediaFlex.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the reason why the meta data could not be delivered to, or handled by MediaFlex.
        /// </summary>
        public string Reason { get; set; }
    }
}
