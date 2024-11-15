namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Collection of audio assets.
    /// </summary>
    public class AudioAssetInfo
    {
        /// <summary>
        /// Gets or sets the audio assets.
        /// </summary>
        [JsonProperty("AudioAsset")]
        public AudioAsset AudioAsset { get; set; }
    }
}
