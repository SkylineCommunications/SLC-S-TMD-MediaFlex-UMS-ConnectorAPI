namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.IO;

    /// <summary>
    /// Represents a task or operation within a Media Asset Management (MAM) system.
    /// Encapsulates metadata and parameters for processing media assets in workflows.
    /// </summary>
    [XmlRoot("job")]
    public class Job
    {
        /// <summary>
        /// Identifies the preset or configuration template applied to the job.
        /// Commonly used for specifying a workflow or operation setup in MAM systems.
        /// </summary>
        [XmlElement("presetName")]
        public string PresetName { get; set; } = "DataminerMTDInWflow";

        /// <summary>
        /// Stores additional information or comments related to the job.
        /// Useful for annotating specific instructions or documenting the job’s purpose.
        /// </summary>
        [XmlElement("notes")]
        public string Notes { get; set; } = "Test Dataminer version job w Doc";

        /// <summary>
        /// A reference identifier provided by the client for tracking the job.
        /// Links MAM operations to external systems or business references.
        /// </summary>
        [XmlElement("clientJobRef")]
        public string ClientJobRef { get; set; } = string.Empty;

        /// <summary>
        /// Specifies the client or organization associated with the job.
        /// Represents a broadcaster, production house, or other stakeholders.
        /// </summary>
        [XmlElement("client")]
        public string Client { get; set; } = "YLE";

        /// <summary>
        /// A unique identifier for the job within the MAM system.
        /// Ensures traceability and facilitates cross-referencing.
        /// </summary>
        [XmlElement("jobRef")]
        public string JobRef { get; set; } = string.Empty;

        /// <summary>
        /// Indicates the urgency or importance of the job.
        /// High-priority jobs may be expedited within the workflow.
        /// </summary>
        [XmlElement("priority")]
        public string Priority { get; set; } = "High";

        /// <summary>
        /// A collection of custom metadata documents associated with the job.
        /// Used for extending metadata beyond standard fields.
        /// </summary>
        [XmlArray("customMetadataDocs")]
        [XmlArrayItem("customMetadataDoc")]
        public List<CustomMetadataDoc> CustomMetadataDocs { get; set; } = new List<CustomMetadataDoc>();

        /// <summary>
        /// Specifies the type of source for the version being processed.
        /// Relevant in workflows involving media transformations or versioning.
        /// </summary>
        [XmlElement("versionSourceType")]
        public string VersionSourceType { get; set; }

        /// <summary>
        /// A list of source items (e.g., media file paths or asset IDs) associated with the job.
        /// Defines the input materials for the job's operations.
        /// </summary>
        [XmlArray("sourceItems")]
        [XmlArrayItem("sourceItem")]
        public List<string> SourceItems { get; set; } = new List<string>();

        /// <summary>
        /// Serializes the current job to XML.
        /// </summary>
        /// <returns>XML serialized string representing this instance.</returns>
        public string Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Job));
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, this);
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Deserializes the provided XML to a job instance.
        /// </summary>
        /// <param name="serializedJob">XML representing a job instance.</param>
        /// <returns></returns>
        public static Job Deserialize(string serializedJob)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Job));
            using (var stringReader = new StringReader(serializedJob))
            {
                return (Job)serializer.Deserialize(stringReader);
            }
        }
    }
}
