namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Represents a task or operation within a Media Asset Management (MAM) system.
    /// Encapsulates metadata and parameters for processing media assets in workflows.
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Identifies the preset or configuration template applied to the job.
        /// Commonly used for specifying a workflow or operation setup in MAM systems.
        /// </summary>
        [JsonProperty("presetName")]
        public string PresetName { get; set; } = "DataminerMTDInWflow";

        /// <summary>
        /// Stores additional information or comments related to the job.
        /// Useful for annotating specific instructions or documenting the job’s purpose.
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; } = "Test Dataminer version job w Doc";

        /// <summary>
        /// A reference identifier provided by the client for tracking the job.
        /// Links MAM operations to external systems or business references.
        /// </summary>
        [JsonProperty("clientJobRef")]
        public string ClientJobRef { get; set; } = string.Empty;

        /// <summary>
        /// Specifies the client or organization associated with the job.
        /// Represents a broadcaster, production house, or other stakeholders.
        /// </summary>
        [JsonProperty("client")]
        public string Client { get; set; } = "YLE";

        /// <summary>
        /// A unique identifier for the job within the MAM system.
        /// Ensures traceability and facilitates cross-referencing.
        /// </summary>
        [JsonProperty("jobRef")]
        public string JobRef { get; set; } = string.Empty;

        /// <summary>
        /// Indicates the urgency or importance of the job.
        /// High-priority jobs may be expedited within the workflow.
        /// </summary>
        [JsonProperty("priority")]
        public string Priority { get; set; } = "High";

        /// <summary>
        /// A collection of custom metadata documents associated with the job.
        /// Used for extending metadata beyond standard fields.
        /// </summary>
        [JsonProperty("customMetadataDocs")]
        public List<CustomMetadataDoc> CustomMetadataDocs { get; set; } = new List<CustomMetadataDoc>();

        /// <summary>
        /// Specifies the type of source for the version being processed.
        /// Relevant in workflows involving media transformations or versioning.
        /// </summary>
        [JsonProperty("versionSourceType")]
        public string VersionSourceType { get; set; }

        /// <summary>
        /// A list of source items (e.g., media file paths or asset IDs) associated with the job.
        /// Defines the input materials for the job's operations.
        /// </summary>
        [JsonProperty("sourceItems")]
        public List<string> SourceItems { get; set; } = new List<string>();
    }

}
