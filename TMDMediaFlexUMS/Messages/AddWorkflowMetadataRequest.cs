namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Messages
{
    using Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS;
    using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;

    /// <summary>
    /// TMD MediaFlex UMS InterApp request message the is used to provide metadata about a recording in MediaFlex.
    /// </summary>
    public class AddWorkflowMetadataRequest : Message
    {
        /// <summary>
        /// Gets or sets the job be sent to MediaFlex.
        /// </summary>
        public Job Job { get; set; }
    }
}
