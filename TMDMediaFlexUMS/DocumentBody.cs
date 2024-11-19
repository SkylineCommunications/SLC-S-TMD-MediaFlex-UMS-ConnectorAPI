namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents the body of a document within a Media Asset Management (MAM) system.
    /// Encapsulates metadata related to the document for processing and management.
    /// </summary>
    [XmlRoot("documentBody")]
    public class DocumentBody
    {
        /// <summary>
        /// Contains metadata specific to Dataminer, a component or module
        /// responsible for managing or processing media-related metadata.
        /// </summary>
        [XmlElement("DataminerMetadata")]
        public DataminerMetadata DataminerMetadata { get; set; }
    }

}
