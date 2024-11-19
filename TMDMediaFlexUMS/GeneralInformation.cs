namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using System;
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents general information related to an asset, including metadata such as order name, timestamps,
    /// source system, and various flags related to archiving, rerun needs, and subtitle proxies.
    /// </summary>
    [XmlRoot("GeneralInformation")]
    public class GeneralInformation
    {
        /// <summary>
        /// Gets or sets the name of the live order associated with this asset.
        /// </summary>
        [XmlElement("LiveOrderName")]
        public string LiveOrderName { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the asset information was created or updated.
        /// </summary>
        [XmlElement("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the source system from which this asset information originated.
        /// </summary>
        [XmlElement("sourceSystem")]
        public string SourceSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a subtitle proxy is needed for the asset.
        /// </summary>
        [XmlElement("SubtitleProxyNeeded")]
        public bool SubtitleProxyNeeded { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a fast rerun is required for the asset.
        /// </summary>
        [XmlElement("FastRerun")]
        public bool FastRerun { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a copy of the asset is needed for the Areena service.
        /// </summary>
        [XmlElement("AreenaCopyNeeded")]
        public bool AreenaCopyNeeded { get; set; }

        /// <summary>
        /// Gets or sets the deadline for archiving the asset.
        /// </summary>
        [XmlElement("DeadlineForArchiving")]
        public DateTime DeadlineForArchiving { get; set; }
    }

}
