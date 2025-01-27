namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS.Models.Element
{
    using System.ComponentModel;

    /// <summary>
    /// Type of the file status update.
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Program video type.
        /// </summary>
        [Description("PROGRAM_VIDEO")]
        ProgramVideo = 0,

        /// <summary>
        /// Subtitle proxies type.
        /// </summary>
        [Description("SUBTITLE_PROXIES")]
        SubtitleProxy = 1,
    }

    /// <summary>
    /// Status of the file status update.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Queued
        /// </summary>
        [Description("Queued")]
        Queued = 0,

        /// <summary>
        /// Workflow started
        /// </summary>
        [Description("WORKFLOW_STARTED")]
        WorkflowStarted = 1,

        /// <summary>
        /// QC Passed
        /// </summary>
        [Description("QC_PASSED")]
        QcPassed = 2,

        /// <summary>
        /// QC Failed
        /// </summary>
        [Description("QC_FAILED")]
        QcFailed = 3,

        /// <summary>
        /// Delivery Successful
        /// </summary>
        [Description("DELIVERY_SUCCESSFUL")]
        DeliverySuccessful = 4,

        /// <summary>
        /// Delivery Failed.
        /// </summary>
        [Description("DELIVERY_FAILED")]
        DeliveryFailed = 5,
    }
}
