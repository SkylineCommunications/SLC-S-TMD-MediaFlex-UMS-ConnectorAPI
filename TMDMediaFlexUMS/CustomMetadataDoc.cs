namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a custom metadata document within a Media Asset Management (MAM) system.
    /// Used for defining and storing metadata that extends beyond standard schemas.
    /// </summary>
    [XmlRoot("customMetadataDoc")]
    public class CustomMetadataDoc
    {
        /// <summary>
        /// The identifier of the schema associated with this metadata document.
        /// Specifies the structure and validation rules for the metadata content.
        /// </summary>
        [XmlElement("schemaId")]
        [JsonProperty("schemaId")]
        public string SchemaId { get; set; }

        /// <summary>
        /// The body of the metadata document, containing the actual metadata content.
        /// Encapsulates data defined by the specified schema.
        /// </summary>
        [XmlElement("documentBody")]
        [JsonProperty("documentBody")]
        public DocumentBody DocumentBody { get; set; }
    }

}
