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
        /// Gets or sets the Plasma ID of the request. This Plasma ID uniquely identifies the recording to be archived in MediaFlex.
        /// </summary>
        public string PlasmaId { get; set; }

        /// <summary>
        /// Gets or sets the metadata to be delivered to MediaFlex.
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}
