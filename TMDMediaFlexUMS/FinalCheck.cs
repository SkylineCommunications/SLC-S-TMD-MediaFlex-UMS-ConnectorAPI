namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the final check process for a media asset, including comments from the MAM import process
    /// and the name of the media operator responsible for the check.
    /// </summary>
    public class FinalCheck
    {
        /// <summary>
        /// Gets or sets the comments related to the MAM (Media Asset Management) import process.
        /// </summary>
        [JsonProperty("MAMImportComments")]
        public string MAMImportComments { get; set; }

        /// <summary>
        /// Gets or sets the name of the media operator responsible for the final check process.
        /// </summary>
        [JsonProperty("MediaOperatorName")]
        public string MediaOperatorName { get; set; }
    }
}
