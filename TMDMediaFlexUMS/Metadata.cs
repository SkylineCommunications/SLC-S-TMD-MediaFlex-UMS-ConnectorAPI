namespace Skyline.DataMiner.ConnectorAPI.TMDMediaFlexUMS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the metadata structure used in Media Asset Management (MAM) systems.
    /// This class contains properties for managing various aspects of media content.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Contains general information about the media asset, such as title, description, and creation date.
        /// Useful for categorization and search functionality in a MAM system.
        /// </summary>
        [JsonProperty("GeneralInformation")]
        public GeneralInformation GeneralInformation { get; set; }

        /// <summary>
        /// Represents the results of the final check or quality control process
        /// performed on the media asset before approval or publication.
        /// </summary>
        [JsonProperty("FinalCheck")]
        public FinalCheck FinalCheck { get; set; }

        /// <summary>
        /// Includes specific details about the video program or clip, 
        /// such as format, duration, and technical specifications, essential for playback and distribution.
        /// </summary>
        [JsonProperty("VideoProgramClipSpecificInfo")]
        public VideoProgramClipSpecificInfo VideoProgramClipSpecificInfo { get; set; }
    }
}
