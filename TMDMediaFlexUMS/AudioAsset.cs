namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using System.Xml.Serialization;

    /// <summary>
    /// Metadata about audio assets in the recording.
    /// </summary>
    [XmlRoot("AudioAsset")]
    public class AudioAsset
    {
        /// <summary>
        /// Gets or sets the track number of the audio asset.
        /// </summary>
        [XmlElement("trackNumber")]
        public int TrackNumber { get; set; }

        /// <summary>
        /// Gets or sets the mix type of the audio asset (e.g., stereo, mono, etc.).
        /// </summary>
        [XmlElement("mixType")]
        public string MixType { get; set; }

        /// <summary>
        /// Gets or sets the language of the audio asset (e.g., English, Spanish, etc.).
        /// </summary>
        [XmlElement("Language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the audio type (e.g., podcast, music, audiobook, etc.).
        /// </summary>
        [XmlElement("audioType")]
        public string AudioType { get; set; }
    }
}
