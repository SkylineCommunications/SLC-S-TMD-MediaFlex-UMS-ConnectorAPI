namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents general information related to an asset, including metadata such as order name, timestamps,
    /// source system, and various flags related to archiving, rerun needs, and subtitle proxies.
    /// </summary>
    public class GeneralInformation
    {
        /// <summary>
        /// Gets or sets the name of the live order associated with this asset.
        /// </summary>
        [JsonProperty("LiveOrderName")]
        public string LiveOrderName { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the asset information was created or updated.
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the source system from which this asset information originated.
        /// </summary>
        [JsonProperty("sourceSystem")]
        public string SourceSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a subtitle proxy is needed for the asset.
        /// </summary>
        [JsonProperty("SubtitleProxyNeeded")]
        public bool SubtitleProxyNeeded { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a fast rerun is required for the asset.
        /// </summary>
        [JsonProperty("FastRerun")]
        public bool FastRerun { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a copy of the asset is needed for the Areena service.
        /// </summary>
        [JsonProperty("AreenaCopyNeeded")]
        public bool AreenaCopyNeeded { get; set; }

        /// <summary>
        /// Gets or sets the deadline for archiving the asset.
        /// </summary>
        [JsonProperty("DeadlineForArchiving")]
        public DateTime DeadlineForArchiving { get; set; }
    }

}
